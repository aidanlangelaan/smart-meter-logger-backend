using System.Text.Json.Serialization;

namespace SmartMeterLogger.Api.Models
{
    public class CreateTelegramViewModel
    {
        [JsonPropertyName("dsmr_version")]
        public string DsmrVersion { get; set; }
        
        [JsonPropertyName("timestamp")]
        public string Timestamp { get; set; }
        
        [JsonPropertyName("meter_id")]
        public string MeterId { get; set; }
        
        [JsonPropertyName("total_delivery_low_kwh")]
        public string TotalDeliveryLowKwh { get; set; }
        
        [JsonPropertyName("total_delivery_high_kwh")]
        public string TotalDeliveryHighKwh { get; set; }
        
        [JsonPropertyName("total_backdelivery_low_kwh")]
        public string TotalBackdeliveryLowKwh { get; set; }
        
        [JsonPropertyName("total_backdelivery_high_kwh")]
        public string TotalBackdeliveryHighKwh { get; set; }
        
        [JsonPropertyName("tariff_indicator")]
        public string TariffIndicator { get; set; }
        
        [JsonPropertyName("actual_delivery_kw")]
        public string ActualDeliveryKw { get; set; }
        
        [JsonPropertyName("actual_backdelivery_kw")]
        public string ActualBackdeliveryKw { get; set; }
        
        [JsonPropertyName("nr_powerfailures")]
        public string NrPowerfailures { get; set; }
        
        [JsonPropertyName("nr_powerfailures_long")]
        public string NrPowerfailuresLong { get; set; }
        
        [JsonPropertyName("powerfailure_log")]
        public string PowerfailureLog { get; set; }
        
        [JsonPropertyName("nr_voltage_sags_l1")]
        public string NrVoltageSagsL1 { get; set; }
        
        [JsonPropertyName("nr_voltage_sags_l2")]
        public string NrVoltageSagsL2 { get; set; }
        
        [JsonPropertyName("nr_voltage_sags_l3")]
        public string NrVoltageSagsL3 { get; set; }
        
        [JsonPropertyName("nr_voltage_swells_l1")]
        public string NrVoltageSwellsL1 { get; set; }
        
        [JsonPropertyName("nr_voltage_swells_l2")]
        public string NrVoltageSwellsL2 { get; set; }
        
        [JsonPropertyName("nr_voltage_swells_l3")]
        public string NrVoltageSwellsL3 { get; set; }
        
        [JsonPropertyName("voltage_l1_v")]
        public string VoltageL1V { get; set; }
        
        [JsonPropertyName("voltage_l2_v")]
        public string voltageL2V { get; set; }
        
        [JsonPropertyName("voltage_l3_v")]
        public string VoltageL3V { get; set; }
        
        [JsonPropertyName("current_l1_a {")]
        public string CurrentL1A { get; set; }
        
        [JsonPropertyName("current_l2_a")]
        public string CurrentL2A { get; set; }
        
        [JsonPropertyName("current_l3_a")]
        public string CurrentL3A { get; set; }
        
        [JsonPropertyName("act_power_l1_kw")]
        public string ActPowerL1Kw { get; set; }
        
        [JsonPropertyName("act_power_l2_kw")]
        public string ActPowerL2Kw { get; set; }
        
        [JsonPropertyName("act_power_l3_kw")]
        public string ActPowerL3Kw { get; set; }
        
        [JsonPropertyName("act_power_backdelivery_l1_kw")]
        public string ActPowerBackdeliveryL1Kw { get; set; }
        
        [JsonPropertyName("act_power_backdelivery_l2_kw")]
        public string ActPowerBackdeliveryL2Kw { get; set; }
        
        [JsonPropertyName("act_power_backdelivery_l3_kw")]
        public string ActPowerBackdeliveryL3Kw { get; set; }
        
        [JsonPropertyName("text_message")]
        public string TextMessage { get; set; }
        
        [JsonPropertyName("mbus1_device_type")]
        public string Mbus1DeviceType { get; set; }
        
        [JsonPropertyName("mbus1_meter_id")]
        public string Mbus1MeterId { get; set; }
        
        [JsonPropertyName("mbus1_value")]
        public string Mbus1Value { get; set; }
        
        [JsonPropertyName("mbus2_device_type")]
        public string Mbus2DeviceType { get; set; }
        
        [JsonPropertyName("mbus2_meter_id")]
        public string Mbus2MeterId { get; set; }
        
        [JsonPropertyName("mbus2_value")]
        public string Mbus2Value { get; set; }
        
        [JsonPropertyName("mbus3_device_type")]
        public string Mbus3DeviceType { get; set; }
        
        [JsonPropertyName("mbus3_meter_id")]
        public string Mbus3MeterId { get; set; }
        
        [JsonPropertyName("mbus3_value")]
        public string Mbus3Value { get; set; }
        
        [JsonPropertyName("mbus4_device_type")]
        public string Mbus4DeviceType { get; set; }
        
        [JsonPropertyName("mbus4_meter_id")]
        public string Mbus4MeterId { get; set; }
        
        [JsonPropertyName("mbus4_value")]
        public string Mbus4Value { get; set; }
    }
}
