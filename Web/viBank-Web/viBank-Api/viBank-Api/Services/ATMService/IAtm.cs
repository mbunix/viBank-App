using viBank_Api.Models;

namespace viBank_Api.Services.ATMService
{
    public interface IAtm
    {
        public Task<ATMs> CreateAtm(ATMs atm);

        public Task<ATMs> GetATMDetails(Guid atmid);
    }
}
