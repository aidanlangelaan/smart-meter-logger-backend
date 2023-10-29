using System;
using Microsoft.AspNetCore.Mvc;

namespace SmartMeterLogger.Api.Models;

public class GetGasUsageRequestViewModel
{
    public DateTime? from { get; set; }
    
    public DateTime? to  { get; set; }
    
    public int? pageSize { get; set; }
    
    public int? page  { get; set; }
}