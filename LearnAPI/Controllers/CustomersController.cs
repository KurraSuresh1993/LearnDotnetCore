using LearnAPI.Models;
using LearnAPI.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.RateLimiting;

namespace LearnAPI.Controllers
{
  //  [Authorize]
    [EnableRateLimiting("fixedwindow")]
    //[DisableCors]
    [ApiController]
    [Route("api/[controller]")]
    public class CustomersController : ControllerBase
    {
        private readonly ICustomerService _customerService;

        public CustomersController(ICustomerService customerService)
        {
            _customerService = customerService;
        }

       // [EnableCors("corspolicy")]
        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAllAsync()
        {
            var customers = await _customerService.GetAllAsync();
            if (customers is null)
            {
                return NotFound();
            }
            return Ok(customers);
        }

        [DisableRateLimiting]
        [HttpGet("GetById")]
        public async Task<IActionResult> GetByIdAsync([FromQuery] int id)
        {
            var customer = await _customerService.GetByIdAsync(id);
            if (customer is null)
            {
                return NotFound();
            }
            return Ok(customer);
        }

        [HttpPost("Create")]
        public async Task<IActionResult> CreateAsync([FromBody] CustomerModel customer)
        {
            var result = await _customerService.CreateAsync(customer);
            return Ok(result);
        }

        [HttpPut("Update")]
        public async Task<IActionResult> UpdateAsync([FromBody] CustomerModel customer,[FromQuery] int id)
        {
            var result = await _customerService.UpdateAsync(customer,id);
            return Ok(result);
        }

        [HttpDelete("Delete")]
        public async Task<IActionResult> RemoveAsync([FromQuery] int id)
        {
            var result = await _customerService.RemoveAsync(id);
            return Ok(result);
        }
    }
}
