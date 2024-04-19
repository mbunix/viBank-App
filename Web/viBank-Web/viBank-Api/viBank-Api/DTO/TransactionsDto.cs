using viBank_Api.Models;

namespace viBank_Api.DTO
{
    public class TransactionsDto
    {
        public TransactionType TransactionType { get; set; }
        public double  Amount { get; set; }
        public string?  OriginAccountNumber { get; set; }
        public string? DestinationAccountNumber { get; set; }
        public Guid ATMID = new ATMs().ATMID;
        public Guid AccountID { get; set; }
        public DateTime TransactionDate { get; set; } = DateTime.UtcNow;
    }
}
