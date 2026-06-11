using Microsoft.AspNetCore.Mvc;
using Strategia360.Service.Api.DTOs;
using Strategia360.Service.Api.Services;

namespace Strategia360.Service.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class VisitaController : ControllerBase
{
    private readonly IVisitaService _visitaService;
    

    public VisitaController(IVisitaService visitaService )
    {
        _visitaService = visitaService;
        
    
    }

    [HttpPost("registrarvisita")]
    public async Task<IActionResult> RegistrarVisita(RegistrarCiudadanoVisitaRequest command)
          => Ok(await _visitaService.NuevoAsync(command));

    [HttpPost("actualizarvisita")]
    public async Task<IActionResult> ActualizarVisita(RegistrarCiudadanoVisitaRequest command)
        => Ok(await _visitaService.ActualizarAsync(command));

    [HttpGet("consultarciudadanos")]
    public async Task<IActionResult> ConsultarCiudadanos(
        [FromQuery] string tienda,
        [FromQuery] string ciudad,
        [FromQuery] string? nombres,
        [FromQuery] string? apellidos)
        => Ok(await _visitaService.ConsultarCiudadanosAsync(tienda, ciudad, nombres, apellidos));


    // [HttpGet("obtenertodos")]
    // public IActionResult ObtenerTodos(string institucion)
    //=> Ok(_identityService.ObtenerTodos(institucion));

    // [HttpPost("signup")]
    // public async Task<IActionResult> SignUp(UsuarioDto command)
    // {
    //     return Ok(await _identityService.SignUpFullAsync(command));
    // }

    // [HttpPost("signupsimple")] // mail, telefono, nombre
    // public async Task<IActionResult> SignUpSimple(UsuarioDto command)
    // {
    //     return Ok(await _identityService.SignUpSimpleAsync(command));
    // }
    // [HttpPost("activar")] 
    // public async Task<IActionResult> Activar(UsuarioDto command)
    // {
    //     return Ok(await _identityService.ActivarAsync(command));
    // }

    // [HttpPost("actualizar")]
    // public async Task<IActionResult> Actualizar(UsuarioDto command)
    // {
    //     return Ok(await _identityService.ActualizarAsync(command));
    // }

    // [HttpPost("changepassword")]
    // public async Task<IActionResult> ChangePassword(ChangePasswordDto command)
    // {
    //     return Ok(await _identityService.ChangePasswordAsync(command.Key, command.Password, command.NewPassword, command.Sistema));
    // }
    // [HttpPost("forgetpassword")]
    // public async Task<IActionResult> ForgetPasswordAsync(ChangePasswordDto command)
    // {
    //     return Ok(await _identityService.ForgetPasswordAsync(command.Key, command.Sistema));
    // }
    // [HttpPost("updatepassword")]
    // public async Task<IActionResult> UpdatePassword(ChangePasswordDto command)
    // {
    //     return Ok(await _identityService.UpdatePasswordAsync(command.Key, command.Password, command.NewPassword, command.Sistema));
    // }
    // [HttpPost("registro")]
    // public async Task<IActionResult> Registro(UsuarioDto command)
    // {
    //     return Ok(await _registroService.GuardarAsync(command, true));
    // }

    // [HttpGet("registrovalidarimei")]
    // public async Task<IActionResult> RegistroValidarImei(string sistema, string imei)
    // {

    //     return Ok(await _registroService.RegistroValidarImei(sistema, imei));
    // }
    // [HttpPost("registraringreso")]
    // public async Task<IActionResult> RegistrarIngreso(UsuarioDto command)
    // {
    //     return Ok(await _identityService.RegistrarIngresoAsync(command));
    // }
    // [HttpPost("token")]
    // public async Task<IActionResult> TokenAsync(SignIn command)
    //       => Ok(await _identityService.TokenAsync(command.Key, command.Sistema));

    // [HttpPost("crearotp")]
    // public async Task<IActionResult> CrearOtpAsync(UsuarioDto command)
    //     => Ok(await _identityService.CrearOtpAsync(command));

    // [HttpPost("validarotp")]
    // public async Task<IActionResult> ValidarOtpAsync(UsuarioDto command)
    //     => Ok(await _identityService.ValidarOtpAsync(command));

    // [HttpPost("enviarpush")]
    // public async Task<IActionResult> EnviarPushAsync(MessagePush command)
    //      => Ok(await _identityService.EnviarPushAsync(command));

    // [HttpGet("obtenrusuarioscomercio")]
    // public async Task<IActionResult> ObtenrUsuariosComercioAsync(int idComercio)
    //     => Ok(await _identityService.ObtenerUsuariosComercioAsync(idComercio));

    // [HttpPost("enviarlistapush")]
    // public async Task<IActionResult> EnviarListaPushAsync(List<MessagePush> command)
    //     => Ok(await _identityService.EnviarListaPushAsync(command));


    // [HttpGet("getuser")]
    // public async Task<IActionResult> GetUser(string key, string sistema)
    // {
    //     return Ok(await _identityService.GetUser(key, sistema));
    // }

    // [HttpGet("getusersbynombreapellidos")]
    // public async Task<IActionResult> GetUsersByNombreApellidos(string nombres, string apellidos, string sistema)
    // {
    //     return Ok(await _identityService.GetUsersByNombreApellidos(nombres, apellidos, sistema));
    // }

}


