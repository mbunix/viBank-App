using viBank_Api.DTO;
using viBank_Api.Models;

namespace viBank_Api.Services.TransactionService
{
    public interface Itransactions
    {
        public Task<Transactions> Deposit(TransactionsDto transactions);

        public Task<Transactions> Withdraw(TransactionsDto transactions);

        public Task<Transactions> Transfer(TransactionsDto transactions);

    }
}
