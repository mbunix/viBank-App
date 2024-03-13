using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using viBank_Api.DTO;
using viBank_Api.Helpers;
using viBank_Api.Models;

namespace viBank_Api.Services.UserService
{
    public class UserService : IUserService
    {
        private readonly AppDbContext _context;

        public UserService(AppDbContext dbContext)
        {
            _context = dbContext;
        }
        public async Task<UserModel> Create(CreateUserDto newUserDto)
        {
            var newUser = new UserModel
            {
                UserName = newUserDto.UserName,
                Email = newUserDto.Email,
                PasswordHash = PasswordHelper.HashPassword(newUserDto.Password),
                RoleID = newUserDto.RoleID,
                CreatedDTM = DateTime.UtcNow
            };
            var UserExists = await _context.User.AnyAsync(u => u.Email == newUserDto.Email);
            if (UserExists)
            {
                throw new InvalidOperationException($"User with email {newUserDto.Email} already exists");
            }
            await _context.User.AddAsync(newUser);
            await _context.SaveChangesAsync();
            return newUser;
        }
    }
}