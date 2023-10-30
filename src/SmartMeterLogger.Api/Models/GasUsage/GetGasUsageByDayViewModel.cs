using System;
using SmartMeterLogger.Data.Enums;

namespace SmartMeterLogger.Api.Models;

public class GetGasUsageByDayViewModel
{
    public DateTime Timestamp { get; set; }

    public int MeterId { get; set; }

    public TariffIndicator TariffIndicator { get; set; }

    public decimal TotalDelivery { get; set; }
    
    public decimal DeltaTotalDelivery { get; set; }
}