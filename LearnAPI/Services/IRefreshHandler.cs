namespace LearnAPI.Services
{
    public interface IRefreshHandler
    {
        Task<string> GenerateTokenAync(string userName);
    }
}
