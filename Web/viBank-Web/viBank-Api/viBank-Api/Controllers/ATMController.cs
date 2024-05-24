using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using viBank_Api.Models;
using viBank_Api.Services.ATMService;

namespace viBank_Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ATMController : ControllerBase
    {
        private readonly IAtm _atmService;
        public ATMController( IAtm atm)
        {
            _atmService = atm;
            
        }
        [HttpPost]
        [Route("atms/create")]
        public async Task<IActionResult> CreateAtm([FromBody]ATMs atm)
        {
            if (atm == null)
            {
                return BadRequest("Atm information is required.");
            }
            try
            {
                var createAtm = await _atmService.CreateAtm(atm);
                if (createAtm != null){
                    return Ok(createAtm);
                }
                return BadRequest("Failed to create account.");
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "An error occurred while creating the account.");
            }
        }
        //get the atm details :
        [HttpGet]
        [Route("atm/id")]
        public  async Task<ActionResult<ATMs>> GetAtmDetails(Guid atmId)
        {
            var atmData = await _atmService.GetATMDetails(atmId);
            if(atmData != null)
            {
                return Ok(atmData);
            }
            return NotFound();
        }
         


    }
}
