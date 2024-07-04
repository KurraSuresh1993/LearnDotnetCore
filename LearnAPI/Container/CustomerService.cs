using AutoMapper;
using LearnAPI.Models;
using LearnAPI.Repos;
using LearnAPI.Repos.Models;
using LearnAPI.Services;
using Microsoft.EntityFrameworkCore;

namespace LearnAPI.Container
{
    public class CustomerService : ICustomerService
    {
        private readonly LearnDataContext _context;
        private readonly IMapper _mapper;

        public CustomerService(LearnDataContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<List<CustomerModel>> GetAllAsync()
        {
            List<CustomerModel> result = new List<CustomerModel>();
            var tblcustomers = await _context.TblCustomers.ToListAsync();
            if (tblcustomers is not null)
            {
                result = _mapper.Map<List<TblCustomer>,List<CustomerModel>>(tblcustomers);
            }
            return result;
        }
    }
}
