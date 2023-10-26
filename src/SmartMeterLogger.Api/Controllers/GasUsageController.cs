using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SmartMeterLogger.Api.Models;
using SmartMeterLogger.Business.Interfaces;

namespace SmartMeterLogger.Api.Controllers;

/// <summary>
///    GasUsageController
/// </summary>
[Produces("application/json")]
[Route("api/[controller]")]
[ApiController]
public class GasUsageController : ControllerBase
{
    private readonly IMapper _mapper;
    private readonly IGasUsageService _gasUsageService;

    /// <summary>
    ///    TelegramController
    /// </summary>
    /// <param name="mapper"></param>
    /// <param name="gasUsageService"></param>
    public GasUsageController(IMapper mapper, IGasUsageService gasUsageService)
    {
        _mapper = mapper;
        _gasUsageService = gasUsageService;
    }

    /// <summary>
    /// Gets all gas usages for a specific meter
    /// </summary>
    /// <remarks>
    /// Sample request:
    ///
    ///     GET /api/gasusage/4530303433303015985636353834373138
    ///
    /// </remarks>
    /// <returns>List of gas usages</returns>
    /// <response code="200">Gas usages have been retrieved</response>
    /// <response code="400">Failed to process request</response>
    [HttpGet("{serialNumber}")]
    [ProducesResponseType(typeof(IEnumerable<GetGasUsageViewModel>), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(void), StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> Get(string serialNumber)
    {
        var gasUsages = await _gasUsageService.GetAll(serialNumber, null);
        return Ok(gasUsages);
    }

    /// <summary>
    /// Gets a single gas usage by its id for a specific meter
    /// </summary>
    /// <remarks>
    /// Sample request:
    ///
    ///     GET /api/gasusage/4530303433303015985636353834373138/1
    ///
    /// </remarks>
    /// <returns>A single transaction</returns>
    /// <response code="200">Gas usage for given id has been retrieved</response>
    /// <response code="404">Gas usage not found for given id</response>
    /// <response code="400">Failed to process request</response>
    [HttpGet("{serialNumber}/{id:int}")]
    [ProducesResponseType(typeof(GetGasUsageViewModel), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(void), StatusCodes.Status404NotFound)]
    [ProducesResponseType(typeof(void), StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> Get(string serialNumber, int id)
    {
        var gasUsage = await _gasUsageService.GetById(serialNumber, id);
        if (gasUsage != null)
        {
            return Ok(gasUsage);
        }

        return NotFound();
    }
}