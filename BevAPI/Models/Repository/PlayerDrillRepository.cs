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
            var playerDrill = await _dbSet
                .Where(x => x.PlayerId == playerId)
                .Include(x => x.Player)
                .Include(x => x.Drill)
                .FirstOrDefaultAsync();

            if (playerDrill == null) return new Result<PlayerDrill>(false, "Player Drill not found.");

            return new Result<PlayerDrill>(playerDrill);
        }

        public async Task<Result<IEnumerable<PlayerDrill>>> GetByDrillIdAsync(int drillId)
        {
            var playerDrills = await _dbSet
                .Where(x => x.DrillId == drillId)
                .Include(x => x.Player)
                .Include(x => x.Drill)
                .ToListAsync();

            return new Result<IEnumerable<PlayerDrill>>(playerDrills);
        }
    }
}
