using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using SmartMeterLogger.Business.Models;

namespace SmartMeterLogger.Business.Interfaces
{
    public interface IElectricityUsageService
    {
        public Task<IEnumerable<GetElectricityUsageDTO>> GetAll(string serialNumber,
            GetElectricityUsageRequestDTO model);
        
        public Task<GetElectricityUsageDTO> GetById(string serialNumber, int usageId);
        
        public Task<IEnumerable<GetElectricityUsageByDayDTO>> GetByDate(string serialNumber, DateTime date);
        
        public Task<IEnumerable<GetElectricityUsageDTO>> GetByMonth(string serialNumber, int month);
    }
}
