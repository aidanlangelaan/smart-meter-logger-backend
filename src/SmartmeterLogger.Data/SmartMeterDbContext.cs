﻿using Microsoft.EntityFrameworkCore;
using SmartMeterLogger.Data.Entities;

namespace SmartMeterLogger.Data
{
    public class SmartMeterDbContext : DbContext
    {
        public DbSet<Meter> Meters { get; set; }
        public DbSet<ElectricityUsage> ElectricityUsages { get; set; }
        public DbSet<GasUsage> GasUsages { get; set; }

        public SmartMeterDbContext(DbContextOptions<SmartMeterDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
        }
    }
}
