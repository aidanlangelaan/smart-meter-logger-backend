using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
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
            // TODO: nog happy with this as it is...
            // setup auditable and concurrency properties
            foreach (var entityType in modelBuilder.Model.GetEntityTypes())
            {
                var rowVersionProperty = entityType.FindProperty("RowVersion");
                if (rowVersionProperty != null)
                {
                    rowVersionProperty.SetDefaultValueSql("CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP");
                    rowVersionProperty.ValueGenerated = ValueGenerated.OnAddOrUpdate;
                    rowVersionProperty.AddAnnotation("MySql:ValueGenerationStrategy",
                        MySqlValueGenerationStrategy.ComputedColumn);
                }

                var createdOnAtProperty = entityType.FindProperty("CreatedOnAt");
                if (createdOnAtProperty != null)
                {
                    createdOnAtProperty.SetDefaultValueSql("CURRENT_TIMESTAMP");
                    createdOnAtProperty.ValueGenerated = ValueGenerated.OnAdd;
                    createdOnAtProperty.AddAnnotation("MySql:ValueGenerationStrategy",
                        MySqlValueGenerationStrategy.IdentityColumn);
                }

                var updatedOnAtProperty = entityType.FindProperty("UpdatedOnAt");
                if (updatedOnAtProperty != null)
                {
                    updatedOnAtProperty.SetColumnType("datetime");
                    updatedOnAtProperty.SetDefaultValueSql("CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP");
                    updatedOnAtProperty.ValueGenerated = ValueGenerated.OnAddOrUpdate;
                    updatedOnAtProperty.AddAnnotation("MySql:ValueGenerationStrategy",
                        MySqlValueGenerationStrategy.ComputedColumn);
                }
            }
        }
    }
}