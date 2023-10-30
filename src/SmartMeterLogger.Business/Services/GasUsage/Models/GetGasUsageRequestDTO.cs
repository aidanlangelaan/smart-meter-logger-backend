﻿using System;

namespace SmartMeterLogger.Business.Models;

public class GetGasUsageRequestDTO
{
    public DateTime? From { get; set; }

    public DateTime? To { get; set; }

    public int? PageSize { get; set; }

    public int? Page { get; set; }
}