using BevAPI.Models.Data;
using BevAPI.Models.Local;

namespace BevAPI.Models.Repository.IRepository
{
    public interface IPlayerDrillRepository : IRepository<PlayerDrill>
    {
        Task<Result<IEnumerable<PlayerDrill>>> GetByPlayerIdAsync(int playerId);
        Task<Result<IEnumerable<PlayerDrill>>> GetByDrillIdAsync(int drillId);
    }
}