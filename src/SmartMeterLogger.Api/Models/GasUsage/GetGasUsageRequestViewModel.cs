using System;
using Microsoft.AspNetCore.Mvc;

namespace SmartMeterLogger.Api.Models;

public class GetGasUsageRequestViewModel
{
    [FromRoute]
    public string SerialNumber { get; set; }
    
    [FromQuery]
    public DateTime? from { get; set; }
    
    [FromQuery]
    public DateTime? to  { get; set; }
    
    [FromQuery]
    public int? pageSize { get; set; }
    
    [FromQuery]
    public int? page  { get; set; }
}