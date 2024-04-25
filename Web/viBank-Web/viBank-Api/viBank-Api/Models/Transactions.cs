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
        public Guid ATMID { get; set; }
        public TransactionType transactionType { get; set; }
        public double Amount { get; set; }
        public long? OriginAccountNumber { get; set; }
        public long? DestinationAccountNumber { get; set; }
        public long AccountID { get; set; } = new Account().ID;
        public DateTime TransactionDate { get; set; }
        public ATMs ATMs { get; set; }
    }
}
