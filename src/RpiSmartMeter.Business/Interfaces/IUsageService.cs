using System.Threading.Tasks;
using RpiSmartMeter.Business.Models;

namespace RpiSmartMeter.Business.Interfaces
{
    public interface IUsageService
    {
        public Task<CreateUsageDTO> CreateUsage(CreateUsageDTO model);
    }
}
