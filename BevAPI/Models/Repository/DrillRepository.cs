using BevAPI.Models.Data;
using BevAPI.Models.Repository.IRepository;

namespace BevAPI.Models.Repository
{
    public class DrillRepository : Repository<Drill>, IDrillRepository
    {
        public DrillRepository(AppDbContext context) : base(context)
        {
        }
    }
}