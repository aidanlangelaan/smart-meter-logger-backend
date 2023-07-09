using System.Threading.Tasks;
using SmartMeterLogger.Business.Models;

namespace SmartMeterLogger.Business.Interfaces
{
    public interface ITelegramService
    {
        public Task<GetTelegramDTO> Create(CreateTelegramDTO model);
    }
}
