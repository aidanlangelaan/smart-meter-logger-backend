using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SmartMeterLogger.Api.Models;
using SmartMeterLogger.Business.Interfaces;
using SmartMeterLogger.Business.Models;

namespace SmartMeterLogger.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TelegramController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly ITelegramService _telegramService;

        public TelegramController(IMapper mapper, ITelegramService telegramService)
        {
            _mapper = mapper;
            _telegramService = telegramService;
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateTelegramViewModel model)
        {
            var createTelegramDto = _mapper.Map<CreateTelegramDTO>(model);
            var result = await _telegramService.Create(createTelegramDto);
            
            var getTelegramViewModel = _mapper.Map<GetTelegramViewModel>(result);
            return Created(getTelegramViewModel.Id.ToString(), getTelegramViewModel);
        }
    }
}