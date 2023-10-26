using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Smartmeter.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddDeltaPropertiesToUsageTables : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "voltageL2",
                table: "ElectricityUsages",
                newName: "VoltageL2");

            migrationBuilder.AddColumn<decimal>(
                name: "DeltaTotalDelivery",
                table: "GasUsages",
                type: "decimal(10,3)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "DeltaActPowerBackdeliveryL1",
                table: "ElectricityUsages",
                type: "decimal(10,3)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "DeltaActPowerBackdeliveryL2",
                table: "ElectricityUsages",
                type: "decimal(10,3)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "DeltaActPowerBackdeliveryL3",
                table: "ElectricityUsages",
                type: "decimal(10,3)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "DeltaActPowerL1",
                table: "ElectricityUsages",
                type: "decimal(10,3)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "DeltaActPowerL2",
                table: "ElectricityUsages",
                type: "decimal(10,3)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "DeltaActPowerL3",
                table: "ElectricityUsages",
                type: "decimal(10,3)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "DeltaActualBackdelivery",
                table: "ElectricityUsages",
                type: "decimal(10,3)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "DeltaActualDelivery",
                table: "ElectricityUsages",
                type: "decimal(10,3)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "DeltaCurrentL1",
                table: "ElectricityUsages",
                type: "decimal(10,3)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "DeltaCurrentL2",
                table: "ElectricityUsages",
                type: "decimal(10,3)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "DeltaCurrentL3",
                table: "ElectricityUsages",
                type: "decimal(10,3)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "DeltaTotalBackdeliveryHigh",
                table: "ElectricityUsages",
                type: "decimal(10,3)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "DeltaTotalBackdeliveryLow",
                table: "ElectricityUsages",
                type: "decimal(10,3)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "DeltaTotalDeliveryHigh",
                table: "ElectricityUsages",
                type: "decimal(10,3)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "DeltaTotalDeliveryLow",
                table: "ElectricityUsages",
                type: "decimal(10,3)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "DeltaVoltageL1",
                table: "ElectricityUsages",
                type: "decimal(10,3)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "DeltaVoltageL2",
                table: "ElectricityUsages",
                type: "decimal(10,3)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "DeltaVoltageL3",
                table: "ElectricityUsages",
                type: "decimal(10,3)",
                nullable: false,
                defaultValue: 0m);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DeltaTotalDelivery",
                table: "GasUsages");

            migrationBuilder.DropColumn(
                name: "DeltaActPowerBackdeliveryL1",
                table: "ElectricityUsages");

            migrationBuilder.DropColumn(
                name: "DeltaActPowerBackdeliveryL2",
                table: "ElectricityUsages");

            migrationBuilder.DropColumn(
                name: "DeltaActPowerBackdeliveryL3",
                table: "ElectricityUsages");

            migrationBuilder.DropColumn(
                name: "DeltaActPowerL1",
                table: "ElectricityUsages");

            migrationBuilder.DropColumn(
                name: "DeltaActPowerL2",
                table: "ElectricityUsages");

            migrationBuilder.DropColumn(
                name: "DeltaActPowerL3",
                table: "ElectricityUsages");

            migrationBuilder.DropColumn(
                name: "DeltaActualBackdelivery",
                table: "ElectricityUsages");

            migrationBuilder.DropColumn(
                name: "DeltaActualDelivery",
                table: "ElectricityUsages");

            migrationBuilder.DropColumn(
                name: "DeltaCurrentL1",
                table: "ElectricityUsages");

            migrationBuilder.DropColumn(
                name: "DeltaCurrentL2",
                table: "ElectricityUsages");

            migrationBuilder.DropColumn(
                name: "DeltaCurrentL3",
                table: "ElectricityUsages");

            migrationBuilder.DropColumn(
                name: "DeltaTotalBackdeliveryHigh",
                table: "ElectricityUsages");

            migrationBuilder.DropColumn(
                name: "DeltaTotalBackdeliveryLow",
                table: "ElectricityUsages");

            migrationBuilder.DropColumn(
                name: "DeltaTotalDeliveryHigh",
                table: "ElectricityUsages");

            migrationBuilder.DropColumn(
                name: "DeltaTotalDeliveryLow",
                table: "ElectricityUsages");

            migrationBuilder.DropColumn(
                name: "DeltaVoltageL1",
                table: "ElectricityUsages");

            migrationBuilder.DropColumn(
                name: "DeltaVoltageL2",
                table: "ElectricityUsages");

            migrationBuilder.DropColumn(
                name: "DeltaVoltageL3",
                table: "ElectricityUsages");

            migrationBuilder.RenameColumn(
                name: "VoltageL2",
                table: "ElectricityUsages",
                newName: "voltageL2");
        }
    }
}
