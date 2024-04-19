using viBank_Api.DTO;

namespace viBank_Api.Services.AccountsService
{
    public interface IAccounts
    {
        public  Task<CreateAccountDto> AddAccount(CreateAccountDto account);
        public Task<CreateAccountDto> SelectAccount(CreateAccountDto account);

        public Task<CreateAccountDto> DeleteAccount(CreateAccountDto account);
    }
}
