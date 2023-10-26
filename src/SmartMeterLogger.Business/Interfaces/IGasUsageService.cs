using System.Collections.Generic;
using System.Threading.Tasks;
using SmartMeterLogger.Business.Models;

namespace SmartMeterLogger.Business.Interfaces
{
    public interface IGasUsageService
    {
        public Task<List<GetGasUsageDTO>> GetAll(string serialNumber,
            GetGasUsageRequestDTO model);
        public Task<GetGasUsageDTO> GetById(string serialNumber, int usageId);
    }
}
