using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using viBank_Api.DTO;

using viBank_Api.Models;

namespace viBank_Api.Services.UserService
{
    public interface IUserService
    {
        Task<UserModel> Create(CreateUserDto user);
    }
}
