using System.Collections.Generic;
using System.Threading.Tasks;
using SmartMeterLogger.Business.Models;

namespace SmartMeterLogger.Business.Interfaces
{
    public interface IElectricityUsageService
    {
        public Task<List<GetElectricityUsageDTO>> GetAll(string serialNumber,
            GetElectricityUsageRequestDTO model);
        public Task<GetElectricityUsageDTO> GetById(string serialNumber, int usageId);
    }
}
