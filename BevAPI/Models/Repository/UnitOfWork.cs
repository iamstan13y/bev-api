using BevAPI.Models.Data;
using BevAPI.Models.Repository.IRepository;

namespace BevAPI.Models.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly AppDbContext _context;

        public UnitOfWork(AppDbContext context)
        {
            _context = context;
        }

        public void SaveChanges() => _context.SaveChanges();
    }
}