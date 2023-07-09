using RpiSmartMeter.Data;
using RpiSmartMeter.Business.Interfaces;
using RpiSmartMeter.Business.Models;
using System.Threading.Tasks;

namespace RpiSmartMeter.Business.Services
{
    public class TelegramService : ITelegramService
    {
        private readonly SmartMeterDbContext _context;

        public TelegramService(SmartMeterDbContext context)
        {
            _context = context;
        }

        public async Task<GetTelegramDTO> Create(CreateTelegramDTO model)
        {
            /// TODO: map to entities
            /// Save to DB
            /// Return some sort of value
            return default;
        }
    }
}
