using System.Collections.Generic;
using System.Threading.Tasks;
using SmartMeterLogger.Business.Models;

namespace SmartMeterLogger.Business.Interfaces
{
    public interface ITelegramService
    {
        public Task<List<GetTelegramDTO>> CreateMany(IEnumerable<CreateTelegramDTO> model);
        public Task<GetTelegramDTO> Create(CreateTelegramDTO model);
    }
}
