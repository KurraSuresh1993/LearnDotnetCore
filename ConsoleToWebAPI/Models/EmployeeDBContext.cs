using Microsoft.EntityFrameworkCore;

namespace ConsoleToWebAPI.Models
{
    public class EmployeeDBContext : DbContext
    {
        public EmployeeDBContext(DbContextOptions<EmployeeDBContext> options) : base(options)
        {

        }

        public DbSet<Employee> Employees { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Employee>().HasData(
                new Employee
                {
                    Id = 1,
                    Name = "John Doe",
                    Description = "Senior Developer",
                    Email = "john.doe@example.com",
                    Salary = 60000,
                    IsActive = true
                },
                new Employee
                {
                    Id = 2,
                    Name = "Jane Smith",
                    Description = "Project Manager",
                    Email = "jane.smith@example.com",
                    Salary = 80000,
                    IsActive = true
                },
                new Employee
                {
                    Id = 3,
                    Name = "Alice Johnson",
                    Description = "UX Designer",
                    Email = "alice.johnson@example.com",
                    Salary = 55000,
                    IsActive = false
                }
            );
        }
    }
}

