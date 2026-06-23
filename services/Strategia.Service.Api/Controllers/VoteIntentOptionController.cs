using Microsoft.AspNetCore.Mvc;
using Strategia.Service.Api.Services;

namespace  Strategia.Service.Controllers;

[Route("api/[controller]")]
[ApiController]
public class VoteIntentOptionController : ControllerBase
{
    private readonly IVoteIntentOptionService _intencionVotoOpcionService;

    public VoteIntentOptionController(IVoteIntentOptionService intencionVotoOpcionService)
    {
        _intencionVotoOpcionService = intencionVotoOpcionService;
    }

    [HttpGet("getbystore")]
    public async Task<IActionResult> GetByStore([FromQuery] string tienda)
        => Ok(await _intencionVotoOpcionService.GetByStoreAsync(tienda));
}
