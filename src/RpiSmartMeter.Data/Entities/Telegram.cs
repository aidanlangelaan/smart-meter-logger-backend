using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using RpiSmartMeter.Data.Enums;

namespace RpiSmartMeter.Data.Entities
{
    public class Telegram : EntityBase
    {
        [Required]
        [Column(TypeName = "datetime2(7)")]
        public DateTime Timestamp { get; set; }

        [Required]
        [Column(TypeName = "int")]
        public int MeterId { get; set; }

        [Required]
        [Column(TypeName = "float")]
        public double TotalDeliveryLowKwh { get; set; }

        [Required]
        [Column(TypeName = "float")]
        public double TotalDeliveryHighKwh { get; set; }

        [Required]
        [Column(TypeName = "float")]
        public double TotalBackdeliveryLowKwh { get; set; }

        [Required]
        [Column(TypeName = "float")]
        public double TotalBackdeliveryHighKwh { get; set; }

        [Required]
        [Column(TypeName = "tinyint")]
        public TariffIndicator TariffIndicator { get; set; }

        [Required]
        [Column(TypeName = "float")]
        public double ActualDeliveryKw { get; set; }

        [Required]
        [Column(TypeName = "float")]
        public double ActualBackdeliveryKw { get; set; }

        [Required]
        [Column(TypeName = "int")]
        public int NrPowerfailures { get; set; }

        [Required]
        [Column(TypeName = "int")]
        public int NrPowerfailuresLong { get; set; }

        //public string PowerfailureLog { get; set; }

        [Column(TypeName = "int")]
        public int NrVoltageSagsL1 { get; set; }

        [Column(TypeName = "int")]
        public int NrVoltageSwellsL1 { get; set; }

        [Column(TypeName = "float")]
        public double VoltageL1V { get; set; }

        [Column(TypeName = "float")]
        public double CurrentL1A { get; set; }

        [Column(TypeName = "float")]
        public double ActLowerL1Kw { get; set; }

        [Column(TypeName = "float")]
        public double ActLowerBackdeliveryL1Kw { get; set; }

        [Column(TypeName = "varchar(255)")]
        public string TextMessage { get; set; }

        [Column(TypeName = "tinyint")]
        public MeterType Mbus1DeviceType { get; set; }

        [Column(TypeName = "varchar(255)")]
        public string Mbus1MeterId { get; set; }

        [Column(TypeName = "varchar(255)")]
        public string Mbus1Value { get; set; }

        // Foreign keys
        [ForeignKey("MeterId")]
        public Meter Meter { get; set; }
    }
}
