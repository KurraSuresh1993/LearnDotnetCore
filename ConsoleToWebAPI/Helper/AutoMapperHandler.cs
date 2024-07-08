using AutoMapper;
using ConsoleToWebAPI.DTO;
using ConsoleToWebAPI.Models;

namespace ConsoleToWebAPI.Helper
{
    public class AutoMapperHandler:Profile
    {
        public AutoMapperHandler()
        {
            CreateMap<Employee,EmployeeDto>().ReverseMap(); 
        }
    }
}
