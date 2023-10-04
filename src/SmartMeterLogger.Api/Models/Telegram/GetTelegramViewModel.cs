namespace SmartMeterLogger.Api.Models;

public class GetTelegramViewModel
{
    public GetElectricityUsageViewModel ElectricityUsage { get; set; }

    public GetGasUsageViewModel GasUsage { get; set; }
}