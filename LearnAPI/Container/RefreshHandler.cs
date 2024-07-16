using LearnAPI.Repos;
using LearnAPI.Repos.Models;
using LearnAPI.Services;
using Microsoft.EntityFrameworkCore;
using System.Security.Cryptography;

namespace LearnAPI.Container
{
    public class RefreshHandler : IRefreshHandler
    {
        private readonly LearnDataContext _context;

        public RefreshHandler(LearnDataContext context)
        {
            _context = context;
        }
        public async Task<string> GenerateTokenAync(string userName)
        {
            var randomNumber = new byte[32];
            using (var randomNumberGenerator = RandomNumberGenerator.Create())
            {
                randomNumberGenerator.GetBytes(randomNumber);
                string refreshToken = Convert.ToBase64String(randomNumber);
                var existToken = await _context.TblRefreshtokens.FirstOrDefaultAsync(item => item.UserId == userName);
                if (existToken != null)
                {
                    existToken.RefreshToken = refreshToken;
                }
                else
                {
                    await _context.TblRefreshtokens.AddAsync(new TblRefreshtoken
                    {
                        UserId = userName,
                        TokenId = new Random().Next().ToString(),
                        RefreshToken = refreshToken
                    });
                }
                await _context.SaveChangesAsync();
                return refreshToken;
            }
        }
    }
}
