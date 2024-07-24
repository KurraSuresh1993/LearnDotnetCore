using LearnAPI.Helper;
using LearnAPI.Models;

namespace LearnAPI.Services
{
    public interface IUserService
    {
        Task<APIResponse> UserRegistrationAsync(UserRegister userRegister);
        Task<APIResponse> ConfirmRegistrationAsync(int userId,string userName,string otpText);
    }
}
