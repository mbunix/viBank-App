using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using viBank_Api.DTO;
using viBank_Api.Helpers;
using viBank_Api.Models;
using viBank_Api.Services.AccountsService;

namespace viBank_Api.Services.UserService
{
    public class UserService : IUserService
    {
        private readonly AppDbContext _context;
        private readonly IAccounts _accountsService;

        public UserService(AppDbContext dbContext, IAccounts accountsService)
        {
            _context = dbContext;
            _accountsService = accountsService;
        }
        public async Task<UserModel> Create(CreateUserDto newUserDto)
        {
            // Check if user already exists
            var userExists = await _context.User.AnyAsync(u => u.Email == newUserDto.Email);
            if (userExists)
            {
                throw new InvalidOperationException($"User with email {newUserDto.Email} already exists");
            }

            var newUser = new UserModel
            {
                UserName = newUserDto.UserName,
                Email = newUserDto.Email,
                PasswordHash= PasswordHelper.HashPassword(newUserDto.Password),
                RoleID = newUserDto.RoleID,
                CreatedDTM = DateTime.UtcNow,
                UserID = newUserDto.UserID
            };
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
                UserID = newUser.UserID ,
                AccountNumber = addedAccount.AccountNumber,
                AccountType = (Models.AccountTypes)addedAccount.accountTypes,
                AccountBalance = addedAccount.balance
            };
            await _context.User.AddAsync(newUser);
            await _context.SaveChangesAsync();
            return newUser;
        }
    }
}
