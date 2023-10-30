using System;
using Microsoft.AspNetCore.Mvc;

namespace SmartMeterLogger.Api.Models;

public class GetElectricityUsageRequestViewModel
{
    public DateTime? From { get; set; }

    public DateTime? To { get; set; }

    public int? PageSize { get; set; }

    public int? Page { get; set; }
}