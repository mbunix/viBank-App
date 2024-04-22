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
        public string? OriginAccountNumber { get; set; }
        public string? DestinationAccountNumber { get; set; }
        public Guid AccountID { get; set; } = new Account().AccountID;
        public DateTime TransactionDate { get; set; }
        public ATMs ATMs { get; set; }
    }
}
