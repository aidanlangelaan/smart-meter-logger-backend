using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SmartMeterLogger.Api.Models;
using SmartMeterLogger.Business.Interfaces;
using SmartMeterLogger.Business.Models;

namespace SmartMeterLogger.Api.Controllers;

/// <summary>
///    TelegramController
/// </summary>
[Route("api/[controller]")]
[ApiController]
public class TelegramController : ControllerBase
{
    private readonly IMapper _mapper;
    private readonly ITelegramService _telegramService;

    /// <summary>
    ///    TelegramController
    /// </summary>
    /// <param name="mapper"></param>
    /// <param name="telegramService"></param>
    public TelegramController(IMapper mapper, ITelegramService telegramService)
    {
        _mapper = mapper;
        _telegramService = telegramService;
    }

    [HttpPost("create-many")]
    public async Task<IActionResult> CreateMany(IEnumerable<CreateTelegramViewModel> model)
    {
        var createTelegramDtos = _mapper.Map<IEnumerable<CreateTelegramDTO>>(model);
        var result = await _telegramService.CreateMany(createTelegramDtos);
            
        if (result == null)
        {
            return BadRequest("Failed to create telegram");
        }
        
        var getTelegramViewModels = _mapper.Map<List<GetTelegramViewModel>>(result);
        return CreatedAtAction(nameof(CreateMany), getTelegramViewModels);
    }
        
    [HttpPost("create")]
    public async Task<IActionResult> Create(CreateTelegramViewModel model)
    {
        var createTelegramDto = _mapper.Map<CreateTelegramDTO>(model);
        var result = await _telegramService.Create(createTelegramDto);

        if (result == null)
        {
            return BadRequest("Failed to create telegram");
        }
        
        var getTelegramViewModel = _mapper.Map<GetTelegramViewModel>(result);
        return CreatedAtAction(nameof(Create), getTelegramViewModel);
    }
}