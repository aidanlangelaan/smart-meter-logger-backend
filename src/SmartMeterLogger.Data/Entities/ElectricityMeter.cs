using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using SmartMeterLogger.Data.Enums;

namespace SmartMeterLogger.Data.Entities
{
    public class ElectricityMeter : AuditableEntity
    {
        [Required]
        [Column(TypeName = "tinyint")]
        public DSMRVersion? DsmrVersion { get; set; }
        
        [Required]
        [Column(TypeName = "int")]
        public int NrPowerfailures { get; set; }
        
        [Required]
        [Column(TypeName = "int")]
        public int? NrPowerfailuresLong { get; set; }
        
        [Column(TypeName = "varchar(255)")]
        public string PowerfailureLog { get; set; }
        
        [Required]
        [Column(TypeName = "int")]
        public int NrVoltageSagsL1 { get; set; }
        
        [Column(TypeName = "int")]
        public int? NrVoltageSagsL2 { get; set; }
        
        [Column(TypeName = "int")]
        public int? NrVoltageSagsL3 { get; set; }
        
        [Required]
        [Column(TypeName = "int")]
        public int NrVoltageSwellsL1 { get; set; }
        
        [Column(TypeName = "int")]
        public int? NrVoltageSwellsL2 { get; set; }
        
        [Column(TypeName = "int")]
        public int? NrVoltageSwellsL3 { get; set; }
        
        [Required] 
        [Column(TypeName = "int")] 
        public int MeterId { get; set; }

        // Foreign keys
        [ForeignKey("MeterId")] 
        public Meter Meter { get; set; }
    }
}
