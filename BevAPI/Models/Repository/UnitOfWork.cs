using BevAPI.Models.Data;

namespace BevAPI.Models.Repository
{
    public class UnitOfWork
    {
        private readonly AppDbContext _context;

        public UnitOfWork(AppDbContext context)
        {
            _context = context;
        }

        public void SaveChanges() => _context.SaveChanges();
    }
}