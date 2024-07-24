using AutoMapper;
using LearnAPI.Helper;
using LearnAPI.Models;
using LearnAPI.Repos;
using LearnAPI.Repos.Models;
using LearnAPI.Services;

namespace LearnAPI.Container
{
    public class UserService : IUserService
    {
        private readonly LearnDataContext _context;
        private readonly IMapper _mapper;

        public UserService(LearnDataContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public Task<APIResponse> ConfirmRegistrationAsync(int userId, string userName, string otpText)
        {
            throw new NotImplementedException();
        }

        public async Task<APIResponse> UserRegistrationAsync(UserRegister userRegister)
        {
            APIResponse response = new();
            int userId = 0;
            string otpType = GenerateRondomOtp();
            try
            {
                if (userRegister != null)
                {
                    var user = _mapper.Map<UserRegister, TblTempuser>(userRegister);
                    await _context.TblTempusers.AddAsync(user);
                    await _context.SaveChangesAsync();
                    userId = user.Id;
                    await UpdateOtp(userRegister.UserName, otpType, "register");
                    response.Result = userId.ToString();
                    response.ResponseCode = 200;
                }

            }
            catch (Exception ex)
            {

                throw;
            }

            return response;

        }

        public async Task UpdateOtp(string userName, string otpText, string otpType)
        {
            var _otpManager = new TblOtpManager()
            {
                Username = userName,
                Otptext = otpText,
                Otptype = otpType,
                Expiration = DateTime.Now.AddMinutes(30),
                Createddate = DateTime.Now,
            };
            await _context.TblOtpManagers.AddAsync(_otpManager);
            await _context.SaveChangesAsync();
        }

        public string GenerateRondomOtp()
        {
            return new Random().Next(0, 1000000).ToString("D6");
        }
    }
}
