using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using RpiSmartMeter.Data;
using RpiSmartMeter.Services.Interfaces;
using RpiSmartMeter.Services.Logger.Models;

namespace RpiSmartMeter.Services.Services
{
    public class LoggerService : ILoggerService
    {
        private readonly SmartMeterDbContext _context;

        public LoggerService(SmartMeterDbContext context)
        {
            _context = context;
        }

        public async Task<CreateUsageModel> CreateUsage(CreateUsageModel model)
        {


            return model;
        }
    }
}
