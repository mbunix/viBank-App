using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace viBank_Api.DTO
{
    public class CreateAccountDto
    {
        public AccountTypes accountTypes { get; set; }
        public double balance { get; set; }
    }
}