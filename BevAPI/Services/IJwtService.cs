using BevAPI.Models.Data;

namespace BevAPI.Services
{
    public interface IJwtService
    {
        Task<string> GenerateTokenAsync(Account account);
    }
}