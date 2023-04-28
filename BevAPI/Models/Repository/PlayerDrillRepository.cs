using BevAPI.Models.Data;
using BevAPI.Models.Local;
using BevAPI.Models.Repository.IRepository;
using Microsoft.EntityFrameworkCore;

namespace BevAPI.Models.Repository
{
    public class PlayerDrillRepository : Repository<PlayerDrill>, IPlayerDrillRepository
    {
        public PlayerDrillRepository(AppDbContext context) : base(context)
        {
        }

        public async Task<Result<PlayerDrill>> GetByPlayerIdAsync(int playerId)
        {
            var player = await _dbSet
                .Where(x => x.PlayerId == playerId)
                .FirstOrDefaultAsync();
            if (player == null) return new Result<PlayerDrill>(false, "Player Drill not found.");

            return new Result<PlayerDrill>(player);
        }
    }
}
