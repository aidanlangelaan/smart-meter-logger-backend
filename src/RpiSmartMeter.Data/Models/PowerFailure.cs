using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using RpiSmartMeter.Data.Enums;

namespace RpiSmartMeter.Data.Models
{
    public class PowerFailure : EntityBase
    {
        [Required]
        [Column(TypeName = "int")]
        public int MeterId { get; set; }

        [Required]
        [Column(TypeName = "datetime2(7)")]
        public DateTime Timestamp { get; set; }

        [Required]
        [Column(TypeName = "int")]
        public int DurationInSeconds { get; set; }

        // Foreign keys
        [ForeignKey("MeterId")]
        public virtual Meter Meter { get; set; }
    }
}
