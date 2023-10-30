using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using SmartMeterLogger.Business.Models;

namespace SmartMeterLogger.Business.Interfaces
{
    public interface IGasUsageService
    {
        public Task<IEnumerable<GetGasUsageDTO>> GetAll(string serialNumber,
            GetGasUsageRequestDTO model);
        
        public Task<GetGasUsageDTO> GetById(string serialNumber, int usageId);
        
        public Task<IEnumerable<GetGasUsageByDayDTO>> GetByDate(string serialNumber, DateTime date);
    }
}
