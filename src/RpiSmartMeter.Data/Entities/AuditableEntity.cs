using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RpiSmartMeter.Data.Entities
{
    public class AuditableEntity : EntityBase
    {
        [Required]
        [Column(TypeName = "datetime")]
        public DateTime CreatedOnAt { get; set; }

        [Required]
        [Column(TypeName = "datetime")]
        public DateTime UpdatedOnAt { get; set; }
    }
}
