using SmartMeterLogger.Data.Enums;

namespace SmartMeterLogger.Api.Models;

public class GetMeterViewModel
{
    public int Id { get; set; }
    
    public string SerialNumber { get; set; }

    public MeterType DeviceType { get; set; }
        
    public DSMRVersion DsmrVersion { get; set; }
}