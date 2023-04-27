using BevAPI.Models.Data;
using BevAPI.Models.Repository.IRepository;

namespace BevAPI.Models.Repository
{
    public class PlayerRepository : Repository<Player>, IPlayerRepository
    {
        public PlayerRepository(AppDbContext context) : base(context)
        {
        }
    }
}