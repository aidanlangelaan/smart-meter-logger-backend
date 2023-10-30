using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using SmartMeterLogger.Business.Interfaces;
using SmartMeterLogger.Business.Models;
using SmartMeterLogger.Data;
using SmartMeterLogger.Data.Entities;

namespace SmartMeterLogger.Business.Services;

public class GasUsageService : IGasUsageService
{
    private readonly SmartMeterLoggerDbContext _context;
    private readonly IMapper _mapper;

    public GasUsageService(SmartMeterLoggerDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<IEnumerable<GetGasUsageDTO>> GetAll(string serialNumber,
        GetGasUsageRequestDTO model)
    {
        var query = _context.GasUsages
            .Where(u => u.Meter.SerialNumber == serialNumber)
            .AsQueryable();

        if (model.From.HasValue)
        {
            query = query.Where(u => u.Timestamp >= model.From.Value);
        }

        if (model.To.HasValue)
        {
            query = query.Where(u => u.Timestamp <= model.To.Value);
        }

        if (model.Page.HasValue && model.PageSize.HasValue)
        {
            int skip = (model.Page.Value - 1) * model.PageSize.Value;
            query = query.Skip(skip).Take(model.PageSize.Value);
        }

        var gasUsages = await query
            .Include(u => u.Meter)
            .ToListAsync();

        return _mapper.Map<List<GetGasUsageDTO>>(gasUsages);
    }

    public async Task<GetGasUsageDTO> GetById(string serialNumber, int usageId)
    {
        var gasUsage = await _context.GasUsages
            .Include(u => u.Meter)
            .FirstOrDefaultAsync(u => u.Meter.SerialNumber == serialNumber && u.Id == usageId);
        return _mapper.Map<GetGasUsageDTO>(gasUsage);
    }
    
    public async Task<IEnumerable<GetGasUsageByDayDTO>> GetByDate(string serialNumber, DateTime date)
    {
        var fromDate = date.Date + new TimeSpan(0, 0, 0);
        var toDate = date.Date + new TimeSpan(23, 59, 59);

        var gasUsages = await _context.GasUsages
            .Where(u => u.Meter.SerialNumber == serialNumber
                        && u.Timestamp.Date >= fromDate
                        && u.Timestamp.Date <= toDate)
            .GroupBy(u => u.Timestamp.Hour)
            .Select(g => new GasUsage()
            {
                Timestamp = g.First().Timestamp,
                MeterId = g.First().MeterId,
                TotalDelivery = g.OrderBy(u => u.Timestamp.Hour).Last().TotalDelivery,
                DeltaTotalDelivery = g.OrderBy(u => u.Timestamp.Hour).Last().DeltaTotalDelivery,
            })
            .ToListAsync();

        // format hours
        for (var i = 0; i <= 23; i++)
        {
            // add missing hours of for the day
            if (gasUsages.Count <= i)
            {
                var previous = gasUsages[i - 1];
                gasUsages.Add(new GasUsage()
                {
                    Timestamp = previous.Timestamp.Date + new TimeSpan(i, 0, 0),
                    TotalDelivery = 0,
                    DeltaTotalDelivery = 0,
                });
                continue;
            }

            var usage = gasUsages[i];
            usage.Timestamp = usage.Timestamp.Date + new TimeSpan(usage.Timestamp.Hour, 0, 0);
        }

        return _mapper.Map<IEnumerable<GetGasUsageByDayDTO>>(gasUsages);
    }
}