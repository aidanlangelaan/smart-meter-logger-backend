using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Smartmeter.Data.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase()
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Meters",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    DeviceType = table.Column<sbyte>(type: "tinyint", nullable: false),
                    SerialNumber = table.Column<string>(type: "varchar(34)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    RowVersion = table.Column<DateTime>(type: "datetime", rowVersion: true, nullable: false, defaultValueSql: "CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP")
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.ComputedColumn),
                    CreatedOnAt = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "CURRENT_TIMESTAMP")
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    UpdatedOnAt = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP")
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.ComputedColumn)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Meters", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "ElectricityMeter",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    DsmrVersion = table.Column<sbyte>(type: "tinyint", nullable: false),
                    NrPowerfailures = table.Column<int>(type: "int", nullable: false),
                    NrPowerfailuresLong = table.Column<int>(type: "int", nullable: false),
                    PowerfailureLog = table.Column<string>(type: "varchar(255)", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    NrVoltageSagsL1 = table.Column<int>(type: "int", nullable: false),
                    NrVoltageSagsL2 = table.Column<int>(type: "int", nullable: true),
                    NrVoltageSagsL3 = table.Column<int>(type: "int", nullable: true),
                    NrVoltageSwellsL1 = table.Column<int>(type: "int", nullable: false),
                    NrVoltageSwellsL2 = table.Column<int>(type: "int", nullable: true),
                    NrVoltageSwellsL3 = table.Column<int>(type: "int", nullable: true),
                    MeterId = table.Column<int>(type: "int", nullable: false),
                    RowVersion = table.Column<DateTime>(type: "datetime", rowVersion: true, nullable: false, defaultValueSql: "CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP")
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.ComputedColumn),
                    CreatedOnAt = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "CURRENT_TIMESTAMP")
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    UpdatedOnAt = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP")
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.ComputedColumn)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ElectricityMeter", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ElectricityMeter_Meters_MeterId",
                        column: x => x.MeterId,
                        principalTable: "Meters",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "ElectricityUsages",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    ActPowerL1 = table.Column<decimal>(type: "decimal(10,3)", nullable: false),
                    ActPowerL2 = table.Column<decimal>(type: "decimal(10,3)", nullable: true),
                    ActPowerL3 = table.Column<decimal>(type: "decimal(10,3)", nullable: true),
                    ActPowerBackdeliveryL1 = table.Column<decimal>(type: "decimal(10,3)", nullable: false),
                    ActPowerBackdeliveryL2 = table.Column<decimal>(type: "decimal(10,3)", nullable: true),
                    ActPowerBackdeliveryL3 = table.Column<decimal>(type: "decimal(10,3)", nullable: true),
                    ActualBackdelivery = table.Column<decimal>(type: "decimal(10,3)", nullable: false),
                    ActualDelivery = table.Column<decimal>(type: "decimal(10,3)", nullable: false),
                    CurrentL1 = table.Column<decimal>(type: "decimal(10,3)", nullable: false),
                    CurrentL2 = table.Column<decimal>(type: "decimal(10,3)", nullable: true),
                    CurrentL3 = table.Column<decimal>(type: "decimal(10,3)", nullable: true),
                    MeterId = table.Column<int>(type: "int", nullable: false),
                    TariffIndicator = table.Column<sbyte>(type: "tinyint", nullable: false),
                    TextMessage = table.Column<string>(type: "varchar(255)", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Timestamp = table.Column<DateTime>(type: "datetime", nullable: false),
                    TotalBackdeliveryLow = table.Column<decimal>(type: "decimal(10,3)", nullable: false),
                    TotalBackdeliveryHigh = table.Column<decimal>(type: "decimal(10,3)", nullable: false),
                    TotalDeliveryHigh = table.Column<decimal>(type: "decimal(10,3)", nullable: false),
                    TotalDeliveryLow = table.Column<decimal>(type: "decimal(10,3)", nullable: false),
                    VoltageL1 = table.Column<decimal>(type: "decimal(10,3)", nullable: false),
                    voltageL2 = table.Column<decimal>(type: "decimal(10,3)", nullable: true),
                    VoltageL3 = table.Column<decimal>(type: "decimal(10,3)", nullable: true),
                    RowVersion = table.Column<DateTime>(type: "datetime", rowVersion: true, nullable: false, defaultValueSql: "CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP")
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.ComputedColumn),
                    CreatedOnAt = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "CURRENT_TIMESTAMP")
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    UpdatedOnAt = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP")
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.ComputedColumn)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ElectricityUsages", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ElectricityUsages_Meters_MeterId",
                        column: x => x.MeterId,
                        principalTable: "Meters",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "GasUsages",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    MeterId = table.Column<int>(type: "int", nullable: false),
                    Timestamp = table.Column<DateTime>(type: "datetime", nullable: false),
                    TotalDelivery = table.Column<decimal>(type: "decimal(10,3)", nullable: false),
                    RowVersion = table.Column<DateTime>(type: "datetime", rowVersion: true, nullable: false, defaultValueSql: "CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP")
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.ComputedColumn),
                    CreatedOnAt = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "CURRENT_TIMESTAMP")
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    UpdatedOnAt = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP")
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.ComputedColumn)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GasUsages", x => x.Id);
                    table.ForeignKey(
                        name: "FK_GasUsages_Meters_MeterId",
                        column: x => x.MeterId,
                        principalTable: "Meters",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_ElectricityMeter_MeterId",
                table: "ElectricityMeter",
                column: "MeterId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ElectricityUsages_MeterId",
                table: "ElectricityUsages",
                column: "MeterId");

            migrationBuilder.CreateIndex(
                name: "IX_GasUsages_MeterId",
                table: "GasUsages",
                column: "MeterId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ElectricityMeter");

            migrationBuilder.DropTable(
                name: "ElectricityUsages");

            migrationBuilder.DropTable(
                name: "GasUsages");

            migrationBuilder.DropTable(
                name: "Meters");
        }
    }
}
