using Microsoft.EntityFrameworkCore;

namespace BevAPI.Models.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<Account>? Accounts { get; set; }
        public DbSet<Player>? Players { get; set; }
    }
}