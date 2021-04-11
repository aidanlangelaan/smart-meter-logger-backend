using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using RpiSmartMeter.Data.Enums;

namespace RpiSmartMeter.Data.Entities
{
    public class GasUsage : EntityBase
    {
        [Required]
        [Column(TypeName = "datetime2(7)")]
        public DateTime Timestamp { get; set; }

        [Required]
        [Column(TypeName = "int")]
        public int MeterId { get; set; }

        [Column(TypeName = "varchar(255)")]
        public string TotalDelivery { get; set; }


        // Foreign keys
        [ForeignKey("MeterId")]
        public Meter Meter { get; set; }
    }
}
