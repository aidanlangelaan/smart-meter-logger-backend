namespace SmartMeterLogger.Business.Models;

public class GetTelegramDTO
{
    public GetElectricityUsageDTO ElectricityUsage { get; set; }
    
    public GetGasUsageDTO GasUsage { get; set; }
}