using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using Google.Apis.Auth;
namespace viBank_Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class Authcontroller : ControllerBase
    {

        private readonly AppDbContext _dbContext;
        public Authcontroller(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        [HttpGet("google")]
        public IActionResult GoogleSignIn()
        {
            var authentictionProperties = new AuthenticationProperties
            {
                RedirectUri = Url.Action(nameof(HandleGoogleResponse))
            };
            return Challenge(authentictionProperties, GoogleDefaults.AuthenticationScheme);
        }

        [HttpGet("google-response")]
        public async Task<IActionResult> HandleGoogleResponse(string idToken)
        {
            try
            {

                var payload = await GoogleJsonWebSignature.ValidateAsync(idToken);
                var email = payload.Email;

                // check if the user is in the databasse 
                var existingUser = await _dbContext.User.FirstOrDefaultAsync(u => u.Email == email);
                if (existingUser == null)
                {
                    // user does not exist so create  one


                }

            }

        }
    }
}
