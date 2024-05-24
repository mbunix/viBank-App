using Microsoft.EntityFrameworkCore;
using viBank_Api.DTO;
using viBank_Api.Models;

namespace viBank_Api.Services.TransactionService
{
    public class TransactionService : Itransactions
    {
        private readonly AppDbContext _context;

        public TransactionService(AppDbContext context)
        {
            _context = context;
        }
      
        public async  Task<Transactions> Deposit(TransactionsDto transactions)
        {
            //find the account 
            var account = await _context.account.FindAsync(transactions.AccountID);
            if (account == null)
            {
                throw new InvalidOperationException("Account not found");
            }
            account.AccountBalance += transactions.Amount;
            var transaction = new Transactions
            {
                AccountID = account.ID,
                TransactionID = Guid.NewGuid(),
                Amount = transactions.Amount,
                transactionType = TransactionType.Deposit,
                TransactionDate = DateTime.UtcNow,
            };
            //persist to db
            await _context.Transactions.AddAsync(transaction);
            // Save changes to the database
            await _context.SaveChangesAsync();

            // Return the transaction
            return transaction;
        }

       public async Task<Transactions> Transfer(TransactionsDto transactions)
        {
            var originAccount = await _context.account.FirstOrDefaultAsync(u => u.AccountNumber == transactions.OriginAccountNumber);


            var destinationAccount = await _context.account.FirstOrDefaultAsync(u => u.AccountNumber == transactions.DestinationAccountNumber);

          


            if (originAccount == null|| destinationAccount == null)
            {
                throw new InvalidOperationException("Account is not Available");
            }
            //check available balance 
            if(originAccount.AccountBalance < transactions.Amount)
            {
                throw new InvalidOperationException("You have Insufficient Funds in You Account Please Deposit");
            }
            originAccount.AccountBalance -= transactions.Amount;
            destinationAccount.AccountBalance += transactions.Amount;
            //persist db

            var transaction = new Transactions
            {
                OriginAccountNumber = originAccount.AccountNumber,
                DestinationAccountNumber = destinationAccount.AccountNumber,
                TransactionID = Guid.NewGuid(),
                Amount = transactions.Amount,
                AccountID = originAccount.ID,
                transactionType = TransactionType.Transfers,
                TransactionDate = DateTime.UtcNow,
                ATMID = Guid.NewGuid(),
            };
            await _context.Transactions.AddAsync(transaction);
            await _context.SaveChangesAsync();

            return transaction;
        }

        public async Task<Transactions>  Withdraw(TransactionsDto transactions)
        {
            var account = await _context.account.FirstOrDefaultAsync(u => u.AccountNumber == transactions.OriginAccountNumber);
            if (account == null)
            {
                throw new InvalidOperationException("Account not found.");
            }
            var atm = await _context.ATMs.FirstOrDefaultAsync(u => u.ATMID == transactions.ATMID);


            if (atm == null|| !atm.isActive)
            {
                throw new InvalidOperationException("Atm is not active ");
            }
            if(account.AccountBalance < transactions.Amount)
            {

                throw new InvalidOperationException("You have Insufficient Funds in You Account Please Deposit");
            }
            account.AccountBalance -= transactions.Amount;
            atm.AvailbleBalance -= (decimal)transactions.Amount;

            var transaction = new Transactions
            {
                TransactionID = Guid.NewGuid(),
                transactionType = TransactionType.Withdrawal,
                Amount = transactions.Amount,
                AccountID = transactions.AccountID,
                TransactionDate = DateTime.UtcNow,

            };
            await _context.Transactions.AddAsync(transaction);
            await _context.SaveChangesAsync();

            // Return the transaction
            return transaction;
        }

        
    }
}
