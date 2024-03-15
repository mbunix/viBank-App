using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.IdentityModel.Tokens.Jwt;
using System.ComponentModel.DataAnnotations;
namespace viBank_Api.DTO
{
    public class LoginRequestDto
    {
        [Required(ErrorMessage = "UserName is required"), EmailAddress(ErrorMessage = "Invalid Email Address")]
        public string UserName { get; set; } = string.Empty;
        [Required(ErrorMessage = "Password is required")]
        public string Password { get; set; } = string.Empty;
    }
    public class ForgotPasswordDto
    {
        [Required(ErrorMessage = "Email is required")]
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
        public Guid UserID { get; set; }
        public string UserName { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string? Role { get; set; }

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