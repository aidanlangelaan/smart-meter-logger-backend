using System.Collections.Generic;
using System.Threading.Tasks;
using SmartMeterLogger.Business.Models;

namespace SmartMeterLogger.Business.Interfaces
{
    public interface IMeterService
    {
        public Task<IEnumerable<GetMeterDTO>> GetAll();
        
        public Task<GetMeterDTO> GetById(int id);
        
        public Task<GetMeterDTO> GetBySerialNumber(string serialNumber);
    }
}
