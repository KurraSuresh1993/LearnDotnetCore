using AutoMapper;
using ConsoleToWebAPI.DTO;
using ConsoleToWebAPI.Interfaces.Repositories;
using ConsoleToWebAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace ConsoleToWebAPI.Repositories
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly EmployeeDBContext _context;
        private readonly IMapper _mapper;

        public EmployeeRepository(EmployeeDBContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task AddEmployeeAsync(EmployeeDto employee)
        {
            var employeer = _mapper.Map<EmployeeDto, Employee>(employee);
            await _context.Employees.AddAsync(employeer);
            await _context.SaveChangesAsync();
        }

        public async Task<bool> DeleteEmployeeAsync(int id)
        {
            var employee = await _context.Employees.FindAsync(id);
            if (employee == null)
            {
                return false;
            }

            _context.Employees.Remove(employee);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<IEnumerable<EmployeeDto>> GetAllEmployeesAsync()
        {
            var employees = await _context.Employees.ToListAsync();
            return _mapper.Map<List<Employee>, List<EmployeeDto>>(employees);
        }

        public async Task<EmployeeDto> GetEmployeeByIdAsync(int id)
        {
            var employee = await _context.Employees.FindAsync(id);
            return _mapper.Map<Employee, EmployeeDto>(employee);
        }

        public async Task<bool> UpdateEmployeeAsync(EmployeeDto employee)
        {
            var employeer = _mapper.Map<EmployeeDto, Employee>(employee);
            _context.Entry(employeer).State = EntityState.Modified;
            try
            {
                await _context.SaveChangesAsync();
                return true;
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!await EmployeeExistsAsync(employeer.Id))
                {
                    return false;
                }
                throw;
            }
        }

        private async Task<bool> EmployeeExistsAsync(int id)
        {
            return await _context.Employees.AnyAsync(e => e.Id == id);
        }
    }
}
