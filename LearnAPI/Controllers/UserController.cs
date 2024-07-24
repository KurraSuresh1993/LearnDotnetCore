using LearnAPI.Models;
using LearnAPI.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LearnAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost("UserRegistration")]
        public async Task<IActionResult> UserRegistrationAsync(UserRegister userRegister)
        {
            var user = await _userService.UserRegistrationAsync(userRegister);
            return Ok(user);

        }

        [HttpPost("ConfirmRegistration")]
        public async Task<IActionResult> ConfirmRegistrationAsync(int userId, string userName, string otpText)
        {
            var user = await _userService.ConfirmRegistrationAsync(userId,userName,otpText);
            return Ok(user);

        }
    }
}
