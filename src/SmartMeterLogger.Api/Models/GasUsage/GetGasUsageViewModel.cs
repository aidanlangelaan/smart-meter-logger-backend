using System;

namespace SmartMeterLogger.Api.Models;

public class GetGasUsageViewModel
{
    public int Id { get; set; }
    
    public DateTime Timestamp { get; set; }

    public int MeterId { get; set; }

    public decimal TotalDelivery { get; set; }
    
    public decimal DeltaTotalDelivery { get; set; }
}