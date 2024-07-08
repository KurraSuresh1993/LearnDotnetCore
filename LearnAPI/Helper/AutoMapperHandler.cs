using AutoMapper;
using LearnAPI.Models;
using LearnAPI.Repos.Models;

namespace LearnAPI.Helper
{
    public class AutoMapperHandler : Profile
    {
        public AutoMapperHandler()
        {
            CreateMap<TblCustomer, CustomerModel>()
                .ForMember(item => item.StatusName, o => o.MapFrom(
                    item => item.IsActive.HasValue ? "Active" : "In-Active"))
                .ReverseMap();
        }
    }
}
