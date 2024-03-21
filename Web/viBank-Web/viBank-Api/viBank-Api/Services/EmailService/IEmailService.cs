using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using viBank_Api.DTO;

namespace viBank_Api.Services.EmailService
{
    public interface IEmailService
    {
        public void SendEmail(EmailDto emailDto);
    }
}