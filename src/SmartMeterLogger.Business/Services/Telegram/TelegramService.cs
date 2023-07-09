using SmartMeterLogger.Data;
using SmartMeterLogger.Business.Interfaces;
using SmartMeterLogger.Business.Models;
using System.Threading.Tasks;

namespace SmartMeterLogger.Business.Services
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
