using BevAPI.Models.Data;
using BevAPI.Models.Repository.IRepository;

namespace BevAPI.Models.Repository
{
    public class PlayerDrillRepository : Repository<PlayerDrill>, IPlayerDrillRepository
    {
        public PlayerDrillRepository(AppDbContext context) : base(context)
        {
        }
    }
}
