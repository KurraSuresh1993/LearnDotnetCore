using System.ComponentModel.DataAnnotations;

namespace ConsoleToWebAPI.DTO
{
    public class EmployeeDto
    {
        [Required]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        public string Description { get; set; } = string.Empty;

        [Required]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [DataType(DataType.Currency)]
        public double Salary { get; set; }

        public bool IsActive { get; set; }
    }
}
