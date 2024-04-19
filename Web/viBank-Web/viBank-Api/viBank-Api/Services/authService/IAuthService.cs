using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using viBank_Api.DTO;

namespace viBank_Api.Services.authService
{
    public interface IAuthService
    {
        public Task<TokenResponseDto> Login(LoginRequestDto loginRequestDto);
        public Task<TokenResponseDto> RefreshToken(TokenModel tokenModel);
        public Task<TokenResponseDto> ForgotPassword(ForgotPasswordDto payload);
        public Task<bool> ResetPassword(ResetPasswordDto payload);
        public Task<TokenResponseDto>SignInWithMicrosoft(string idToken,string returnUrl , string remoteError);
        public Task<bool> ValidateResetToken(ResetPasswordDto payload);
        public Task<TokenResponseDto> SignInWithGoogle(string idToken,string returnUrl, string remoteError );
    }
}