using Microsoft.AspNetCore.Mvc;
using MongoDbWebAPI.Models;
using MongoDbWebAPI.Services;

namespace MongoDbWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TransactionsController : ControllerBase
    {

        private readonly TransactionService _transactionService;
        private readonly AccountService _accountService;

        public TransactionsController(TransactionService transactionService, AccountService accountService)
        {
            _transactionService = transactionService;
            _accountService = accountService;
        }

        [HttpGet]
        public async Task<ActionResult<List<Transaction>>> Get(int pageSize, int pageNumber)
        {
            return Ok(await _transactionService.GetTransactionPagination(pageSize, pageNumber));
        }

        [HttpGet("{id:length(24)}")]
        public async Task<ActionResult<Transaction>> Get(string id)
        {
            var customer = await _transactionService.GetAsync(id);

            if (customer is null)
            {
                return NotFound();
            }

            return Ok(customer);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Transaction newTransaction)
        {
            var existAccount = await _accountService.GetByAccountIdAsync(newTransaction.AccountId);

            if (existAccount is null)
            {
                return BadRequest(new
                {
                    Message = $"The account: {newTransaction.AccountId} does not exists.",
                    Status = 400,
                });
            }

            await _transactionService.CreateAsync(newTransaction);

            return CreatedAtAction(nameof(Get), new { id = newTransaction.Id }, newTransaction);
        }

        [HttpPut("{id:length(24)}")]
        public async Task<IActionResult> Put(string id, [FromBody] Transaction updatedTransaction)
        {
            var transaction = await _transactionService.GetAsync(id);

            if (transaction is null)
            {
                return NotFound();
            }

            var existAccount = await _accountService.GetByAccountIdAsync(updatedTransaction.AccountId);

            if (existAccount is null)
            {
                return NotFound(new
                {
                    Message = $"The account: {updatedTransaction.AccountId} does not exists.",
                    Status = 404
                });
            }

            updatedTransaction.Id = transaction.Id;

            await _transactionService.UpdateAsync(id, updatedTransaction);

            return NoContent();
        }

        [HttpDelete("{id:length(24)}")]
        public async Task<IActionResult> Delete(string id)
        {
            var transaction = await _transactionService.GetAsync(id);

            if (transaction is null)
            {
                return BadRequest();
            }

            await _transactionService.RemoveAsync(id);

            return NoContent();
        }
    }
}
