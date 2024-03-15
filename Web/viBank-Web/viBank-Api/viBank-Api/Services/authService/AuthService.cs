using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace viBank_Api.Services.authService
{
    public class AuthService : IAuthService
    {
        private readonly AppDbContext _dbContext;
        private readonly IConfiguration _config;
        private readonly IEmailService _emailService;

        public IAuthService(AppDbContext dbContext, IConfiguration config, IEmailService emailService)
        {
            _config = config;
            _dbContext = dbContext;
            _emailService = emailService;

        }

    }
}