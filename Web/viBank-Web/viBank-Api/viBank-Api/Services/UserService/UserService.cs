using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using System.IdentityModel.Tokens.Jwt;
using viBank_Api.DTO;
using viBank_Api.Helpers;
using viBank_Api.Models;
using viBank_Api.Services.AccountsService;
using System.Security.Cryptography;
using Microsoft.EntityFrameworkCore;
using System.Security.Authentication;

namespace viBank_Api.Services.UserService
{
    public class UserService : IUserService
    {
        private readonly AppDbContext _context;
        private readonly IAccounts _accountsService;
        private readonly UserManager<IdentityUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly TokenHelper _tokenHelper;
        private readonly IConfiguration _config;
        public UserService(AppDbContext dbContext, IAccounts accountsService, IConfiguration config, UserManager<IdentityUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            _context = dbContext;
            _config = config;
            _userManager = userManager;
            _roleManager = roleManager;
            _accountsService = accountsService;
            _tokenHelper = new TokenHelper(_config);
        }
        public async Task<TokenResponseDto> Create(CreateUserDto newUserDto ,string role)
        {
            // Check if user already exists
            var userExists = await _userManager.FindByEmailAsync(newUserDto.Email);
            if (userExists != null)
            {
                throw new InvalidOperationException($"User with email {newUserDto.Email} already exists");
            }
           
            // Create IdentityUser
            var identityUser = new IdentityUser
            {
                Email = newUserDto.Email,
                UserName = newUserDto.UserName,
            };
            var result = await _userManager.CreateAsync(identityUser, newUserDto.Password);
            if (!result.Succeeded)
            {
                throw new InvalidOperationException($"Failed to create user: {result.Errors.FirstOrDefault()?.Description}");
            }
            else
            {
                // Assign the user role by default
                var UserRole = "User"; // Assuming "user" is the role name
                if (!await _roleManager.RoleExistsAsync(UserRole))
                {
                    throw new InvalidOperationException($"Role {UserRole} does not exist");
                }
                await _userManager.AddToRoleAsync(identityUser, UserRole);
            }
        
            var newUser = new UserModel()
            {
                UserName = newUserDto.UserName,
                Email = newUserDto.Email,
                PasswordHash = PasswordHelper.HashPassword(newUserDto.Password),
                CreatedDTM = DateTime.UtcNow,
                UserModelID = Guid.Parse(identityUser.Id)
            };
            var addedUser = await _context.User.AddAsync(newUser);

            // Create a default account for the user
            var defaultAccount = new CreateAccountDto
            {
                accountTypes = AccountTypes.Current,
                AccountNumber = new Random().Next(),
                AccountID = Guid.NewGuid(),
                userEmail = newUser.Email,
                balance = 0,
                CreatedAtDTM = DateTime.UtcNow,
                UpdatedAtDTM = new DateTime()
            };

            var addedAccount = await _accountsService.AddAccount(defaultAccount);
            newUser.Account = new Account
            {
                AccountID = addedAccount.AccountID,
                UserModelID = Guid.Parse(identityUser.Id),
                AccountNumber = addedAccount.AccountNumber,
                AccountType = (Models.AccountTypes)addedAccount.accountTypes,
                AccountBalance = addedAccount.balance,
                UserEmail = newUser.Email
            };

            // Save UserModel and corresponding account in a single transaction
            await using var transaction = await _context.Database.BeginTransactionAsync();
            try
            {
                await _context.SaveChangesAsync();
                await transaction.CommitAsync();
            }
            catch (Exception)
            {
                await transaction.RollbackAsync();
                throw; 
            }
            var user = await _context.User
                        
                        .FirstOrDefaultAsync(x=>x.UserModelID == newUser.UserModelID);
           if (user == null) {
                throw new InvalidDataException("User not found");
            }
            _ = int.TryParse(_config["TokenValidityInMinutes"], out int tokenValidityInMinutes);
            var token = _tokenHelper.CreateToken(user, tokenValidityInMinutes);
            var refreshToken = GenerateRefreshToken(user);
            var accessToken = token.UserToken;
            user.RefreshToken = refreshToken;
            _ = int.TryParse(_config["RefreshTokenValidityInMinutes"], out int RefreshTokenValidityInMinutes);
            user.RefreshTokenExpiryTime = DateTime.UtcNow.AddMinutes(RefreshTokenValidityInMinutes);
            var returnedUser = new UserResponseDto()
            {
                ID = user.ID,
                UserName = newUser.UserName,
                Account = newUser.Account,
                Email = newUser.Email,
                RoleID = user.RoleID,
                AccountNumber = user.Account?.AccountNumber, 
                RefreshToken = refreshToken
            };
            var returned = new TokenResponseDto
            {
                Token = accessToken,
                User = returnedUser,
                RefreshToken = refreshToken,
                Expires = token.Token?.ValidTo
            };

            return returned;

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
    }

}
