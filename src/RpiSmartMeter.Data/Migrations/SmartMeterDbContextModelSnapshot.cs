﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using RpiSmartMeter.Data;

namespace RpiSmartMeter.Data.Migrations
{
    [DbContext(typeof(SmartMeterDbContext))]
    partial class SmartMeterDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 64)
                .HasAnnotation("ProductVersion", "5.0.13");

            modelBuilder.Entity("RpiSmartMeter.Data.Entities.ElectricityUsage", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<float>("ActualBackdeliveryKw")
                        .HasColumnType("float");

                    b.Property<float>("ActualDeliveryKw")
                        .HasColumnType("float");

                    b.Property<DateTime>("CreatedOnAt")
                        .HasColumnType("datetime");

                    b.Property<int>("MeterId")
                        .HasColumnType("int");

                    b.Property<DateTime>("RowVersion")
                        .IsConcurrencyToken()
                        .ValueGeneratedOnAddOrUpdate()
                        .HasColumnType("datetime");

                    b.Property<byte>("TariffIndicator")
                        .HasColumnType("tinyint");

                    b.Property<string>("TextMessage")
                        .HasColumnType("varchar(255)");

                    b.Property<DateTime>("Timestamp")
                        .HasColumnType("datetime");

                    b.Property<float>("TotalBackdeliveryHighKwh")
                        .HasColumnType("float");

                    b.Property<float>("TotalBackdeliveryLowKwh")
                        .HasColumnType("float");

                    b.Property<float>("TotalDeliveryHighKwh")
                        .HasColumnType("float");

                    b.Property<float>("TotalDeliveryLowKwh")
                        .HasColumnType("float");

                    b.Property<DateTime>("UpdatedOnAt")
                        .HasColumnType("datetime");

                    b.HasKey("Id");

                    b.HasIndex("MeterId");

                    b.ToTable("ElectricityUsages");
                });

            modelBuilder.Entity("RpiSmartMeter.Data.Entities.GasUsage", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<DateTime>("CreatedOnAt")
                        .HasColumnType("datetime");

                    b.Property<int>("MeterId")
                        .HasColumnType("int");

                    b.Property<DateTime>("RowVersion")
                        .IsConcurrencyToken()
                        .ValueGeneratedOnAddOrUpdate()
                        .HasColumnType("datetime");

                    b.Property<DateTime>("Timestamp")
                        .HasColumnType("datetime");

                    b.Property<string>("TotalDelivery")
                        .HasColumnType("varchar(255)");

                    b.Property<DateTime>("UpdatedOnAt")
                        .HasColumnType("datetime");

                    b.HasKey("Id");

                    b.HasIndex("MeterId");

                    b.ToTable("GasUsages");
                });

            modelBuilder.Entity("RpiSmartMeter.Data.Entities.Meter", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<DateTime>("CreatedOnAt")
                        .HasColumnType("datetime");

                    b.Property<byte>("DeviceType")
                        .HasColumnType("tinyint");

                    b.Property<DateTime>("RowVersion")
                        .IsConcurrencyToken()
                        .ValueGeneratedOnAddOrUpdate()
                        .HasColumnType("datetime");

                    b.Property<string>("SerialNumber")
                        .IsRequired()
                        .HasColumnType("varchar(255)");

                    b.Property<DateTime>("UpdatedOnAt")
                        .HasColumnType("datetime");

                    b.HasKey("Id");

                    b.ToTable("Meters");
                });

            modelBuilder.Entity("RpiSmartMeter.Data.Entities.ElectricityUsage", b =>
                {
                    b.HasOne("RpiSmartMeter.Data.Entities.Meter", "Meter")
                        .WithMany("ElectricityUsages")
                        .HasForeignKey("MeterId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Meter");
                });

            modelBuilder.Entity("RpiSmartMeter.Data.Entities.GasUsage", b =>
                {
                    b.HasOne("RpiSmartMeter.Data.Entities.Meter", "Meter")
                        .WithMany("GasUsages")
                        .HasForeignKey("MeterId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Meter");
                });

            modelBuilder.Entity("RpiSmartMeter.Data.Entities.Meter", b =>
                {
                    b.Navigation("ElectricityUsages");

                    b.Navigation("GasUsages");
                });
#pragma warning restore 612, 618
        }
    }
}
