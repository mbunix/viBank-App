namespace viBank_Api.DTO
{
    public class AccountDetailsDto
    {
        public Guid AccountID { get; set; }
        public string userEmail { get; set; }
        public long AccountNumber { get; set; }
        public double balance { get; set; }
    }
}
