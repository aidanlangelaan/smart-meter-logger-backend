using System;
using SmartMeterLogger.Data.Enums;

namespace SmartMeterLogger.Business.Models;

public class GetElectricityUsageByDayDTO
{
    public DateTime Timestamp { get; set; }

    public int MeterId { get; set; }

    public TariffIndicator TariffIndicator { get; set; }

    public decimal TotalBackdeliveryLow { get; set; }

    public decimal DeltaTotalBackdeliveryLow { get; set; }

    public decimal TotalBackdeliveryHigh { get; set; }

    public decimal DeltaTotalBackdeliveryHigh { get; set; }

    public decimal TotalDeliveryHigh { get; set; }

    public decimal DeltaTotalDeliveryHigh { get; set; }

    public decimal TotalDeliveryLow { get; set; }

    public decimal DeltaTotalDeliveryLow { get; set; }
}