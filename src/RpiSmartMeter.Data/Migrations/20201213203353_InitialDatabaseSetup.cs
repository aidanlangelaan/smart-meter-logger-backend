using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace RpiSmartMeter.Data.Migrations
{
    public partial class InitialDatabaseSetup : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Meters",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedOnAt = table.Column<DateTime>(type: "datetime2(7)", nullable: false),
                    UpdatedOnAt = table.Column<DateTime>(type: "datetime2(7)", nullable: false),
                    RowVersion = table.Column<byte[]>(type: "timestamp", nullable: false),
                    SerialNumber = table.Column<string>(type: "varchar(255)", nullable: false),
                    DsmrVersion = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Meters", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PowerFailures",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedOnAt = table.Column<DateTime>(type: "datetime2(7)", nullable: false),
                    UpdatedOnAt = table.Column<DateTime>(type: "datetime2(7)", nullable: false),
                    RowVersion = table.Column<byte[]>(type: "timestamp", nullable: false),
                    MeterId = table.Column<int>(type: "int", nullable: false),
                    Timestamp = table.Column<DateTime>(type: "datetime2(7)", nullable: false),
                    DurationInSeconds = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PowerFailures", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PowerFailures_Meters_MeterId",
                        column: x => x.MeterId,
                        principalTable: "Meters",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Telegrams",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedOnAt = table.Column<DateTime>(type: "datetime2(7)", nullable: false),
                    UpdatedOnAt = table.Column<DateTime>(type: "datetime2(7)", nullable: false),
                    RowVersion = table.Column<byte[]>(type: "timestamp", nullable: false),
                    Timestamp = table.Column<DateTime>(type: "datetime2(7)", nullable: false),
                    MeterId = table.Column<int>(type: "int", nullable: false),
                    TotalDeliveryLowKwh = table.Column<double>(type: "float", nullable: false),
                    TotalDeliveryHighKwh = table.Column<double>(type: "float", nullable: false),
                    TotalBackdeliveryLowKwh = table.Column<double>(type: "float", nullable: false),
                    TotalBackdeliveryHighKwh = table.Column<double>(type: "float", nullable: false),
                    TariffIndicator = table.Column<byte>(type: "tinyint", nullable: false),
                    ActualDeliveryKw = table.Column<double>(type: "float", nullable: false),
                    ActualBackdeliveryKw = table.Column<double>(type: "float", nullable: false),
                    NrPowerfailures = table.Column<int>(type: "int", nullable: false),
                    NrPowerfailuresLong = table.Column<int>(type: "int", nullable: false),
                    NrVoltageSagsL1 = table.Column<int>(type: "int", nullable: false),
                    NrVoltageSwellsL1 = table.Column<int>(type: "int", nullable: false),
                    VoltageL1V = table.Column<double>(type: "float", nullable: false),
                    CurrentL1A = table.Column<double>(type: "float", nullable: false),
                    ActLowerL1Kw = table.Column<double>(type: "float", nullable: false),
                    ActLowerBackdeliveryL1Kw = table.Column<double>(type: "float", nullable: false),
                    TextMessage = table.Column<string>(type: "varchar(255)", nullable: true),
                    Mbus1DeviceType = table.Column<byte>(type: "tinyint", nullable: false),
                    Mbus1MeterId = table.Column<string>(type: "varchar(255)", nullable: true),
                    Mbus1Value = table.Column<string>(type: "varchar(255)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Telegrams", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Telegrams_Meters_MeterId",
                        column: x => x.MeterId,
                        principalTable: "Meters",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PowerFailures_MeterId",
                table: "PowerFailures",
                column: "MeterId");

            migrationBuilder.CreateIndex(
                name: "IX_Telegrams_MeterId",
                table: "Telegrams",
                column: "MeterId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PowerFailures");

            migrationBuilder.DropTable(
                name: "Telegrams");

            migrationBuilder.DropTable(
                name: "Meters");
        }
    }
}
