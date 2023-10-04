using System;

namespace SmartMeterLogger.Business.Models;

public class GetGasUsageDTO
{
    public int Id { get; set; }
    
    public DateTime Timestamp { get; set; }

    public int MeterId { get; set; }

    public float TotalDelivery { get; set; }
}