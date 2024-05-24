using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using viBank_Api.DTO;
using viBank_Api.Services.UserService;

namespace viBank_Api.Controllers
{
    [Route("api/auth/register")]
    [ApiController]
    public class RegistrationController : ControllerBase
    {
        private readonly IUserService _userService;

        public RegistrationController( IUserService userService)
        {
            _userService = userService;
        }
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public async Task<ActionResult> CreateUser( [FromBody] CreateUserDto createUser)
        {
            try
            {
              var result =  await _userService.Create(createUser,string.Empty);
                return Ok(result);

            }catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
