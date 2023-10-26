using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SmartMeterLogger.Api.Models;
using SmartMeterLogger.Business.Interfaces;
using SmartMeterLogger.Business.Models;

namespace SmartMeterLogger.Api.Controllers;

/// <summary>
///    TelegramController
/// </summary>
[Produces("application/json")]
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

    /// <summary>
    /// Processes many telegrams
    /// </summary>
    /// <remarks>
    /// Sample request:
    ///
    ///     POST /api/telegram/create-many
    ///
    ///     [{
    ///         "dsmr_version":50,
    ///         "timestamp":"2023-10-26T17:27:54.000000Z",
    ///         "meter_id":"3840650207359198556957562562582383",
    ///         "total_delivery_low_kwh":10095.07,
    ///         "total_delivery_high_kwh":9735.537,
    ///         "total_backdelivery_low_kwh":0.0,
    ///         "total_backdelivery_high_kwh":0.2,
    ///         "tariff_indicator":2,
    ///         "actual_delivery_kw":0.300,
    ///         "actual_backdelivery_kw":0.0,
    ///         "nr_powerfailures":8,
    ///         "nr_powerfailures_long":3,
    ///         "powerfailure_log":"['1', '0-0:96.7.19', '220407153135S', '0000002815*s']",
    ///         "nr_voltage_sags_l1":16,
    ///         "nr_voltage_swells_l1":1,
    ///         "text_message":"",
    ///         "voltage_l1_v":226.7,
    ///         "current_l1_a":1,
    ///         "act_power_l1_kw":0.266,
    ///         "act_power_backdelivery_l1_kw":0.0,
    ///         "mbus1_device_type":3,
    ///         "mbus1_meter_id":"3485628099095606051169369383822221",
    ///         "mbus1_value":4548.456
    ///     }]
    ///
    /// </remarks>
    /// <returns>A list of created usages</returns>
    /// <response code="201">Usages have been created</response>
    /// <response code="400">Request is invalid</response>
    /// <response code="500">Something went wrong while processing the telegrams</response>
    [HttpPost("create-many")]
    [ProducesResponseType(typeof(List<GetTelegramViewModel>), StatusCodes.Status201Created)]
    [ProducesResponseType(typeof(void), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(void), StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> CreateMany([FromBody]IEnumerable<CreateTelegramViewModel> model)
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

    /// <summary>
    /// Processes a single telegrams
    /// </summary>
    /// <remarks>
    /// Sample request:
    ///
    ///     POST /api/telegram/create
    ///
    ///     {
    ///         "dsmr_version":50,
    ///         "timestamp":"2023-10-26T17:27:54.000000Z",
    ///         "meter_id":"3840650207359198556957562562582383",
    ///         "total_delivery_low_kwh":10095.07,
    ///         "total_delivery_high_kwh":9735.537,
    ///         "total_backdelivery_low_kwh":0.0,
    ///         "total_backdelivery_high_kwh":0.2,
    ///         "tariff_indicator":2,
    ///         "actual_delivery_kw":0.300,
    ///         "actual_backdelivery_kw":0.0,
    ///         "nr_powerfailures":8,
    ///         "nr_powerfailures_long":3,
    ///         "powerfailure_log":"['1', '0-0:96.7.19', '220407153135S', '0000002815*s']",
    ///         "nr_voltage_sags_l1":16,
    ///         "nr_voltage_swells_l1":1,
    ///         "text_message":"",
    ///         "voltage_l1_v":226.7,
    ///         "current_l1_a":1,
    ///         "act_power_l1_kw":0.266,
    ///         "act_power_backdelivery_l1_kw":0.0,
    ///         "mbus1_device_type":3,
    ///         "mbus1_meter_id":"3485628099095606051169369383822221",
    ///         "mbus1_value":4548.456
    ///     }
    ///
    /// </remarks>
    /// <returns>The created created usages</returns>
    /// <response code="201">Usages have been created</response>
    /// <response code="400">Request is invalid</response>
    /// <response code="500">Something went wrong while processing the telegrams</response>
    [HttpPost("create")]
    [ProducesResponseType(typeof(GetTelegramViewModel), StatusCodes.Status201Created)]
    [ProducesResponseType(typeof(void), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(void), StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> Create([FromBody]CreateTelegramViewModel model)
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