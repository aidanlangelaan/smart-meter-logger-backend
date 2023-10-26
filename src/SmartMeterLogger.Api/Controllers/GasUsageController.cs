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
    ///    GasUsageController
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
    /// <response code="500">Something went wrong while retrieving the gas usages</response>
    [HttpGet("{serialNumber}")]
    [ProducesResponseType(typeof(IEnumerable<GetGasUsageViewModel>), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(void), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(void), StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> Get(GetGasUsageRequestViewModel model)
    {
        var dto = _mapper.Map<GetGasUsageRequestDTO>(model);
        var gasUsages = await _gasUsageService.GetAll(model.SerialNumber, dto);
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
    /// <response code="500">Something went wrong while retrieving the gas usage</response>
    [HttpGet("{serialNumber}/{id:int}")]
    [ProducesResponseType(typeof(GetGasUsageViewModel), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(void), StatusCodes.Status404NotFound)]
    [ProducesResponseType(typeof(void), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(void), StatusCodes.Status500InternalServerError)]
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