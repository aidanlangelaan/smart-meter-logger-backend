using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using RpiSmartMeter.Business.Interfaces;
using RpiSmartMeter.Business.Models;

namespace RpiSmartMeter.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsageController : ControllerBase
    {
        private readonly IUsageService _loggerService;

        public UsageController(IUsageService loggerService)
        {
            _loggerService = loggerService;
        }

        [HttpPost]
        public async Task<IActionResult> CreateUsage(CreateUsageDTO model)
        {
            var result = await _loggerService.CreateUsage(model);
            return Ok(result);
        }
    }
}
