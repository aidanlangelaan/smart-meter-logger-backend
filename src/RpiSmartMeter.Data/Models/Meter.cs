using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using RpiSmartMeter.Data.Enums;

namespace RpiSmartMeter.Data.Models
{
    public class Meter : EntityBase
    {
        [Required]
        [Column(TypeName = "varchar(255)")]
        public string SerialNumber { get; set; }

        [Required]
        [Column(TypeName = "float")]
        public double DsmrVersion { get; set; }

        // Relations
        public virtual List<Telegram> Telegrams { get; set; }

        public virtual List<PowerFailure> PowerFailures { get; set; }
    }
}
