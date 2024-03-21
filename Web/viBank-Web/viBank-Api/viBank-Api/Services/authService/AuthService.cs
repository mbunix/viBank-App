using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Authentication;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using viBank_Api.DTO;
using viBank_Api.Helpers;
using viBank_Api.Services.EmailService;

namespace viBank_Api.Services.authService
{
    public class AuthService : IAuthService
    {
        private readonly AppDbContext _dbContext;
        private readonly IConfiguration _config;
        private readonly IEmailService _emailService;

        public AuthService(AppDbContext dbContext, IConfiguration config, IEmailService emailService)
        {
            _config = config;
            _dbContext = dbContext;
            _emailService = emailService;

        }
        public async Task<TokenResponseDto> Login(LoginRequestDto loginRequestDto)
        {
            var user = await _dbContext.User
            .Include(user => user.Partner)
            .Include(user => user.RoleID)
            .FirstOrDefaultAsync(user => user.UserName == loginRequestDto.UserName);
            if (user == null)
            {
                throw new InvalidDataException("User not found");
            }
            bool isPatner = user.RoleID == (int)UserRoles.Partner;
            if (isPatner)
            {
                if (user.Partner == null)
                {
                    throw new InvalidDataException("Partner not found");
                }

            }
            bool isDistributor = user.RoleID == (int)UserRoles.Distributor;
            if (isDistributor)
            {
                if (user.Distributor == null)
                {
                    throw new InvalidDataException("Distributor not found");
                }
            }
            var isPasswordValid = PasswordHelper.VerifyPassword(user.PasswordHash, loginRequestDto.Password);
            if (!isPasswordValid)
            {
                throw new InvalidCredentialException("Username or password is incorrect");
            }

            _ = int.TryParse(_config("Token:TokenValidityInMinutes"), out int tokenValidityInMinutes);
            var token = TokenHelper.CreateToken(user, tokenValidityInMinutes);
            var refreshToken = GenerateRefreshToken(user);
            user.RefreshToken = refreshToken;
            user.RefreshTokenExpiryTime = DateTime.UtcNow.AddMinutes(tokenValidityInMinutes);
            await _dbContext.SaveChangesAsync();
            var returnedUser = new UserResponseDto()
            {
                ID = user.ID,
                UserName = user.UserName,
                Email = user.Email,
                RoleID = user.RoleID,
                RefreshToken = refreshToken
            };
            var result = new TokenResponseDto
            {
                Token = token.Token,
                User = returnedUser,
                RefreshToken = token.RefreshToken
                Expires = token.Token?.validTo
            };
        }

    }
}