using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.EntityFrameworkCore;
using viBank_Api.Models;

namespace viBank_Api.Services.ATMService
{
    public class ATMService : IAtm
    {
        private readonly AppDbContext _dbContext;
        public ATMService(AppDbContext dbcontext)
        {
            _dbContext = dbcontext;
            
        }
        public async Task<ATMs> CreateAtm(ATMs atm)
        {
            throw new NotImplementedException();
        }

        public async Task<ATMs> GetATMDetails(Guid atmid)
        {
            var atmDetails = await _dbContext.ATMs.FirstOrDefaultAsync(a=> a.ATMID  == atmid);
            if(atmDetails == null|| atmDetails.isActive == true)
            {
                throw new InvalidDataException("The ATM is not available");
            }
            return atmDetails;
        }
    }
}
