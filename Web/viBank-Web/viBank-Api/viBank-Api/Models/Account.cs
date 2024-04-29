using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace viBank_Api.Models
{
    public class Account
    {
        public long ID { get; set; }

        public Guid AccountID { get; set; }
        public long? AccountNumber { get; set; }

        public AccountTypes AccountType { get; set; }

        public double AccountBalance { get; set; }
        public Guid UserID { get; set; }
        public string UserEmail { get; set; } = new UserModel().Email;
        public DateTime CreatedDTM { get; set; }
        public DateTime UpdatedDTM { get; set; }

    }
}
