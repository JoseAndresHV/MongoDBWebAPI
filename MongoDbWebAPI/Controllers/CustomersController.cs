using Microsoft.AspNetCore.Mvc;
using MongoDbWebAPI.Models;
using MongoDbWebAPI.Services;

namespace MongoDbWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomersController : ControllerBase
    {
        private readonly CustomerService _customerService;
        private readonly AccountService _accountService;

        public CustomersController(CustomerService customerService, AccountService accountService)
        {
            _customerService = customerService;
            _accountService = accountService;
        }

        [HttpGet]
        public async Task<ActionResult<List<Customer>>> Get()
        {
            return Ok(await _customerService.GetAsync());
        }

        [HttpGet("{id:length(24)}")]
        public async Task<ActionResult<Customer>> Get(string id)
        {
            var customer = await _customerService.GetAsync(id);

            if (customer is null)
            {
                return NotFound();
            }

            return Ok(customer);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Customer newCustomer)
        {
            foreach (int accountId in newCustomer.Accounts.ToList())
            {
                var existAccount = await _accountService.GetByAccountIdAsync(accountId);

                if (existAccount is null)
                {
                    return BadRequest(new
                    {
                        Message = $"The account: {accountId} does not exists.",
                        Status = 400,
                    });
                }
            }

            await _customerService.CreateAsync(newCustomer);

            return CreatedAtAction(nameof(Get), new { id = newCustomer.Id }, newCustomer);
        }

        [HttpPut("{id:length(24)}")]
        public async Task<IActionResult> Put(string id, [FromBody] Customer updatedCustomer)
        {
            var customer = await _customerService.GetAsync(id);

            if (customer is null)
            {
                return NotFound();
            }

            foreach (int accountId in updatedCustomer.Accounts.ToList())
            {
                var existAccount = await _accountService.GetByAccountIdAsync(accountId);

                if (existAccount is null)
                {
                    return NotFound(new
                    {
                        Message = $"The account: {accountId} does not exists.",
                        Status = 404
                    });
                }
            }

            updatedCustomer.Id = customer.Id;

            await _customerService.UpdateAsync(id, updatedCustomer);

            return NoContent();
        }

        [HttpDelete("{id:length(24)}")]
        public async Task<IActionResult> Delete(string id)
        {
            var customer = await _customerService.GetAsync(id);

            if (customer is null)
            {
                return BadRequest();
            }

            await _customerService.RemoveAsync(id);

            return NoContent();
        }
    }
}