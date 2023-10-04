using System;
using System.Collections.Generic;
using SmartMeterLogger.Data;
using SmartMeterLogger.Business.Interfaces;
using SmartMeterLogger.Business.Models;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using SmartMeterLogger.Data.Entities;
using SmartMeterLogger.Data.Enums;

namespace SmartMeterLogger.Business.Services
{
    public class TelegramService : ITelegramService
    {
        private readonly SmartMeterLoggerDbContext _context;
        private readonly IMapper _mapper;

        public TelegramService(SmartMeterLoggerDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<List<GetTelegramDTO>> CreateMany(IEnumerable<CreateTelegramDTO> model)
        {
            var createdTelegrams = new List<GetTelegramDTO>();

            await using var transaction = await _context.Database.BeginTransactionAsync();
            try
            {
                foreach (var telegram in model)
                {
                    var createdTelegram = await Create(telegram);
                    createdTelegrams.Add(createdTelegram);
                }

                await transaction.CommitAsync();
            }
            catch (Exception)
            {
                // TODO: Handle failure
                return null;
            }

            return createdTelegrams;
        }

        public async Task<GetTelegramDTO> Create(CreateTelegramDTO model)
        {
            // TODO: switch statement to save individual mbus values?
            var electricityUsage = await CreateElectricityUsage(model);

            var gasUsage = await CreateGasUsage(model, electricityUsage);

            await _context.SaveChangesAsync();

            return new GetTelegramDTO
            {
                ElectricityUsage = _mapper.Map<GetElectricityUsageDTO>(electricityUsage),
                GasUsage = gasUsage != null ? _mapper.Map<GetGasUsageDTO>(gasUsage) : null
            };
        }

        private async Task<ElectricityUsage> CreateElectricityUsage(CreateTelegramDTO model)
        {
            // Create electricity usage
            var electricityMeter = await _context.Meters
                .Include(m => m.ElectricityMeter)
                .FirstOrDefaultAsync(m => m.SerialNumber == model.MeterId);

            if (electricityMeter == null)
            {
                electricityMeter = _mapper.Map<Meter>(model);
                electricityMeter.ElectricityMeter = _mapper.Map<ElectricityMeter>(model);
                _context.Meters.Add(electricityMeter);
            }
            else
            {
                electricityMeter.ElectricityMeter = _mapper.Map<ElectricityMeter>(model);
            }

            var electricityUsage = _mapper.Map<ElectricityUsage>(model);
            electricityUsage.Meter = electricityMeter;
            _context.ElectricityUsages.Add(electricityUsage);
            return electricityUsage;
        }

        private async Task<GasUsage> CreateGasUsage(CreateTelegramDTO model, ElectricityUsage electricityUsage)
        {
            // Create gas usage
            GasUsage gasUsage = null;
            var gasMeterData = GetMeterDataForType(MeterType.Gas, model);
            if (gasMeterData.HasValue)
            {
                // TODO: use mapper?
                var gasMeter =
                    await _context.Meters.FirstOrDefaultAsync(m =>
                        m.SerialNumber == gasMeterData.Value.Meter.SerialNumber);
                if (gasMeter == null)
                {
                    gasMeter = gasMeterData.Value.Meter;
                    _context.Meters.Add(gasMeter);
                }

                gasUsage = new GasUsage()
                {
                    // set to electricity timestamp for now until model is updated to retrieve gas timestamp
                    Timestamp = electricityUsage.Timestamp,
                    TotalDelivery = gasMeterData.Value.MeterValue,
                    Meter = gasMeter
                };
                _context.GasUsages.Add(gasUsage);
            }

            return gasUsage;
        }

        private static (Meter Meter, decimal MeterValue)? GetMeterDataForType(MeterType meterType,
            CreateTelegramDTO model)
        {
            string serialNumber = null;
            decimal? meterValue = default;

            if (model.Mbus1DeviceType == meterType)
            {
                serialNumber = model.Mbus1MeterId;
                meterValue = model.Mbus1Value;
            }
            else if (model.Mbus2DeviceType == meterType)
            {
                serialNumber = model.Mbus2MeterId;
                meterValue = model.Mbus2Value;
            }
            else if (model.Mbus3DeviceType == meterType)
            {
                serialNumber = model.Mbus3MeterId;
                meterValue = model.Mbus3Value;
            }
            else if (model.Mbus4DeviceType == meterType)
            {
                serialNumber = model.Mbus4MeterId;
                meterValue = model.Mbus4Value;
            }

            if (string.IsNullOrEmpty(serialNumber))
            {
                return null;
            }

            return new(new Meter { SerialNumber = serialNumber, DeviceType = meterType }, meterValue ?? 0);
        }
    }
}