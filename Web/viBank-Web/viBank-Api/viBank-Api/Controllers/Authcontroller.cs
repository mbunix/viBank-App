using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using Google.Apis.Auth;
using viBank_Api.Models;
using Microsoft.EntityFrameworkCore;
using viBank_Api.Helpers;
using viBank_Api.DTO;
using viBank_Api.Services.authService;
namespace viBank_Api.Controllers
{
    [ApiController]
    [Route("api/auth")]
    public class Authcontroller : ControllerBase
    {

        private readonly IAuthService _authService;
        public Authcontroller(IAuthService authService)
        {
            _authService = authService;
        }
        [HttpGet("google")]
        public IActionResult GoogleSignIn()
        {
            var authentictionProperties = new AuthenticationProperties
            {
                RedirectUri = Url.Action("SignInWithGoogleCallBack")
            };
            return Challenge(authentictionProperties,"Google");
        }

        [HttpGet("signin-google-callback")]
        public async Task<IActionResult> SignInWithGoogleCallback()
        {
            var result = await HttpContext.AuthenticateAsync();
            if (result?.Principal != null)
            {
                var idToken = result.Properties.GetTokenValue("id_token");

                // Call your method in the AuthService to handle the Google sign-in process
                var tokenResponse = await _authService.SignInWithGoogle(idToken, null, null);

                if (tokenResponse != null)
                {
                    return Ok(tokenResponse);
                }
            }

            return Unauthorized("Failed to authenticate with Google.");
        }
        [HttpGet("signin-microsoft-callback")]
        public async Task<IActionResult> SignInWithMicrosoftCallback()
        {
            var result = await HttpContext.AuthenticateAsync();
            if (result?.Principal != null)
            {
                var idToken = result.Properties.GetTokenValue("id_token");

                // Call the AuthService to handle the Microsoft sign-in process
                var tokenResponse = await _authService.SignInWithMicrosoft(idToken, null, null);

                if (tokenResponse != null)
                {
                    return Ok(tokenResponse);
                }
            }

            return Unauthorized("Failed to authenticate with Microsoft.");
        }
        [HttpPost]
        [Route("Login")]
        public async Task<ActionResult<TokenResponseDto>> Login(LoginRequestDto loginRequest)
        {
            // Validate the login request
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                // Perform login using the auth service
                var tokenResponse = await _authService.Login(loginRequest);

                // Check if the login was successful and return the result
                if (tokenResponse != null)
                {
                    return Ok(tokenResponse);
                }
                else
                {
                    return Unauthorized("Invalid credentials");
                }
            }
            catch (Exception ex)
            {
                // Log the error (you can use a logging framework here)
                Console.Error.WriteLine(ex);

                // Return a generic error response
                return StatusCode(500, "Internal server error");
            }
        }
        [HttpPost]
        [Route("SignOut")]
        public async Task<IActionResult> SignOut()
        {
            // Sign the user out from the authentication scheme
            await HttpContext.SignOutAsync();

            // Return a successful response
            return Ok("You have successfully signed out.");
        }
    }


}

