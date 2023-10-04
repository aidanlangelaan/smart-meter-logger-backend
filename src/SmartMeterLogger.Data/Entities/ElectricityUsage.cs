﻿using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using SmartMeterLogger.Data.Enums;

namespace SmartMeterLogger.Data.Entities;

public class ElectricityUsage : AuditableEntity
{
    [Required]
    [Column(TypeName = "decimal(10,3)")]
    public decimal ActPowerL1 { get; set; }
        
    [Column(TypeName = "decimal(10,3)")]
    public decimal? ActPowerL2 { get; set; }
        
    [Column(TypeName = "decimal(10,3)")]
    public decimal? ActPowerL3 { get; set; }
        
    [Required]
    [Column(TypeName = "decimal(10,3)")]
    public decimal ActPowerBackdeliveryL1 { get; set; }
        
    [Column(TypeName = "decimal(10,3)")]
    public decimal? ActPowerBackdeliveryL2 { get; set; }
        
    [Column(TypeName = "decimal(10,3)")]
    public decimal? ActPowerBackdeliveryL3 { get; set; }
    
    [Required]
    [Column(TypeName = "decimal(10,3)")]
    public decimal ActualBackdelivery { get; set; }

    [Required]
    [Column(TypeName = "decimal(10,3)")]
    public decimal ActualDelivery { get; set; }

    [Required]
    [Column(TypeName = "decimal(10,3)")]
    public decimal CurrentL1 { get; set; }
        
    [Column(TypeName = "decimal(10,3)")]
    public decimal? CurrentL2 { get; set; }
        
    [Column(TypeName = "decimal(10,3)")]
    public decimal? CurrentL3 { get; set; }
    
    [Required] 
    [Column(TypeName = "int")] 
    public int MeterId { get; set; }
    
    [Required]
    [Column(TypeName = "tinyint")]
    public TariffIndicator TariffIndicator { get; set; }

    [Column(TypeName = "varchar(255)")] 
    public string TextMessage { get; set; }
    
    [Required]
    [Column(TypeName = "datetime")]
    public DateTime Timestamp { get; set; }
    
    [Required]
    [Column(TypeName = "decimal(10,3)")]
    public decimal TotalBackdeliveryLow { get; set; }

    [Required]
    [Column(TypeName = "decimal(10,3)")]
    public decimal TotalBackdeliveryHigh { get; set; }
    
    [Required]
    [Column(TypeName = "decimal(10,3)")]
    public decimal TotalDeliveryHigh { get; set; }
    
    [Required]
    [Column(TypeName = "decimal(10,3)")]
    public decimal TotalDeliveryLow { get; set; }
    
    [Required]
    [Column(TypeName = "decimal(10,3)")]
    public decimal VoltageL1 { get; set; }
        
    [Column(TypeName = "decimal(10,3)")]
    public decimal? voltageL2 { get; set; }
        
    [Column(TypeName = "decimal(10,3)")]
    public decimal? VoltageL3 { get; set; }

    // Foreign keys
    [ForeignKey("MeterId")] 
    public Meter Meter { get; set; }
}