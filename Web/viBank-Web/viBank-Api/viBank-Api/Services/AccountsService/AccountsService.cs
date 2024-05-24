using Microsoft.EntityFrameworkCore;
using viBank_Api.DTO;
using viBank_Api.Helpers;
using viBank_Api.Models;

namespace viBank_Api.Services.AccountsService
{
    public class AccountsService : IAccounts
    {
        private readonly AppDbContext _context;
        public AccountsService(AppDbContext dbContext) {
            _context = dbContext;
        }
        public async Task<CreateAccountDto> AddAccount(CreateAccountDto account)
        {
            var newAccount = new Account
            {
                AccountID = account.AccountID,
                AccountType = (Models.AccountTypes)account.accountTypes,
                UserEmail = account.userEmail,
                AccountNumber = account.AccountNumber,
                AccountBalance = account.balance,
                CreatedDTM = DateTime.UtcNow,
                UpdatedDTM = new DateTime()
            };
            await _context.account.AddAsync(newAccount);
            await _context.SaveChangesAsync();
            account.AccountID = newAccount.AccountID;
            account.balance = newAccount.AccountBalance;
            account.userEmail = account.userEmail;
            account.CreatedAtDTM = DateTime.UtcNow;
            account.UpdatedAtDTM = new DateTime();
            return account;

        }
        public async Task<Account> GetAccountDetails(Guid accountId)
        {
            //get the user and account
            var userAccount = await _context.account.FirstOrDefaultAsync( a => a.AccountID == accountId);

            if (userAccount == null)
            {
                if (userAccount == null)
                {
                    throw new InvalidDataException("User with such account not found");
                }
            }
           
            return userAccount;
        }
        public async  Task<CreateAccountDto> DeleteAccount(CreateAccountDto account)
        {
            throw new NotImplementedException();
        }

        public async  Task<CreateAccountDto> SelectAccount(CreateAccountDto account)
        {
            throw new NotImplementedException();
        }
    }
}
