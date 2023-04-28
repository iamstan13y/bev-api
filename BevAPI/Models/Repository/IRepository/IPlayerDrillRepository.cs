using BevAPI.Models.Data;
using BevAPI.Models.Local;

namespace BevAPI.Models.Repository.IRepository
{
    public interface IPlayerDrillRepository : IRepository<PlayerDrill>
    {
        Task<Result<PlayerDrill>> GetByPlayerIdAsync(int playerId);
    }
}