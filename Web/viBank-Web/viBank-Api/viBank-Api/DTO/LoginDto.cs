using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.IdentityModel.Tokens.Jwt;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Authentication;
using viBank_Api.Models;
namespace viBank_Api.DTO
{
    public class LoginRequestDto
    {
      
        public string UserName { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
        public bool RememberMe { get; set; }
        public string? ReturnUrl { get; set; }
        public IList<AuthenticationScheme> ExternalLogins { get; set; } = new List<AuthenticationScheme>();
    }
    public class ForgotPasswordDto
    {
        public string[] Email { get; set; } = Array.Empty<string>();
        public string? BaseUrl { get; set; }
    }
    public class ResetPasswordDto
    {
        public string Token { get; set; } = String.Empty;
        public string Email { get; set; } = String.Empty;
        public string? Password { get; set; } = String.Empty;
    }
    public class TokenModel
    {
        public string? AccessToken { get; set; }
        public string? RefreshToken { get; set; }
    }
    public class UserResponseDto
    {
        public long ID { get; set; }
        public string UserName { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string? Role { get; set; }
        public string PasswordHash { get; set; } = string.Empty;
        public DateTime CreatedDTM { get; set; }
        public Account? Account { get; set; }
        public Guid UserModelID { get; set; }
        public long? AccountNumber { get; set; }
        public string? RefreshToken { get; set; }
        public long RoleID { get; set; }
    }
    public class TokenObject
    {
        public string? UserToken { get; set; }
        public JwtSecurityToken? Token { get; set; }
    }
    public class TokenResponseDto
    {
        public string? Token { get; set; }
        public string? RefreshToken { get; set; }
        public UserResponseDto? User { get; set; }
        public DateTime? Expires { get; set; }
        public DateTime? RefreshTokenExpires { get; set; }
    }
}
