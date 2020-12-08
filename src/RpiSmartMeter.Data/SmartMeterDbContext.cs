using Microsoft.EntityFrameworkCore;
using RpiSmartMeter.Data.Entities;

namespace RpiSmartMeter.Data
{
    public class SmartMeterDbContext : DbContext
    {
        public DbSet<Meter> Meters { get; set; }
        public DbSet<Telegram> Telegrams { get; set; }
        public DbSet<PowerFailure> PowerFailures { get; set; }

        public SmartMeterDbContext(DbContextOptions<SmartMeterDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
        }
    }
}
