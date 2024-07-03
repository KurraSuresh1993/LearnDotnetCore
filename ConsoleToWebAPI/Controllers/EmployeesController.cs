using ConsoleToWebAPI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ConsoleToWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeesController : ControllerBase
    {
        List<Employee> employees;
        public EmployeesController()
        {
            employees = new List<Employee>()
                 {
            new Employee { Id = 1, Name = "John Doe", Description = "Software Engineer", Email = "john.doe@example.com", Salary = 80000 },
            new Employee { Id = 2, Name = "Jane Smith", Description = "Data Analyst", Email = "jane.smith@example.com", Salary = 70000 },
            new Employee { Id = 3, Name = "Michael Johnson", Description = "Project Manager", Email = "michael.johnson@example.com", Salary = 90000 },
            new Employee { Id = 4, Name = "Emily Brown", Description = "UX Designer", Email = "emily.brown@example.com", Salary = 75000 },
            new Employee { Id = 5, Name = "David Lee", Description = "Marketing Specialist", Email = "david.lee@example.com", Salary = 60000 }
                 };
        }

        public ActionResult<List<Employee>> Get()
        {
            return Ok(employees.ToList());
        }
    }
}
