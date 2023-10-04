using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using SmartMeterLogger.Data.Enums;

namespace SmartMeterLogger.Data.Entities
{
    public class Meter : AuditableEntity
    {
        [Column(TypeName = "tinyint")]
        public MeterType DeviceType { get; set; }
        
        [Required]
        [Column(TypeName = "varchar(34)")]
        public string SerialNumber { get; set; }

        // Relations
        public ElectricityMeter ElectricityMeter { get; set; }
    }
}
