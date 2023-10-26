using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using SmartMeterLogger.Business.Interfaces;
using SmartMeterLogger.Business.Models;
using SmartMeterLogger.Data;

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

    public async Task<List<GetGasUsageDTO>> GetAll(string serialNumber,
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

        var electricityUsages = await query
            .Include(u => u.Meter)
            .ToListAsync();

        return _mapper.Map<List<GetGasUsageDTO>>(electricityUsages);
    }

    public async Task<GetGasUsageDTO> GetById(string meterId, int usageId)
    {
        var electricityUsage = await _context.GasUsages.FirstOrDefaultAsync(t => t.Id == usageId);
        return _mapper.Map<GetGasUsageDTO>(electricityUsage);
    }
}