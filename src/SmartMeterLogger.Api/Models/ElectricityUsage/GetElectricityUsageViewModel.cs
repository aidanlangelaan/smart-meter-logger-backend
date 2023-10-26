using System;
using SmartMeterLogger.Data.Enums;

namespace SmartMeterLogger.Api.Models;

public class GetElectricityUsageViewModel
{
    public int Id { get; set; }
    
    public DateTime Timestamp { get; set; }

    public int MeterId { get; set; }

    public decimal ActPowerL1 { get; set; }

    public decimal DeltaActPowerL1 { get; set; }

    public decimal? ActPowerL2 { get; set; }

    public decimal DeltaActPowerL2 { get; set; }

    public decimal? ActPowerL3 { get; set; }

    public decimal DeltaActPowerL3 { get; set; }

    public decimal ActPowerBackdeliveryL1 { get; set; }

    public decimal DeltaActPowerBackdeliveryL1 { get; set; }

    public decimal? ActPowerBackdeliveryL2 { get; set; }

    public decimal DeltaActPowerBackdeliveryL2 { get; set; }

    public decimal? ActPowerBackdeliveryL3 { get; set; }

    public decimal DeltaActPowerBackdeliveryL3 { get; set; }

    public decimal ActualBackdelivery { get; set; }

    public decimal DeltaActualBackdelivery { get; set; }

    public decimal ActualDelivery { get; set; }

    public decimal DeltaActualDelivery { get; set; }

    public decimal CurrentL1 { get; set; }

    public decimal DeltaCurrentL1 { get; set; }

    public decimal? CurrentL2 { get; set; }

    public decimal DeltaCurrentL2 { get; set; }

    public decimal? CurrentL3 { get; set; }

    public decimal DeltaCurrentL3 { get; set; }

    public TariffIndicator TariffIndicator { get; set; }

    public string TextMessage { get; set; }

    public decimal TotalBackdeliveryLow { get; set; }

    public decimal DeltaTotalBackdeliveryLow { get; set; }

    public decimal TotalBackdeliveryHigh { get; set; }

    public decimal DeltaTotalBackdeliveryHigh { get; set; }

    public decimal TotalDeliveryHigh { get; set; }

    public decimal DeltaTotalDeliveryHigh { get; set; }

    public decimal TotalDeliveryLow { get; set; }

    public decimal DeltaTotalDeliveryLow { get; set; }

    public decimal VoltageL1 { get; set; }

    public decimal DeltaVoltageL1 { get; set; }

    public decimal? VoltageL2 { get; set; }

    public decimal DeltaVoltageL2 { get; set; }

    public decimal? VoltageL3 { get; set; }

    public decimal DeltaVoltageL3 { get; set; }
}