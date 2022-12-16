using Microsoft.AspNetCore.Mvc;
using MongoDbWebAPI.Models;
using MongoDbWebAPI.Services;

namespace MongoDbWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountsController : ControllerBase
    {
        private readonly AccountService _accountService;

        public AccountsController(AccountService accountService)
        {
            _accountService = accountService;
        }

        [HttpGet]
        public async Task<ActionResult<List<Account>>> Get()
        {
            return Ok(await _accountService.GetAsync());
        }

        [HttpGet("{id:length(24)}")]
        public async Task<ActionResult<Account>> Get(string id)
        {
            var account = await _accountService.GetAsync(id);

            if (account is null)
            {
                return NotFound();
            }

            return Ok(account);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Account newAccount)
        {
            await _accountService.CreateAsync(newAccount);

            return CreatedAtAction(nameof(Get), new { id = newAccount.Id }, newAccount);
        }

        [HttpPut("{id:length(24)}")]
        public async Task<IActionResult> Put(string id, [FromBody] Account updatedAccount)
        {
            var account = await _accountService.GetAsync(id);

            if (account is null)
            {
                return NotFound();
            }

            updatedAccount.Id = account.Id;

            await _accountService.UpdateAsync(id, updatedAccount);

            return NoContent();
        }

        [HttpDelete("{id:length(24)}")]
        public async Task<IActionResult> Delete(string id)
        {
            var account = await _accountService.GetAsync(id);

            if (account is null)
            {
                return BadRequest();
            }

            await _accountService.RemoveAsync(id);

            return NoContent();
        }
    }
}