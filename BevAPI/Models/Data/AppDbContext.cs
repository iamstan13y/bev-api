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
        public DbSet<Drill>? Drills { get; set; }
        public DbSet<PlayerDrill>? PlayerDrills { get; set; }
    }
}