using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Authentication;
using System.Security.Claims;
using System.Security.Cryptography;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using viBank_Api.DTO;
using viBank_Api.Helpers;
using viBank_Api.Models;
using Google.Apis.Auth;
namespace viBank_Api.Services.authService
{
    public class AuthService : IAuthService
    {
        private readonly AppDbContext _dbContext;
        private readonly TokenHelper _tokenHelper;
        private readonly IConfiguration _config;

        public AuthService(AppDbContext dbContext,IConfiguration config)
        {
            _config = config;
            _dbContext = dbContext;
            _tokenHelper = new TokenHelper(_config);

        }
        public async Task<TokenResponseDto> Login(LoginRequestDto loginRequestDto)
        {
            var user = await _dbContext.User
            .Include(user => user.Account)
            .FirstOrDefaultAsync(user => user.UserName == loginRequestDto.UserName);
            if (user == null)
            {
                throw new InvalidDataException("User not found");
            }

            bool isAccountHolder = user.RoleID == (int)UserRoles.User;
            if (isAccountHolder)
            {
                if (user.Account == null)
                {
                    throw new InvalidDataException("Account not found");
                }
            }
            var isPasswordValid = PasswordHelper.VerifyPassword(user.PasswordHash, loginRequestDto.Password);
            if (!isPasswordValid)
            {
                throw new InvalidCredentialException("Username or password is incorrect");
            }

            _ = int.TryParse(_config["TokenValidityInMinutes"], out int tokenValidityInMinutes);
            var token = _tokenHelper.CreateToken(user, tokenValidityInMinutes);
            var refreshToken = GenerateRefreshToken(user);
            var accessToken = token.UserToken;
            user.RefreshToken = refreshToken;
            _ = int.TryParse(_config["RefreshTokenValidityInMinutes"], out int RefreshTokenValidityInMinutes);
            user.RefreshTokenExpiryTime = DateTime.UtcNow.AddMinutes(RefreshTokenValidityInMinutes);
            await _dbContext.SaveChangesAsync();
            var returnedUser = new UserResponseDto()
            {
                ID = user.ID,
                UserName = user.UserName,
                Email = user.Email,
                RoleID = user.RoleID,
                AccountNumber = user.Account?.AccountNumber,
                RefreshToken = refreshToken
            };
            var result = new TokenResponseDto
            {
                Token = accessToken,
                User = returnedUser,
                RefreshToken = refreshToken,
                Expires = token.Token?.ValidTo
            };

            return result;
        }

      

        Task<TokenResponseDto> IAuthService.ForgotPassword(ForgotPasswordDto payload)
        {
            throw new NotImplementedException();
        }

        Task<bool> IAuthService.ResetPassword(ResetPasswordDto payload)
        {
            throw new NotImplementedException();
        }

        Task<bool> IAuthService.ValidateResetToken(ResetPasswordDto payload)
        {
            throw new NotImplementedException();
        }

        public async Task<TokenResponseDto> SignInWithGoogle(string idToken, string returnUrl = null, string remoteError = null)
        {
            try
            {
                // Validate the ID token and retrieve user information
                var user = await GetUserFromGoogleIdToken(idToken);

                // If user is not found, throw an exception
                if (user == null)
                {
                    throw new InvalidCredentialException("Failed to sign in with Google. User not found.");
                }

                // Create an access token and a refresh token for the user
                _ = int.TryParse(_config["TokenValidityInMinutes"], out int tokenValidityInMinutes);
                var token = _tokenHelper.CreateToken(user, tokenValidityInMinutes);

                var accessToken = token.UserToken;

                // Generate a new refresh token for the user
                var refreshToken = GenerateRefreshToken(user);
                user.RefreshToken = refreshToken;

                _ = int.TryParse(_config["RefreshTokenValidityInMinutes"], out int refreshTokenValidityInMinutes);
                user.RefreshTokenExpiryTime = DateTime.UtcNow.AddMinutes(refreshTokenValidityInMinutes);

                // Save changes to the database
                await _dbContext.SaveChangesAsync();

                // Create the response data for the user
                var returnedUser = new UserResponseDto
                {
                    ID = user.ID,
                    UserName = user.UserName,
                    Email = user.Email,
                    RoleID = user.RoleID,
                    AccountNumber = user.Account?.AccountNumber,
                    RefreshToken = refreshToken
                };

                // Create a response object containing the token, refresh token, and user information
                var result = new TokenResponseDto
                {
                    Token = accessToken,
                    User = returnedUser,
                    RefreshToken = refreshToken,
                    Expires = token.Token?.ValidTo
                };

                return result;
            }
            catch (Exception ex)
            {
                // Handle any errors during the process
                throw new InvalidOperationException($"Failed to sign in with Google: {ex.Message}");
            }
        }
        public async Task<TokenResponseDto> SignInWithMicrosoft(string idToken, string returnUrl, string remoteError)
        {
            try
            {
                // Validate the ID token and retrieve user information using Microsoft's ID token validation
                var user = await GetUserFromMicrosoftIdToken(idToken);

                // If user is not found, throw an exception
                if (user == null)
                {
                    throw new InvalidCredentialException("Failed to sign in with Microsoft. User not found.");
                }

                // Create an access token and a refresh token for the user
                _ = int.TryParse(_config["TokenValidityInMinutes"], out int tokenValidityInMinutes);
                var token = _tokenHelper.CreateToken(user, tokenValidityInMinutes);

                var accessToken = token.UserToken;

                // Generate a new refresh token for the user
                var refreshToken = GenerateRefreshToken(user);
                user.RefreshToken = refreshToken;

                _ = int.TryParse(_config["RefreshTokenValidityInMinutes"], out int refreshTokenValidityInMinutes);
                user.RefreshTokenExpiryTime = DateTime.UtcNow.AddMinutes(refreshTokenValidityInMinutes);

                // Save changes to the database
                await _dbContext.SaveChangesAsync();

                // Create the response data for the user
                var returnedUser = new UserResponseDto
                {
                    ID = user.ID,
                    UserName = user.UserName,
                    Email = user.Email,
                    RoleID = user.RoleID,
                    AccountNumber = user.Account?.AccountNumber,
                    RefreshToken = refreshToken
                };

                // Create a response object containing the token, refresh token, and user information
                var result = new TokenResponseDto
                {
                    Token = accessToken,
                    User = returnedUser,
                    RefreshToken = refreshToken,
                    Expires = token.Token?.ValidTo
                };

                return result;
            }
            catch (Exception ex)
            {
                // Handle any errors during the process
                throw new InvalidOperationException($"Failed to sign in with Microsoft: {ex.Message}");
            }
        }
        public async Task<TokenResponseDto> RefreshToken(TokenModel tokenModel)
        {
            if (tokenModel == null)
            {
                throw new InvalidDataException("Invalid client token");
            }
            string? accessToken = tokenModel.AccessToken;
            string? refreshToken = tokenModel.RefreshToken;
            var principal = GetPrincipalFromToken(accessToken!);
            if(principal == null){
                throw new InvalidCredentialException("Invalid access token or refresh token");
            }
            var username = principal.Claims.AsEnumerable().First().Value;
            var user =await _dbContext.User
                            .FirstOrDefaultAsync(u =>u.UserName == username);
            if (user == null || user.RefreshToken != refreshToken || user.RefreshTokenExpiryTime <= DateTime.UtcNow)
            {
                throw new InvalidCredentialException("Invalid access token or refresh token");
            }
            _ = int.TryParse(_config["TokenValidityInMinutes"], out int tokenValidityInMinutes);
            var token = _tokenHelper.CreateToken(user, tokenValidityInMinutes);
            var newAccessToken = token.UserToken;
            var newRefreshToken = GenerateRefreshToken(user);
            user.RefreshToken = newRefreshToken;
            _ = int.TryParse(_config["RefreshTokenValidityInMinutes"], out int RefreshTokenValidityInMinutes);
            user.RefreshTokenExpiryTime = DateTime.UtcNow.AddMinutes(RefreshTokenValidityInMinutes);
            await _dbContext.SaveChangesAsync();
            var returnedUser = new UserResponseDto()
            {
                ID = user.ID,
                UserName = user.UserName,
                Email = user.Email,
                RoleID = user.RoleID,
                AccountNumber = user.Account?.AccountNumber,
                RefreshToken = newRefreshToken
            };
            var result = new TokenResponseDto
            {
                Token = accessToken,
                User = returnedUser,
                RefreshToken = newRefreshToken,
                Expires = token.Token?.ValidTo
            }
;
            return result;
           
        }
          private ClaimsPrincipal? GetPrincipalFromToken(string? token)
        {
            var tokenValidationParameters = new TokenValidationParameters
        {
            ValidateAudience = false,
            ValidateIssuer = false,
            ValidateIssuerSigningKey = true,
            IssuerSigningKey = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes(_config["Token"]!)),
            ValidateLifetime = true
        };

        var tokenHandler = new JwtSecurityTokenHandler();
        var principal = tokenHandler.ValidateToken(token, tokenValidationParameters, out _);

        return principal;
        }
          private string? GenerateRefreshToken(UserModel user)
        {
            var randomNumber = new byte[64];
            using (var rng = RandomNumberGenerator.Create())
            {
                rng.GetBytes(randomNumber);
                return Convert.ToBase64String(randomNumber);
            }
        }
        public async Task<UserModel?> GetUserFromGoogleIdToken(string idToken)
        {
            try
            {
                // Validate the ID token using Google.Apis.Auth
                var validPayload = await GoogleJsonWebSignature.ValidateAsync(idToken);

                if (validPayload == null)
                {
                    throw new InvalidCredentialException("Invalid Google ID token.");
                }

                // Retrieve the user's email and other information from the payload
                string email = validPayload.Email;

                // Perform any necessary checks on the user's email
                // For example, you might want to check if the user's email is allowed to sign in
                var user = await _dbContext.User.FirstOrDefaultAsync(u => u.Email == email);

                if (user == null)
                {
                    // Handle the case where the user is not found
                    // You may want to create a new user account, or deny access, based on your application logic
                    throw new InvalidCredentialException("User with the provided email not found.");
                }

                return user;
            }
            catch (Exception ex)
            {
                // Handle any errors during validation
                throw new InvalidOperationException("Failed to validate Google ID token: " + ex.Message);
            }
        }
        private async Task<UserModel?> GetUserFromMicrosoftIdToken(string idToken)
        {
            try
            {
                // Define the token validation parameters
                var tokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidateIssuerSigningKey = true,
                    ValidIssuer = "https://login.microsoftonline.com/{tenant_id}/v2.0",
                    ValidAudience = _config["Microsoft:ClientId"],
                    IssuerSigningKey = new SymmetricSecurityKey(
                        Convert.FromBase64String(_config["Microsoft:ClientSecret"])),
                    ValidateLifetime = true,
                };

                // Create a token handler
                var tokenHandler = new JwtSecurityTokenHandler();

                // Validate the ID token
                ClaimsPrincipal? principal = tokenHandler.ValidateToken(idToken, tokenValidationParameters, out _);

                // If the token validation fails, throw an exception
                if (principal == null)
                {
                    throw new SecurityTokenValidationException("Invalid ID token.");
                }

                // Retrieve the user's email from the claims
                var emailClaim = principal.FindFirst(ClaimTypes.Email);
                if (emailClaim == null)
                {
                    throw new InvalidOperationException("User's email not found in the token claims.");
                }

                string userEmail = emailClaim.Value;

                // Retrieve the user from the database using the email
                var user = await _dbContext.User.FirstOrDefaultAsync(u => u.Email == userEmail);

                // Return the user
                return user;
            }
            catch (Exception ex)
            {
                // Handle any errors during the process
                throw new InvalidOperationException($"Failed to validate Microsoft ID token: {ex.Message}");
            }
        }


    }


}
