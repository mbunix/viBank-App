using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using viBank_Api.DTO;
using viBank_Api.Services.TransactionService;

namespace viBank_Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TransactionsController : ControllerBase
    {
        private readonly Itransactions _transactionService;

        public TransactionsController(Itransactions transactionService)
        {
            _transactionService = transactionService;
        }

        /// <summary>
        /// Handles deposit transactions.
        /// </summary>
        /// <param name="transactionDto">Transaction data transfer object containing transaction details.</param>
        /// <returns>Returns the processed transaction.</returns>
        [HttpPost]
        [Route("accounts/deposit")]
        public async Task<IActionResult> Deposit([FromBody] TransactionsDto transactionDto)
        {
            try
            {
                var transaction = await _transactionService.Deposit(transactionDto);
                return Ok(transaction);
            }
            catch (InvalidOperationException ex)
            {
                return BadRequest(ex.Message);
            }
        }

        /// <summary>
        /// Handles transfer transactions.
        /// </summary>
        /// <param name="transactionDto">Transaction data transfer object containing transaction details.</param>
        /// <returns>Returns the processed transaction.</returns>
        [HttpPost]
        [Route("accounts/transfer")]
        public async Task<IActionResult> Transfer([FromBody] TransactionsDto transactionDto)
        {
            try
            {
                var transaction = await _transactionService.Transfer(transactionDto);
                return Ok(transaction);
            }
            catch (InvalidOperationException ex)
            {
                return BadRequest(ex.Message);
            }
        }

        /// <summary>
        /// Handles withdrawal transactions.
        /// </summary>
        /// <param name="transactionDto">Transaction data transfer object containing transaction details.</param>
        /// <returns>Returns the processed transaction.</returns>
        [HttpPost]
        [Route("accounts/withdraw")]
        public async Task<IActionResult> Withdraw([FromBody] TransactionsDto transactionDto)
        {
            try
            {
                var transaction = await _transactionService.Withdraw(transactionDto);
                return Ok(transaction);
            }
            catch (InvalidOperationException ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}

