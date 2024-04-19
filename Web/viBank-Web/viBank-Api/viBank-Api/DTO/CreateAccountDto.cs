using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.SqlServer.Dac.Model;
using viBank_Api.Models;

namespace viBank_Api.DTO
{
    public class CreateAccountDto
    {
        public AccountTypes accountTypes { get; set; } 
        public Guid AccountID { get; set; } = new Account().AccountID;
        public string userEmail { get; set; } = new UserModel().Email;
        public double balance { get; set; }
    }
}
