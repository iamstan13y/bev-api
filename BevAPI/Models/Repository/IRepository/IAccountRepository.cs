using BevAPI.Models.Data;
using BevAPI.Models.Local;

namespace BevAPI.Models.Repository.IRepository
{
    public interface IAccountRepository
    {
        Task<Result<Account>> AddAsync(Account account);
        Task<Result<Account>> GetByIdAsync(int id);
        Task<Result<IEnumerable<Account>>> GetAllAsync();
        Task<Result<Account>> UpdateAsync(Account account);
        Task<Result<bool>> DeleteAsync(Account account);
        Task<Result<Account>> LoginAsync(LoginRequest request);
        //Task<Result<Account>> ChangePasswordAsync(ChangePasswordRequest changePassword);
    }
}