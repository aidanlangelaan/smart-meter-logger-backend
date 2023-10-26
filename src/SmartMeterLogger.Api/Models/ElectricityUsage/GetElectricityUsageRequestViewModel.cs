using System;

namespace SmartMeterLogger.Api.Models;

public class GetElectricityUsageRequestViewModel
{
    public DateTime? from { get; set; } 
    public DateTime? to  { get; set; }
    public int? pageSize { get; set; } 
    public int? page  { get; set; }
}