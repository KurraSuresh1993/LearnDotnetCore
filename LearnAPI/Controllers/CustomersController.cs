using LearnAPI.Services;
using Microsoft.AspNetCore.Mvc;

namespace LearnAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CustomersController:ControllerBase
    {
        private readonly ICustomerService _customerService;

        public CustomersController(ICustomerService customerService)
        {
            _customerService = customerService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllAsync()
        {
            var customers=await _customerService.GetAllAsync();
            if(customers == null)
            {
                return NotFound();
            }
            return Ok(customers);
        }
    }
}
