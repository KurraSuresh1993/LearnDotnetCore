using LearnAPI.Repos;
using Microsoft.AspNetCore.Authentication;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using System.Net.Http.Headers;
using System.Security.Claims;
using System.Text;
using System.Text.Encodings.Web;

namespace LearnAPI.Helper
{
    public class BasicAuthenticationHandler : AuthenticationHandler<AuthenticationSchemeOptions>
    {
        private readonly LearnDataContext _context;

        public BasicAuthenticationHandler(IOptionsMonitor<AuthenticationSchemeOptions> options, ILoggerFactory logger, UrlEncoder encoder, ISystemClock clock, LearnDataContext context) : base(options, logger, encoder, clock)
        {
            _context = context;
        }

        protected override async Task<AuthenticateResult> HandleAuthenticateAsync()
        {
            string authHeader = Request.Headers["Authorization"].ToString();
            if (!string.IsNullOrEmpty(authHeader))
            {
                var headerValue = AuthenticationHeaderValue.Parse(authHeader);

                var bytes = Convert.FromBase64String(headerValue.Parameter);
                string credentials = Encoding.UTF8.GetString(bytes);
                string[] array = credentials.Split(":");
                string username = array[0];
                string password = array[1];
                var user = await _context.TblUsers.FirstOrDefaultAsync(u => u.Username == username && u.Password == password);
                if (user is not null)
                {
                    var claims = new[]
                         {
                              new Claim(ClaimTypes.Name, user.Username),
                         };
                    var identity = new ClaimsIdentity(claims, Scheme.Name);
                    var principal = new ClaimsPrincipal(identity);
                    return AuthenticateResult.Success(new AuthenticationTicket(principal, Scheme.Name));
                }
                else
                {
                    return AuthenticateResult.Fail("UnAuthorized");
                }
            }
            else
            {
                return AuthenticateResult.Fail("UnAuthorized");
            }
        }
    }
}


