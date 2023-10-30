using System;
using SmartMeterLogger.Data.Enums;

namespace SmartMeterLogger.Business.Models;

public class GetGasUsageByDayDTO
{
    public DateTime Timestamp { get; set; }

    public int MeterId { get; set; }

    public TariffIndicator TariffIndicator { get; set; }

    public decimal TotalDelivery { get; set; }
    
    public decimal DeltaTotalDelivery { get; set; }
}