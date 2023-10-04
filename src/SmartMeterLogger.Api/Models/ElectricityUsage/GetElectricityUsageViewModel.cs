using System;
using SmartMeterLogger.Data.Enums;

namespace SmartMeterLogger.Api.Models;

public class GetElectricityUsageViewModel
{
    public int Id { get; set; }
    
    public DateTime Timestamp { get; set; }

    public int MeterId { get; set; }

    public decimal TotalDeliveryLow { get; set; }

    public decimal TotalDeliveryHigh { get; set; }

    public decimal TotalBackdeliveryLow { get; set; }

    public decimal TotalBackdeliveryHigh { get; set; }

    public TariffIndicator TariffIndicator { get; set; }

    public decimal ActualDelivery { get; set; }

    public decimal ActualBackdelivery { get; set; }

    public string TextMessage { get; set; }
}