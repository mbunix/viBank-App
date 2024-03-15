using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace viBank_Api.DTO
{
    public class CreateUserDto
    {
        public string UserName { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
        public long RoleID { get; set; }
    }
}