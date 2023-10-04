using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
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
            // modelBuilder.Entity<ElectricityUsage>(entity =>
            // {
            //     // entity.Property(e => e.CreatedOnAt).ValueGeneratedOnAdd();
            //     // entity.Property(e => e.UpdatedOnAt).ValueGeneratedOnAddOrUpdate();
            //     // entity.Property(e => e.RowVersion).ValueGeneratedOnAddOrUpdate()
            //     //     .HasPrecision(3)
            //     //     .HasConversion<DateTime>(s => new DateTime(s), date => date.Ticks)
            //     //     .HasDefaultValueSql("current_timestamp(3) ON UPDATE current_timestamp(3)");
            //
            //     entity.Property(e => e.RowVersion)
            //         .HasConversion<DateTime>(s => new DateTime(s), date => date.Ticks);
            // });
            //
            // modelBuilder.Entity<GasUsage>(entity =>
            // {
            //     // entity.Property(e => e.CreatedOnAt).ValueGeneratedOnAdd();
            //     // entity.Property(e => e.UpdatedOnAt).ValueGeneratedOnAddOrUpdate();
            //     
            //     entity.Property(e => e.RowVersion)
            //         .HasConversion<DateTime>(s => new DateTime(s), date => date.Ticks);
            // });
            //
            // modelBuilder.Entity<Meter>(entity =>
            // {
            //     // entity.Property(e => e.CreatedOnAt).ValueGeneratedOnAdd();
            //     // entity.Property(e => e.UpdatedOnAt).ValueGeneratedOnAddOrUpdate();
            //     
            //     entity.Property(e => e.RowVersion)
            //         .HasConversion<DateTime>(s => new DateTime(s), date => date.Ticks);
            // });
            //
            // modelBuilder.Entity<ElectricityMeter>(entity =>
            // {
            //     // entity.Property(e => e.CreatedOnAt).ValueGeneratedOnAdd();
            //     // entity.Property(e => e.UpdatedOnAt).ValueGeneratedOnAddOrUpdate();
            //     // entity.Property(e => e.RowVersion)
            //     //     .ValueGeneratedOnAddOrUpdate()
            //     //     .HasPrecision(3)
            //     //     .HasConversion(s => new DateTime(s), date => date.Ticks)
            //     //     .HasDefaultValueSql("current_timestamp(3) ON UPDATE current_timestamp(3)");
            //     
            //     entity.Property(e => e.RowVersion)
            //         .HasConversion<DateTime>(s => new DateTime(s), date => date.Ticks);
            // });

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