using Microsoft.AspNetCore.Mvc;
using Strategia.Service.Api.Services;

namespace  Strategia.Service.Controllers;

[Route("api/[controller]")]
[ApiController]
public class CenturiaController : ControllerBase
{
    private readonly ICenturiaService _centuriaService;

    public CenturiaController(ICenturiaService centuriaService)
    {
        _centuriaService = centuriaService;
    }

    [HttpGet("getbystoreandcity")]
    public async Task<IActionResult> GetByStoreAndCity(
        [FromQuery] string tienda,
        [FromQuery] string ciudad)
        => Ok(await _centuriaService.GetByStoreAndCityAsync(tienda, ciudad));
}
