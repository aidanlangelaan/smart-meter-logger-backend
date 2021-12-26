using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using RpiSmartMeter.Data.Enums;

namespace RpiSmartMeter.Data.Entities
{
    public class ElectricityUsage : AuditableEntity
    {
        [Required]
        [Column(TypeName = "datetime")]
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

        [Column(TypeName = "varchar(255)")]
        public string TextMessage { get; set; }


        // Foreign keys
        [ForeignKey("MeterId")]
        public Meter Meter { get; set; }
    }
}
