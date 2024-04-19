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
        public string AccountNumber { get; set; } = string.Empty;

        public AccountTypes AccountType { get; set; }

        public double AccountBalance { get; set; }
        public long UserID { get; set; }
        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public DateTime CreatedDTM { get; set; }
        public DateTime UpdatedDTM { get; set; }
        public long CreatedBy{ get; set; }
        public long UpdatedBy { get; set; }

    }
}