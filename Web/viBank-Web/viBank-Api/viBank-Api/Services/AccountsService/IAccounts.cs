using viBank_Api.DTO;
using viBank_Api.Models;

namespace viBank_Api.Services.AccountsService
{
    public interface IAccounts
    {
        public  Task<CreateAccountDto> AddAccount(CreateAccountDto account);
        public Task<Account> GetAccountDetails(Guid accountId);
        public Task<CreateAccountDto> SelectAccount(CreateAccountDto account);

        public Task<CreateAccountDto> DeleteAccount(CreateAccountDto account);
    }
}
