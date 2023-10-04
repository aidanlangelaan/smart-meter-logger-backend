using System;
using System.Text.Json.Serialization;
using SmartMeterLogger.Data.Enums;

namespace SmartMeterLogger.Api.Models;

public class CreateTelegramViewModel
{
    [JsonPropertyName("dsmr_version")]
    public DSMRVersion DsmrVersion { get; set; }
        
    [JsonPropertyName("timestamp")]
    public DateTime Timestamp { get; set; }
        
    [JsonPropertyName("meter_id")]
    public string MeterId { get; set; }
        
    [JsonPropertyName("total_delivery_low_kwh")]
    public decimal TotalDeliveryLow { get; set; }
        
    [JsonPropertyName("total_delivery_high_kwh")]
    public decimal TotalDeliveryHigh { get; set; }
        
    [JsonPropertyName("total_backdelivery_low_kwh")]
    public decimal TotalBackdeliveryLow { get; set; }
        
    [JsonPropertyName("total_backdelivery_high_kwh")]
    public decimal TotalBackdeliveryHigh { get; set; }
        
    [JsonPropertyName("tariff_indicator")]
    public TariffIndicator TariffIndicator { get; set; }
        
    [JsonPropertyName("actual_delivery_kw")]
    public decimal ActualDelivery { get; set; }
        
    [JsonPropertyName("actual_backdelivery_kw")]
    public decimal ActualBackdelivery { get; set; }
        
    [JsonPropertyName("nr_powerfailures")]
    public int NrPowerfailures { get; set; }
        
    [JsonPropertyName("nr_powerfailures_long")]
    public int NrPowerfailuresLong { get; set; }
        
    [JsonPropertyName("powerfailure_log")]
    public string PowerfailureLog { get; set; }
        
    [JsonPropertyName("nr_voltage_sags_l1")]
    public int? NrVoltageSagsL1 { get; set; }
        
    [JsonPropertyName("nr_voltage_sags_l2")]
    public int? NrVoltageSagsL2 { get; set; }
        
    [JsonPropertyName("nr_voltage_sags_l3")]
    public int? NrVoltageSagsL3 { get; set; }
        
    [JsonPropertyName("nr_voltage_swells_l1")]
    public int NrVoltageSwellsL1 { get; set; }
        
    [JsonPropertyName("nr_voltage_swells_l2")]
    public int? NrVoltageSwellsL2 { get; set; }
        
    [JsonPropertyName("nr_voltage_swells_l3")]
    public int? NrVoltageSwellsL3 { get; set; }
        
    [JsonPropertyName("voltage_l1_v")]
    public decimal VoltageL1 { get; set; }
        
    [JsonPropertyName("voltage_l2_v")]
    public decimal? voltageL2 { get; set; }
        
    [JsonPropertyName("voltage_l3_v")]
    public decimal? VoltageL3 { get; set; }
        
    [JsonPropertyName("current_l1_a")]
    public decimal CurrentL1 { get; set; }
        
    [JsonPropertyName("current_l2_a")]
    public decimal? CurrentL2 { get; set; }
        
    [JsonPropertyName("current_l3_a")]
    public decimal? CurrentL3 { get; set; }
        
    [JsonPropertyName("act_power_l1_kw")]
    public decimal ActPowerL1 { get; set; }
        
    [JsonPropertyName("act_power_l2_kw")]
    public decimal? ActPowerL2 { get; set; }
        
    [JsonPropertyName("act_power_l3_kw")]
    public decimal? ActPowerL3 { get; set; }
        
    [JsonPropertyName("act_power_backdelivery_l1_kw")]
    public decimal ActPowerBackdeliveryL1 { get; set; }
        
    [JsonPropertyName("act_power_backdelivery_l2_kw")]
    public decimal? ActPowerBackdeliveryL2 { get; set; }
        
    [JsonPropertyName("act_power_backdelivery_l3_kw")]
    public decimal? ActPowerBackdeliveryL3 { get; set; }
        
    [JsonPropertyName("text_message")]
    public string TextMessage { get; set; }
        
    [JsonPropertyName("mbus1_device_type")]
    public MeterType? Mbus1DeviceType { get; set; }
        
    [JsonPropertyName("mbus1_meter_id")]
    public string Mbus1MeterId { get; set; }
        
    [JsonPropertyName("mbus1_value")]
    public decimal? Mbus1Value { get; set; }
        
    [JsonPropertyName("mbus2_device_type")]
    public MeterType? Mbus2DeviceType { get; set; }
        
    [JsonPropertyName("mbus2_meter_id")]
    public string Mbus2MeterId { get; set; }
        
    [JsonPropertyName("mbus2_value")]
    public decimal? Mbus2Value { get; set; }
        
    [JsonPropertyName("mbus3_device_type")]
    public MeterType? Mbus3DeviceType { get; set; }
        
    [JsonPropertyName("mbus3_meter_id")]
    public string Mbus3MeterId { get; set; }
        
    [JsonPropertyName("mbus3_value")]
    public decimal? Mbus3Value { get; set; }
        
    [JsonPropertyName("mbus4_device_type")]
    public MeterType? Mbus4DeviceType { get; set; }
        
    [JsonPropertyName("mbus4_meter_id")]
    public string Mbus4MeterId { get; set; }
        
    [JsonPropertyName("mbus4_value")]
    public decimal? Mbus4Value { get; set; }
}