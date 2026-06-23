using Microsoft.AspNetCore.Mvc;
using Strategia.Service.Api.DTOs;
using Strategia.Service.Api.Services;

namespace  Strategia.Service.Controllers;

[Route("api/[controller]")]
[ApiController]
public class VisitController : ControllerBase
{
    private readonly IVisitService _visitaService;
    

    public VisitController(IVisitService visitaService )
    {
        _visitaService = visitaService;
        
    
    }

    [HttpPost("savevisit")]
    public async Task<IActionResult> SaveVisit(RegistrarCiudadanoVisitaRequest command)
          => 
        Ok(await _visitaService.SaveCitizenVisitAsync(command));

    
    [HttpGet("getcitizens")]
    public async Task<IActionResult> GetCitizens(
        [FromQuery] string tienda,
        [FromQuery] string ciudad,
        [FromQuery] string? nombres,
        [FromQuery] string? apellidos)
        => Ok(await _visitaService.GetCitizensAsync(tienda, ciudad, nombres, apellidos));

    [HttpGet("getnearbycitizens")]
    public async Task<IActionResult> GetNearbyCitizens(
        [FromQuery] string tienda,
        [FromQuery] string ciudad,
        [FromQuery] decimal posX,
        [FromQuery] decimal posY,
        [FromQuery] double distanciaMetros)
        => Ok(await _visitaService.GetNearbyCitizensAsync(tienda, ciudad, posX, posY, distanciaMetros));

    [HttpGet("getvisitsbyuseranddaterange")]
    public async Task<IActionResult> GetVisitsByUserAndDateRange(
        [FromQuery] string tienda,
        [FromQuery] string codigoUsuario,
        [FromQuery] DateTime fechaDesde,
        [FromQuery] DateTime fechaHasta)
        => Ok(await _visitaService.GetVisitsByUserAndDateRangeAsync(tienda, codigoUsuario, fechaDesde, fechaHasta));


    
}


