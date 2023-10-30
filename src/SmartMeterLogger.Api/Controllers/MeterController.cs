using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SmartMeterLogger.Api.Models;
using SmartMeterLogger.Business.Interfaces;
using SmartMeterLogger.Business.Models;
using SmartMeterLogger.Data.Enums;

namespace SmartMeterLogger.Api.Controllers;

/// <summary>
///    MeterController
/// </summary>
[Produces("application/json")]
[Route("api/[controller]")]
[ApiController]
public class MeterController : ControllerBase
{
    private readonly IMapper _mapper;
    private readonly IMeterService _meterService;

    /// <summary>
    ///    ElectricityUsageController
    /// </summary>
    /// <param name="mapper"></param>
    /// <param name="meterService"></param>
    public MeterController(IMapper mapper, IMeterService meterService)
    {
        _mapper = mapper;
        _meterService = meterService;
    }

    /// <summary>
    /// Gets all meters
    /// </summary>
    /// <remarks>
    /// Sample request:
    ///
    ///     GET /api/meters
    ///
    /// </remarks>
    /// <returns>List of meters</returns>
    /// <response code="200">Meters have been retrieved</response>
    /// <response code="400">Failed to process request</response>
    /// <response code="500">Something went wrong while retrieving the meters</response>
    [HttpGet]
    [ProducesResponseType(typeof(IEnumerable<GetMeterViewModel>), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(void), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(void), StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> Get()
    {
        var meters = await _meterService.GetAll();
        return Ok(meters);
    }

    /// <summary>
    /// Gets a single meter by its id
    /// </summary>
    /// <remarks>
    /// Sample request:
    ///
    ///     GET /api/meters/1
    ///
    /// </remarks>
    /// <returns>A single meter</returns>
    /// <response code="200">Meter for given id has been retrieved</response>
    /// <response code="404">Meter not found for given id</response>
    /// <response code="400">Failed to process request</response>
    /// <response code="500">Something went wrong while retrieving the meter</response>
    [HttpGet("{id:int}")]
    [ProducesResponseType(typeof(GetMeterViewModel), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(void), StatusCodes.Status404NotFound)]
    [ProducesResponseType(typeof(void), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(void), StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> GetById(int id)
    {
        var meter = await _meterService.GetById(id);
        if (meter != null)
        {
            return Ok(meter);
        }

        return NotFound();
    }
    
    /// <summary>
    /// Gets a single meter by its serial number
    /// </summary>
    /// <remarks>
    /// Sample request:
    ///
    ///     GET /api/meters/4530303433303015985636353834373138
    ///
    /// </remarks>
    /// <returns>A single meter</returns>
    /// <response code="200">Meter for given serial number has been retrieved</response>
    /// <response code="404">Meter not found for given serial number</response>
    /// <response code="400">Failed to process request</response>
    /// <response code="500">Something went wrong while retrieving the meter</response>
    [HttpGet("{serialNumber}")]
    [ProducesResponseType(typeof(GetMeterViewModel), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(void), StatusCodes.Status404NotFound)]
    [ProducesResponseType(typeof(void), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(void), StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> GetBySerialNumber(string serialNumber)
    {
        var meter = await _meterService.GetBySerialNumber(serialNumber);
        if (meter != null)
        {
            return Ok(meter);
        }

        return NotFound();
    }
}