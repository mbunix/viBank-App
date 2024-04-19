using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace viBank_Api.Models
{
    public class Transactions
    {
        public long ID { get; set; }
        public Guid TransactionID { get; set; }
        public string TransactionType { get; set; } = string.Empty;
        public double Amount { get; set; }
        public Guid OriginAccountID { get; set; }
        public Guid DestinationAccountID { get; set; }
        public Guid AccountID { get; set; }
        public DateTime TransactionDate { get; set; }
    }
}