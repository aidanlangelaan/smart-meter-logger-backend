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

public class ElectricityUsageService : IElectricityUsageService
{
    private readonly SmartMeterLoggerDbContext _context;
    private readonly IMapper _mapper;

    public ElectricityUsageService(SmartMeterLoggerDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<IEnumerable<GetElectricityUsageDTO>> GetAll(string serialNumber,
        GetElectricityUsageRequestDTO model)
    {
        var query = _context.ElectricityUsages
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
            int skip = (model.Page.Value > 0 ? model.Page.Value - 1 : 0) * model.PageSize.Value;
            query = query.Skip(skip).Take(model.PageSize.Value);
        }

        var electricityUsages = await query
            .Include(u => u.Meter)
            .ToListAsync();

        return _mapper.Map<List<GetElectricityUsageDTO>>(electricityUsages);
    }

    public async Task<GetElectricityUsageDTO> GetById(string serialNumber, int usageId)
    {
        var electricityUsage = await _context.ElectricityUsages
            .Include(u => u.Meter)
            .FirstOrDefaultAsync(u => u.Meter.SerialNumber == serialNumber && u.Id == usageId);
        return _mapper.Map<GetElectricityUsageDTO>(electricityUsage);
    }

    public async Task<IEnumerable<GetElectricityUsageByDayDTO>> GetByDate(string serialNumber, DateTime date)
    {
        var fromDate = date.Date + new TimeSpan(0, 0, 0);
        var toDate = date.Date + new TimeSpan(23, 59, 59);

        var electricityUsages = await _context.ElectricityUsages
            .Where(u => u.Meter.SerialNumber == serialNumber
                        && u.Timestamp.Date >= fromDate
                        && u.Timestamp.Date <= toDate)
            .GroupBy(u => u.Timestamp.Hour)
            .Select(g => new ElectricityUsage()
            {
                Timestamp = g.First().Timestamp,
                MeterId = g.First().MeterId,
                TariffIndicator = g.First().TariffIndicator,
                TotalBackdeliveryHigh = g.OrderBy(u => u.Timestamp.Hour).Last().TotalBackdeliveryHigh,
                TotalBackdeliveryLow = g.OrderBy(u => u.Timestamp.Hour).Last().TotalBackdeliveryLow,
                TotalDeliveryHigh = g.OrderBy(u => u.Timestamp.Hour).Last().TotalDeliveryHigh,
                TotalDeliveryLow = g.OrderBy(u => u.Timestamp.Hour).Last().TotalDeliveryLow,
                DeltaTotalBackdeliveryHigh = g.Sum(u => u.DeltaTotalBackdeliveryHigh),
                DeltaTotalBackdeliveryLow = g.Sum(u => u.DeltaTotalBackdeliveryLow),
                DeltaTotalDeliveryHigh = g.Sum(u => u.DeltaTotalDeliveryHigh),
                DeltaTotalDeliveryLow = g.Sum(u => u.DeltaTotalDeliveryLow),
            })
            .ToListAsync();

        // format hours
        for (var i = 0; i <= 23; i++)
        {
            // add missing hours of for the day
            if (electricityUsages.Count <= i)
            {
                var previous = electricityUsages[i - 1];
                electricityUsages.Add(new ElectricityUsage()
                {
                    Timestamp = previous.Timestamp.Date + new TimeSpan(i, 0, 0),
                    DeltaTotalBackdeliveryHigh = 0,
                    DeltaTotalBackdeliveryLow = 0,
                    DeltaTotalDeliveryHigh = 0,
                    DeltaTotalDeliveryLow = 0,
                });
                continue;
            }

            var usage = electricityUsages[i];
            usage.Timestamp = usage.Timestamp.Date + new TimeSpan(usage.Timestamp.Hour, 0, 0);
        }

        return _mapper.Map<IEnumerable<GetElectricityUsageByDayDTO>>(electricityUsages);
    }

    public async Task<IEnumerable<GetElectricityUsageDTO>> GetByMonth(string serialNumber, int month)
    {
        throw new NotImplementedException();
    }
}