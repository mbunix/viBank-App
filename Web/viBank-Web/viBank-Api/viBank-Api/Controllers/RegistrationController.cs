using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using viBank_Api.DTO;
using viBank_Api.Services.UserService;

namespace viBank_Api.Controllers
{
    [Route("api/[controller]")]
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
        public async Task<ActionResult<CreateUserDto>> CreateUser( [FromBody] CreateUserDto createUser)
        {
            try
            {
                await _userService.Create(createUser);
                return Created("api/users", createUser);

            }catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
