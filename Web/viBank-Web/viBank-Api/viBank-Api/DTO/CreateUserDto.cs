using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using viBank_Api.Models;

namespace viBank_Api.DTO
{
    public class CreateUserDto
    {
        public string UserName { get; set; }
        public string Email { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
        public string UserID { get; set; } = Guid.NewGuid().ToString();
        protected Account account { get; set; }
        public  DateTime createdDTM {  get; set; }
        public DateTime updatedDTM {  get; set; }
        public long RoleID { get; set; }
    }
}
