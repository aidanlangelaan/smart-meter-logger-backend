using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using RpiSmartMeter.Services.Interfaces;
using RpiSmartMeter.Services.Logger.Models;

namespace RpiSmartMeter.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoggerController : ControllerBase
    {
        private readonly ILoggerService _loggerService;

        public LoggerController(ILoggerService loggerService)
        {
            _loggerService = loggerService;
        }

        [HttpPost]
        public async Task<IActionResult> CreateUsage(CreateUsageModel model)
        {
            var result = await _loggerService.CreateUsage(model);
            return Ok(result);
        }
    }
}
