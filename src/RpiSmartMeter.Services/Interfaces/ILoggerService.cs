using System.Threading.Tasks;
using RpiSmartMeter.Services.Logger.Models;

namespace RpiSmartMeter.Services.Interfaces
{
    public interface ILoggerService
    {
        public Task<CreateUsageModel> CreateUsage(CreateUsageModel model);
    }
}
