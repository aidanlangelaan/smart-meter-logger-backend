using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

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

        public virtual List<Telegram> Telegrams { get; set; }
    }
}
