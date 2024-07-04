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
    }
}
