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
            new("username", user.UserName),
            new("email", user.Email),
            new("userId", user.UserModelID.ToString()),
            new("roleId", user.RoleID.ToString() ?? "")
        };

            var secret = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes(_configuration["Token"]!));
            var credentials = new SigningCredentials(secret, SecurityAlgorithms.HmacSha256Signature);

            var token = new JwtSecurityToken(
                claims: claims,
                expires: DateTime.UtcNow.AddMinutes(tokenValidityInMinutes),
                signingCredentials: credentials
            );

            var returnObj = new TokenObject()
            {
                Token = token,
                UserToken = new JwtSecurityTokenHandler().WriteToken(token)
            };
            return returnObj;
        }


    }
}
