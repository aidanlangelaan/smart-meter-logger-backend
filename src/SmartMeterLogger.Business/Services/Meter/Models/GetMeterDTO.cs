using SmartMeterLogger.Data.Enums;

namespace SmartMeterLogger.Business.Models;

public class GetMeterDTO
{
    public int Id { get; set; }
    
    public string SerialNumber { get; set; }

    public MeterType DeviceType { get; set; }
        
    public DSMRVersion? DsmrVersion { get; set; }
}