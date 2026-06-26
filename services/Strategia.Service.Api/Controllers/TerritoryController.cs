using Microsoft.AspNetCore.Mvc;
using Strategia.Service.Api.Services;

namespace  Strategia.Service.Controllers;

[Route("api/[controller]")]
[ApiController]
public class TerritoryController : ControllerBase
{
    private readonly ITerritoryService _territorioService;

    public TerritoryController(ITerritoryService territorioService)
    {
        _territorioService = territorioService;
    }

    [HttpGet("getbystoreandcity")]
    public async Task<IActionResult> GetByStoreAndCity(
        [FromQuery] string tienda,
        [FromQuery] string ciudad,
        [FromQuery] bool includeInactive = false)
        => Ok(await _territorioService.GetByStoreAndCityAsync(tienda, ciudad, includeInactive));
}
