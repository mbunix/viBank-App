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
            { }
    }
}
