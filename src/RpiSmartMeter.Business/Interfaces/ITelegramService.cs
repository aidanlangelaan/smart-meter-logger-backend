using System.Threading.Tasks;
using RpiSmartMeter.Business.Models;

namespace RpiSmartMeter.Business.Interfaces
{
    public interface ITelegramService
    {
        public Task<GetTelegramDTO> Create(CreateTelegramDTO model);
    }
}
