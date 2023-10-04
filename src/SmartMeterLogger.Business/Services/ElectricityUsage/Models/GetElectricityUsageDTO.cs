using System;
using SmartMeterLogger.Data.Enums;

namespace SmartMeterLogger.Business.Models;

public class GetElectricityUsageDTO
{
    public int Id { get; set; }
    
    public DateTime Timestamp { get; set; }

    public int MeterId { get; set; }

    public float TotalDeliveryLow { get; set; }

    public float TotalDeliveryHigh { get; set; }

    public float TotalBackdeliveryLow { get; set; }

    public float TotalBackdeliveryHigh { get; set; }

    public TariffIndicator TariffIndicator { get; set; }

    public float ActualDelivery { get; set; }

    public float ActualBackdelivery { get; set; }

    public string TextMessage { get; set; }
}