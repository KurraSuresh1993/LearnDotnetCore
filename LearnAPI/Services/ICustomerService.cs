using LearnAPI.Models;
using LearnAPI.Repos.Models;

namespace LearnAPI.Services
{
    public interface ICustomerService
    {
       Task<List<CustomerModel>> GetAllAsync();
    }
}
