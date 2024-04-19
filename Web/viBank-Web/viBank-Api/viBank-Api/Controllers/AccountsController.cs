using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using viBank_Api.DTO;
using viBank_Api.Services.AccountsService;

namespace viBank_Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountsController : ControllerBase
    {
        private readonly IAccounts _accountsService;

        public AccountsController(IAccounts accountsService)
        {
            _accountsService = accountsService;
        }
        /// <summary>
        /// Creates a new account.
        /// </summary>
        /// <param name="accountDto">The account data transfer object containing the account information.</param>
        /// <returns>The created account information.</returns>
        [HttpPost]
        [Route("accounts/create")]
        public async Task<IActionResult> CreateAccount([FromBody] CreateAccountDto accountDto)
        {
            if (accountDto == null)
            {
                return BadRequest("Account information is required.");
            }

            try
            {
                var createdAccount = await _accountsService.AddAccount(accountDto);

                if (createdAccount != null)
                {
                    return CreatedAtAction(nameof(CreateAccount), createdAccount);
                }

                return BadRequest("Failed to create account.");
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "An error occurred while creating the account.");
            }
        }

        // Future implementations for selecting and deleting accounts...
    }
}

