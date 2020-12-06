using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RpiSmartMeter.Data.Models
{
    public class Telegram : EntityBase
    {
        [Required]
        [Column(TypeName = "float")]
        public string TotalDeliveryLowKwh { get; set; }

        [Required]
        [Column(TypeName = "float")]
        public string TotalDeliveryHighKwh { get; set; }

        [Required]
        [Column(TypeName = "float")]
        public string TotalBackdeliveryLowKwh { get; set; }

        [Required]
        [Column(TypeName = "float")]
        public string TotalBackdeliveryHighKwh { get; set; }





        public virtual Meter Meter { get; set; }
    }
}
