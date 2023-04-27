using BevAPI.Models.Data;
using BevAPI.Models.Repository.IRepository;

namespace BevAPI.Models.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly AppDbContext _context;

        public IPlayerRepository Player { get; private set; }
        public IDrillRepository Drill { get; private set; }
        public IPlayerDrillRepository PlayerDrill { get; private set; }

        public UnitOfWork(AppDbContext context)
        {
            Player = new PlayerRepository(context);
            Drill = new DrillRepository(context);
            PlayerDrill = new PlayerDrillRepository(context);
            _context = context;
        }

        public void SaveChanges() => _context.SaveChanges();
    }
}