﻿using ConsoleToWebAPI.DTO;
using ConsoleToWebAPI.Models;
using System.Threading.Tasks;

namespace ConsoleToWebAPI.Interfaces.Repositories
{
    public interface IEmployeeRepository
    {
        Task<IEnumerable<EmployeeDto>> GetAllEmployeesAsync();

        Task<EmployeeDto> GetEmployeeByIdAsync(int id);

        Task AddEmployeeAsync(EmployeeDto employee);

        Task<bool> UpdateEmployeeAsync(EmployeeDto employee);

        Task<bool> DeleteEmployeeAsync(int id);
    }
}
