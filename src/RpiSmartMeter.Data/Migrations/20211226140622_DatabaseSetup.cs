using System;
using Microsoft.EntityFrameworkCore.Migrations;
using MySql.EntityFrameworkCore.Metadata;

namespace RpiSmartMeter.Data.Migrations
{
    public partial class DatabaseSetup : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Meters",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    SerialNumber = table.Column<string>(type: "varchar(255)", nullable: false),
                    DeviceType = table.Column<byte>(type: "tinyint", nullable: false),
                    RowVersion = table.Column<DateTime>(type: "datetime", rowVersion: true, nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.ComputedColumn),
                    CreatedOnAt = table.Column<DateTime>(type: "datetime", nullable: false),
                    UpdatedOnAt = table.Column<DateTime>(type: "datetime", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Meters", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ElectricityUsages",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    Timestamp = table.Column<DateTime>(type: "datetime", nullable: false),
                    MeterId = table.Column<int>(type: "int", nullable: false),
                    TotalDeliveryLowKwh = table.Column<float>(type: "float", nullable: false),
                    TotalDeliveryHighKwh = table.Column<float>(type: "float", nullable: false),
                    TotalBackdeliveryLowKwh = table.Column<float>(type: "float", nullable: false),
                    TotalBackdeliveryHighKwh = table.Column<float>(type: "float", nullable: false),
                    TariffIndicator = table.Column<byte>(type: "tinyint", nullable: false),
                    ActualDeliveryKw = table.Column<float>(type: "float", nullable: false),
                    ActualBackdeliveryKw = table.Column<float>(type: "float", nullable: false),
                    TextMessage = table.Column<string>(type: "varchar(255)", nullable: true),
                    RowVersion = table.Column<DateTime>(type: "datetime", rowVersion: true, nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.ComputedColumn),
                    CreatedOnAt = table.Column<DateTime>(type: "datetime", nullable: false),
                    UpdatedOnAt = table.Column<DateTime>(type: "datetime", nullable: false)
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
                });

            migrationBuilder.CreateTable(
                name: "GasUsages",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    Timestamp = table.Column<DateTime>(type: "datetime", nullable: false),
                    MeterId = table.Column<int>(type: "int", nullable: false),
                    TotalDelivery = table.Column<string>(type: "varchar(255)", nullable: true),
                    RowVersion = table.Column<DateTime>(type: "datetime", rowVersion: true, nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.ComputedColumn),
                    CreatedOnAt = table.Column<DateTime>(type: "datetime", nullable: false),
                    UpdatedOnAt = table.Column<DateTime>(type: "datetime", nullable: false)
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
                });

            migrationBuilder.CreateIndex(
                name: "IX_ElectricityUsages_MeterId",
                table: "ElectricityUsages",
                column: "MeterId");

            migrationBuilder.CreateIndex(
                name: "IX_GasUsages_MeterId",
                table: "GasUsages",
                column: "MeterId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ElectricityUsages");

            migrationBuilder.DropTable(
                name: "GasUsages");

            migrationBuilder.DropTable(
                name: "Meters");
        }
    }
}
