using viBank_Api.Models;

namespace viBank_Api.DTO
{
    public class TransactionsDto
    {
        public TransactionType TransactionType { get; set; }
        public Guid TransactionID { get; set; }
        public double  Amount { get; set; }
        public long  OriginAccountNumber { get; set; }
        public long? DestinationAccountNumber { get; set; }
        public Guid ATMID = new ATMs().ATMID;
        public long AccountID { get; set; }
        public DateTime TransactionDate { get; set; } = DateTime.UtcNow;
    }
}
