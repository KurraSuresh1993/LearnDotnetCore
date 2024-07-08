using LearnAPI.Helper;
using LearnAPI.Models;
using LearnAPI.Repos.Models;

namespace LearnAPI.Services
{
    public interface ICustomerService
    {
        Task<List<CustomerModel>> GetAllAsync();

        Task<CustomerModel> GetByIdAsync(int id);

        Task<APIResponse> CreateAsync(CustomerModel customer);

        Task<APIResponse> UpdateAsync(CustomerModel customer,int id);

        Task<APIResponse> RemoveAsync(int id);
    }
}
