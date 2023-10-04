using Microsoft.EntityFrameworkCore;
using SmartMeterLogger.Data.Entities;

namespace SmartMeterLogger.Data
{
    public class SmartMeterLoggerDbContext : DbContext
    {
        public DbSet<Meter> Meters { get; set; }
        public DbSet<ElectricityUsage> ElectricityUsages { get; set; }
        public DbSet<GasUsage> GasUsages { get; set; }

        public SmartMeterLoggerDbContext(DbContextOptions<SmartMeterLoggerDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
        }
    }
}
