using System;

namespace SmartMeterLogger.Business.Models;

public class GetElectricityUsageRequestDTO
{
    public DateTime? From { get; set; } 
    public DateTime? To  { get; set; }
    public int? PageSize { get; set; } = 50; 
    public int? Page  { get; set; }
}