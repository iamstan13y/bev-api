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

        public async Task<Result<IEnumerable<PlayerDrill>>> GetByPlayerIdAsync(int playerId)
        {
            var playerDrills = await _dbSet
                .Where(x => x.PlayerId == playerId)
                .Include(x => x.Player)
                .Include(x => x.Drill)
                .ToListAsync();


            return new Result<IEnumerable<PlayerDrill>>(playerDrills);
        }

        public async Task<Result<IEnumerable<PlayerDrill>>> GetByDrillIdAsync(int drillId)
        {
            var playerDrills = await _dbSet
                .Where(x => x.DrillId == drillId)
                .Include(x => x.Player)
                .Include(x => x.Drill)
                .OrderByDescending(x => x.DrillMark)
                .ToListAsync();

            return new Result<IEnumerable<PlayerDrill>>(playerDrills);
        }
    }
}