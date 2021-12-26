using RpiSmartMeter.Data;
using RpiSmartMeter.Business.Interfaces;
using RpiSmartMeter.Business.Models;
using System.Threading.Tasks;

namespace RpiSmartMeter.Business.Services
{
    public class UsageService : IUsageService
    {
        private readonly SmartMeterDbContext _context;

        public UsageService(SmartMeterDbContext context)
        {
            _context = context;
        }

        public async Task<CreateUsageDTO> CreateUsage(CreateUsageDTO model)
        {


            return model;
        }
    }
}
