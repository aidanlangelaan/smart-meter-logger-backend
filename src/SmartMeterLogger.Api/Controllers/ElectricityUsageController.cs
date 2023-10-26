using System;
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
///    ElectricityUsageController
/// </summary>
[Produces("application/json")]
[Route("api/[controller]")]
[ApiController]
public class ElectricityUsageController : ControllerBase
{
    private readonly IMapper _mapper;
    private readonly IElectricityUsageService _electricityUsageService;

    /// <summary>
    ///    TelegramController
    /// </summary>
    /// <param name="mapper"></param>
    /// <param name="electricityUsageService"></param>
    public ElectricityUsageController(IMapper mapper, IElectricityUsageService electricityUsageService)
    {
        _mapper = mapper;
        _electricityUsageService = electricityUsageService;
    }

    /// <summary>
    /// Gets all electricity usages for a specific meter
    /// </summary>
    /// <remarks>
    /// Sample request:
    ///
    ///     GET /api/electricityusage/4530303433303015985636353834373138
    ///
    /// </remarks>
    /// <returns>List of electricity usages</returns>
    /// <response code="200">Electricity usages have been retrieved</response>
    /// <response code="400">Failed to process request</response>
    [HttpGet("{serialNumber}")]
    [ProducesResponseType(typeof(IEnumerable<GetElectricityUsageViewModel>), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(void), StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> Get([FromRoute] string serialNumber, [FromQuery]GetElectricityUsageRequestViewModel model)
    {
        var dto = _mapper.Map<GetElectricityUsageRequestDTO>(model);
        var electricityUsages = await _electricityUsageService.GetAll(serialNumber, dto);
        return Ok(electricityUsages);
    }

    /// <summary>
    /// Gets a single electricity usage by its id for a specific meter
    /// </summary>
    /// <remarks>
    /// Sample request:
    ///
    ///     GET /api/electricityusage/4530303433303015985636353834373138/1
    ///
    /// </remarks>
    /// <returns>A single transaction</returns>
    /// <response code="200">Electricity usage for given id has been retrieved</response>
    /// <response code="404">Electricity usage not found for given id</response>
    /// <response code="400">Failed to process request</response>
    [HttpGet("{serialNumber}/{id:int}")]
    [ProducesResponseType(typeof(GetElectricityUsageViewModel), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(void), StatusCodes.Status404NotFound)]
    [ProducesResponseType(typeof(void), StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> Get(string serialNumber, int id)
    {
        var electricityUsage = await _electricityUsageService.GetById(serialNumber, id);
        if (electricityUsage != null)
        {
            return Ok(electricityUsage);
        }

        return NotFound();
    }
}