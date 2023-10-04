using System;
using SmartMeterLogger.Data.Enums;

namespace SmartMeterLogger.Business.Models;

public class CreateTelegramDTO
{
    public DSMRVersion DsmrVersion { get; set; }

    public DateTime Timestamp { get; set; }

    public string MeterId { get; set; }

    public decimal TotalDeliveryLow { get; set; }

    public decimal TotalDeliveryHigh { get; set; }

    public decimal TotalBackdeliveryLow { get; set; }

    public decimal TotalBackdeliveryHigh { get; set; }

    public TariffIndicator TariffIndicator { get; set; }

    public decimal ActualDelivery { get; set; }

    public decimal ActualBackdelivery { get; set; }

    public int NrPowerfailures { get; set; }

    public int NrPowerfailuresLong { get; set; }

    public string PowerfailureLog { get; set; }

    public int? NrVoltageSagsL1 { get; set; }

    public int? NrVoltageSagsL2 { get; set; }

    public int? NrVoltageSagsL3 { get; set; }

    public int NrVoltageSwellsL1 { get; set; }

    public int? NrVoltageSwellsL2 { get; set; }

    public int? NrVoltageSwellsL3 { get; set; }

    public decimal VoltageL1 { get; set; }

    public decimal? voltageL2 { get; set; }

    public decimal? VoltageL3 { get; set; }

    public decimal CurrentL1 { get; set; }

    public decimal? CurrentL2 { get; set; }

    public decimal? CurrentL3 { get; set; }

    public decimal ActPowerL1 { get; set; }

    public decimal? ActPowerL2 { get; set; }

    public decimal? ActPowerL3 { get; set; }

    public decimal ActPowerBackdeliveryL1 { get; set; }

    public decimal? ActPowerBackdeliveryL2 { get; set; }

    public decimal? ActPowerBackdeliveryL3 { get; set; }

    public string TextMessage { get; set; }

    public MeterType? Mbus1DeviceType { get; set; }

    public string Mbus1MeterId { get; set; }

    public decimal? Mbus1Value { get; set; }

    public MeterType? Mbus2DeviceType { get; set; }

    public string Mbus2MeterId { get; set; }

    public decimal? Mbus2Value { get; set; }

    public MeterType? Mbus3DeviceType { get; set; }

    public string Mbus3MeterId { get; set; }

    public decimal? Mbus3Value { get; set; }

    public MeterType? Mbus4DeviceType { get; set; }

    public string Mbus4MeterId { get; set; }

    public decimal? Mbus4Value { get; set; }
}