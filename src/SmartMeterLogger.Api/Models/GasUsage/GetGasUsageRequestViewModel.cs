using System;
using Microsoft.AspNetCore.Mvc;

namespace SmartMeterLogger.Api.Models;

public class GetGasUsageRequestViewModel
{
    public DateTime? From { get; set; }

    public DateTime? To { get; set; }

    public int? PageSize { get; set; } = 50;

    public int? Page { get; set; } = 0;
}