using ConsoleToWebAPI.DTO;

namespace ConsoleToWebAPI.Interfaces.Services
{
    public interface IEmployeeService
    {
        Task<IEnumerable<EmployeeDto>> GetAllEmployeesAsync();

        Task<EmployeeDto> GetEmployeeByIdAsync(int id);

        Task AddEmployeeAsync(EmployeeDto employee);

        Task<bool> UpdateEmployeeAsync(EmployeeDto employee);

        Task<bool> DeleteEmployeeAsync(int id);
    }
}
