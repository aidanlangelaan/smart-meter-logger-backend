using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using SmartMeterLogger.Business.Interfaces;
using SmartMeterLogger.Business.Models;
using SmartMeterLogger.Data;

namespace SmartMeterLogger.Business.Services;

public class MeterService : IMeterService
{
    private readonly SmartMeterLoggerDbContext _context;
    private readonly IMapper _mapper;

    public MeterService(SmartMeterLoggerDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<IEnumerable<GetMeterDTO>> GetAll()
    {
        var meters = await _context.Meters
            .Include(m => m.ElectricityMeter)
            .ToListAsync();
        return _mapper.Map<IEnumerable<GetMeterDTO>>(meters);
    }

    public async Task<GetMeterDTO> GetById(int id)
    {
        var meter = await _context.Meters
            .Include(m => m.ElectricityMeter)
            .FirstOrDefaultAsync(m => m.Id == id);
        return _mapper.Map<GetMeterDTO>(meter);
    }

    public async Task<GetMeterDTO> GetBySerialNumber(string serialNumber)
    {
        var meter = await _context.Meters
            .Include(m => m.ElectricityMeter)
            .FirstOrDefaultAsync(m => m.SerialNumber == serialNumber);
        return _mapper.Map<GetMeterDTO>(meter);
    }
}