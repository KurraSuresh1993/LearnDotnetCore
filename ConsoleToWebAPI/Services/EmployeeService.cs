using ConsoleToWebAPI.DTO;
using ConsoleToWebAPI.Interfaces.Repositories;
using ConsoleToWebAPI.Interfaces.Services;

namespace ConsoleToWebAPI.Services
{
    public class EmployeeService : IEmployeeService
    {
        private readonly IEmployeeRepository _employeeRepository;

        public EmployeeService(IEmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }
        public async Task AddEmployeeAsync(EmployeeDto employee)
        {
            await _employeeRepository.AddEmployeeAsync(employee);
        }

        public async Task<bool> DeleteEmployeeAsync(int id)
        {
            return await _employeeRepository.DeleteEmployeeAsync(id);
        }

        public async Task<IEnumerable<EmployeeDto>> GetAllEmployeesAsync()
        {
            return await _employeeRepository.GetAllEmployeesAsync();
        }

        public async Task<EmployeeDto> GetEmployeeByIdAsync(int id)
        {
            return await _employeeRepository.GetEmployeeByIdAsync(id);
        }

        public async Task<bool> UpdateEmployeeAsync(EmployeeDto employee)
        {
            return await _employeeRepository.UpdateEmployeeAsync(employee);
        }
    }
}
