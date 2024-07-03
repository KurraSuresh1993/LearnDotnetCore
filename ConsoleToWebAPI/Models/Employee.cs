using System.ComponentModel.DataAnnotations;

namespace ConsoleToWebAPI.Models
{
    public class Employee
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
        public double Salary { get;set; }
    }
}
