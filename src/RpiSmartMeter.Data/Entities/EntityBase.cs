using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RpiSmartMeter.Data.Entities
{
    public abstract class EntityBase
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        [Column(TypeName = "datetime2(7)")]
        public DateTime CreatedOnAt { get; set; }

        [Required]
        [Column(TypeName = "datetime2(7)")]
        public DateTime UpdatedOnAt { get; set; }

        [Required]
        [Column(TypeName = "timestamp")]
        public Byte[] RowVersion { get; set; }
    }
}
