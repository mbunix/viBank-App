using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using viBank_Api.DTO;
using viBank_Api.Models;

namespace viBank_Api.Helpers
{
    [NonController]
    public class TokenHelper
    {
        private readonly IConfiguration _configuration;
        public TokenHelper(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public TokenObject CreateToken(UserModel user, int tokenValidityInMinutes)
        {
            var claims = new List<Claim>
            {
                new(ClaimTypes.Name, user.UserName),
                new(ClaimTypes.Email, user.Email),
                new(ClaimTypes.NameIdentifier, user.ID.ToString()),
                new(ClaimTypes.Role, user.RoleID.ToString())
            };
            var secret = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes(_configuration["Token"]!));
            var credentials = new SigningCredentials(secret, SecurityAlgorithms.HmacSha512Signature);
            var token = new JwtSecurityToken(
                claims: claims,
                expires: DateTime.Now.AddMinutes(tokenValidityInMinutes),
                signingCredentials: credentials
            );
            var returnObject = new TokenObject()
            {
                Token = token,
                UserToken = new JwtSecurityTokenHandler().WriteToken(token)
            };
            return returnObject;
        }
    }
}