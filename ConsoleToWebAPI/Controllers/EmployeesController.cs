using ConsoleToWebAPI.Interfaces.Services;
using ConsoleToWebAPI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ConsoleToWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeesController : ControllerBase
    {
        private readonly IEmployeeService _employeeService;

        public EmployeesController(IEmployeeService employeeService)
        {
            _employeeService = employeeService;
        }

        [HttpGet]
        public async Task<ActionResult<List<Employee>>> GetAsync()
        {
            var employees=await _employeeService.GetAllEmployeesAsync();
            if(employees is null)
            {
                return NotFound();
            }
            return Ok(employees);
        }

        
    }
}
