using AutoMapper;
using LearnAPI.Helper;
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

        public async Task<APIResponse> CreateAsync(CustomerModel customer)
        {
            var response = new APIResponse();
            try
            {
                var tblCustomer = _mapper.Map<CustomerModel, TblCustomer>(customer);
                await _context.TblCustomers.AddAsync(tblCustomer);
                await _context.SaveChangesAsync();
                response.ResponseCode = 201;
                response.Result =Convert.ToString(customer.Id);

            }
            catch (Exception ex)
            {

                response.ResponseCode = 400;
                response.ErrorMessage = ex.Message;
            }
            return response;

        }

        public async Task<List<CustomerModel>> GetAllAsync()
        {
            List<CustomerModel> customerModels = new List<CustomerModel>();
            var tblcustomers = await _context.TblCustomers.ToListAsync();
            if (tblcustomers is not null)
            {
                customerModels = _mapper.Map<List<TblCustomer>, List<CustomerModel>>(tblcustomers);
            }
            return customerModels;
        }

        public async Task<CustomerModel> GetByIdAsync(int id)
        {
            CustomerModel customerModel = new CustomerModel();
            var tblcustomer = await _context.TblCustomers.FindAsync(id);
            if (tblcustomer is not null)
            {
                customerModel = _mapper.Map<TblCustomer, CustomerModel>(tblcustomer);
            }
            return customerModel;
        }

        public async Task<APIResponse> RemoveAsync(int id)
        {
            var response = new APIResponse();
            try
            {
                var customer = await _context.TblCustomers.FindAsync(id);
                if (customer is not null)
                {
                    _context.TblCustomers.Remove(customer);
                    await _context.SaveChangesAsync();
                    response.ResponseCode = 201;
                    response.Result = Convert.ToString(id);
                }
                else
                {
                    response.ResponseCode = 404;
                    response.ErrorMessage = "Not Found";
                }


            }
            catch (Exception ex)
            {

                response.ResponseCode = 400;
                response.ErrorMessage = ex.Message;
            }
            return response;
        }

        public async Task<APIResponse> UpdateAsync(CustomerModel model, int id)
        {
            var response = new APIResponse();
            try
            {
                var customer = await _context.TblCustomers.FindAsync(id);
                if (customer is not null)
                {
                    customer.Name = model.Name;
                    customer.Phone = model.Phone;
                    customer.Email = model.Email;
                    customer.CreditLimit = model.CreditLimit;
                    customer.IsActive = model.IsActive;
                    await _context.SaveChangesAsync();
                    response.ResponseCode = 201;
                    response.Result = Convert.ToString(id);
                }
                else
                {
                    response.ResponseCode = 404;
                    response.ErrorMessage = "Not Found";
                }
            }
            catch (Exception ex)
            {

                response.ResponseCode = 400;
                response.ErrorMessage = ex.Message;
            }
            return response;
        }
    }
}
