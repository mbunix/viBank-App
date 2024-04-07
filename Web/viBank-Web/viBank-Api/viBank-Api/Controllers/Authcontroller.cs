using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using Google.Apis.Auth;
using viBank_Api.Models;
using Microsoft.EntityFrameworkCore;
using viBank_Api.Helpers;
using viBank_Api.DTO;
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
                    var newUser = new UserModel
                    {
                        UserName = email,
                        Email = email,
                        RoleID = 2
                    };

                    _dbContext.User.Add(newUser);
                    await _dbContext.SaveChangesAsync();
                    existingUser = newUser;
                }
                //generate the Jwt token
                var tokenvalidityinMinutes = Convert.ToInt32(_config["Token:TokenValidityInMinutes"]);
                var token = TokenHelper.CreateToken(existingUser, tokenvalidityinMinutes);
                var refreshToken = GenerateRefreshToken(existingUser);
                existingUser.RefreshToken = refreshToken;
                existingUser.RefreshTokenValidityInMinutes = DateTime.UtcNow.AddMinutes(tokenvalidityinMinutes).Ticks;
                await _dbContext.SaveChangesAsync();

                var returnedUser = new UserResponseDto
                {
                    ID = existingUser.Id,
                    UserName = existingUser.UserName,
                    Email = existingUser.Email,
                    RoleID = existingUser.RoleID,
                    RefreshToken = refreshToken
                };

                var result = new TokenResponseDto
                {
                    Token = token.Token,
                    User = returnedUser,
                    RefreshToken = token.RefreshToken,
                    Expires = token.Token?.ValidTo
                };
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }

        }
    }
}
