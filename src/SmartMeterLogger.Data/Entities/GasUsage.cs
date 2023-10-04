using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SmartMeterLogger.Data.Entities
{
    public class GasUsage : AuditableEntity
    {
        [Required]
        [Column(TypeName = "int")]
        public int MeterId { get; set; }
        
        [Required]
        [Column(TypeName = "datetime")]
        public DateTime Timestamp { get; set; }

        [Column(TypeName = "decimal(10,3)")]
        public decimal TotalDelivery { get; set; }

        // Foreign keys
        [ForeignKey("MeterId")]
        public Meter Meter { get; set; }
    }
}
