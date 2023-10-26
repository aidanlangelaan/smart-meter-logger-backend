using System;
using System.Collections.Generic;
using System.Linq;
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

            var lastUsage = await _context.ElectricityUsages
                .OrderByDescending(u => u.Id)
                .FirstOrDefaultAsync();

            var electricityUsage = _mapper.Map<ElectricityUsage>(model);
            electricityUsage.Meter = electricityMeter;

            if (lastUsage != null)
            {
                electricityUsage.DeltaActualBackdelivery = electricityUsage.ActualBackdelivery - lastUsage.ActualBackdelivery;
                electricityUsage.DeltaActualDelivery = electricityUsage.ActualDelivery - lastUsage.ActualDelivery;
                electricityUsage.DeltaActPowerL1 = electricityUsage.ActPowerL1 - lastUsage.ActPowerL1;
                electricityUsage.DeltaActPowerL2 = electricityUsage.ActPowerL2 ?? 0 - lastUsage.ActPowerL2 ?? 0;
                electricityUsage.DeltaActPowerL3 = electricityUsage.ActPowerL3 ?? 0 - lastUsage.ActPowerL3 ?? 0;
                electricityUsage.DeltaCurrentL1 = electricityUsage.CurrentL1 - lastUsage.CurrentL1;
                electricityUsage.DeltaCurrentL2 = electricityUsage.CurrentL2 ?? 0 - lastUsage.CurrentL2 ?? 0;
                electricityUsage.DeltaCurrentL3 = electricityUsage.CurrentL3 ?? 0 - lastUsage.CurrentL3 ?? 0;
                electricityUsage.DeltaVoltageL1 = electricityUsage.VoltageL1 - lastUsage.VoltageL1;
                electricityUsage.DeltaVoltageL2 = electricityUsage.VoltageL2 ?? 0 - lastUsage.VoltageL2 ?? 0;
                electricityUsage.DeltaVoltageL3 = electricityUsage.VoltageL3 ?? 0 - lastUsage.VoltageL3 ?? 0;
                electricityUsage.DeltaTotalBackdeliveryHigh = electricityUsage.TotalBackdeliveryHigh - lastUsage.TotalBackdeliveryHigh;
                electricityUsage.DeltaTotalBackdeliveryLow = electricityUsage.TotalBackdeliveryLow - lastUsage.TotalBackdeliveryLow;
                electricityUsage.DeltaTotalDeliveryHigh = electricityUsage.TotalDeliveryHigh - lastUsage.TotalDeliveryHigh;
                electricityUsage.DeltaTotalDeliveryLow = electricityUsage.TotalDeliveryLow - lastUsage.TotalDeliveryLow;
                electricityUsage.DeltaActPowerBackdeliveryL1 = electricityUsage.ActPowerBackdeliveryL1 - lastUsage.ActPowerBackdeliveryL1;
                electricityUsage.DeltaActPowerBackdeliveryL2 = electricityUsage.ActPowerBackdeliveryL2 ?? 0 - lastUsage.ActPowerBackdeliveryL2 ?? 0;
                electricityUsage.DeltaActPowerBackdeliveryL3 = electricityUsage.ActPowerBackdeliveryL3 ?? 0 - lastUsage.ActPowerBackdeliveryL3 ?? 0;
            }

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
                
                var lastUsage = await _context.GasUsages
                    .OrderByDescending(u => u.Id)
                    .FirstOrDefaultAsync();

                if (lastUsage != null)
                {
                    gasUsage.DeltaTotalDelivery = gasUsage.TotalDelivery - lastUsage.TotalDelivery;   
                }
                
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