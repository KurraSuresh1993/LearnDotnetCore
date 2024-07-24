using LearnAPI.Models;
using LearnAPI.Repos;
using LearnAPI.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using Microsoft.VisualBasic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace LearnAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthorizeController : ControllerBase
    {
        private readonly LearnDataContext _context;
        private readonly IRefreshHandler _refreshHandler;
        private readonly JwtSettings _jwtSettings;

        public AuthorizeController(LearnDataContext context, IOptions<JwtSettings> jwtSettings, IRefreshHandler refreshHandler)
        {
            _context = context;
            _refreshHandler = refreshHandler;
            _jwtSettings = jwtSettings.Value;
        }

        [HttpPost("GenerateToken")]
        public async Task<ActionResult> GenerateTokenAsync([FromBody] UserCredential userCredential)
        {
            var user = await _context.TblUsers.FirstOrDefaultAsync(item => item.Username == userCredential.UserName && item.Password == userCredential.Password);

            if (user is not null)
            {
                //generate token
                var tokenHandler = new JwtSecurityTokenHandler();
                var tokenKey = Encoding.UTF8.GetBytes(_jwtSettings.SecurityKey);
                var tokenDesc = new SecurityTokenDescriptor
                {
                    Subject = new ClaimsIdentity(new Claim[]
                    {
                        new(ClaimTypes.Name,user.Username),
                        new(ClaimTypes.Role,user.Role)
                    }),
                    Expires = DateTime.UtcNow.AddSeconds(30),
                    SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(tokenKey), SecurityAlgorithms.HmacSha256)
                };
                var token = tokenHandler.CreateToken(tokenDesc);
                var finalToken = tokenHandler.WriteToken(token);
                return Ok(new TokenReponse() { Token = finalToken, RefreshToken = await _refreshHandler.GenerateTokenAync(userCredential.UserName) });
            }
            else
            {
                return Unauthorized();
            }
        }

        [HttpPost("GenerateRefreshToken")]
        public async Task<IActionResult> GenerateRefreshToken([FromBody] TokenReponse tokenReponse)
        {
            var refreshToken = await _context.TblRefreshtokens.FirstOrDefaultAsync(item => item.RefreshToken == tokenReponse.RefreshToken);
            if (refreshToken != null)
            {
                var tokenHandler = new JwtSecurityTokenHandler();
                var tokenKey = Encoding.UTF8.GetBytes(_jwtSettings.SecurityKey);
                SecurityToken securityToken;
                var principle = tokenHandler.ValidateToken(tokenReponse.Token, new TokenValidationParameters()
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(tokenKey),
                    ValidateIssuer = false,
                    ValidateAudience = false,
                }, out securityToken);
                var _token = securityToken as JwtSecurityToken;
                if (_token != null && _token.Header.Alg.Equals(SecurityAlgorithms.HmacSha256))
                {
                    string userName = principle.Identity?.Name;
                    var existData = await _context.TblRefreshtokens.FirstOrDefaultAsync(item => item.UserId == userName && item.RefreshToken == tokenReponse.RefreshToken);
                    if (existData != null)
                    {
                        var newToken = new JwtSecurityToken(
                            claims: principle.Claims.ToArray(),
                            expires: DateTime.Now.AddSeconds(30),
                            signingCredentials: new SigningCredentials(
                                new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwtSettings.SecurityKey)), SecurityAlgorithms.HmacSha256)
                            );
                        var finalToken = tokenHandler.WriteToken(newToken);
                        return Ok(new TokenReponse() { Token = finalToken, RefreshToken = await _refreshHandler.GenerateTokenAync(userName) });
                    }
                    else
                    {
                        return Unauthorized();
                    }
                }
                else
                {
                    return Unauthorized();
                }

            }
            else
            {
                return Unauthorized();
            }

        }
    }
}
