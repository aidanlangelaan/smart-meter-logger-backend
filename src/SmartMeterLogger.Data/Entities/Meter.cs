using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using SmartMeterLogger.Data.Enums;

namespace SmartMeterLogger.Data.Entities
{
    public class Meter : AuditableEntity
    {
        [Required]
        [Column(TypeName = "varchar(255)")]
        public string SerialNumber { get; set; }

        [Column(TypeName = "tinyint")]
        public MeterType DeviceType { get; set; }

        // Relations
        public List<ElectricityUsage> ElectricityUsages { get; set; }

        public List<GasUsage> GasUsages { get; set; }
    }
}
