using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using SmartMeterLogger.Business.Interfaces;
using SmartMeterLogger.Business.Models;
using SmartMeterLogger.Data;

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

    public async Task<List<GetElectricityUsageDTO>> GetAll(string serialNumber,
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

    public async Task<GetElectricityUsageDTO> GetById(string meterId, int usageId)
    {
        var electricityUsage = await _context.ElectricityUsages.FirstOrDefaultAsync(t => t.Id == usageId);
        return _mapper.Map<GetElectricityUsageDTO>(electricityUsage);
    }
}