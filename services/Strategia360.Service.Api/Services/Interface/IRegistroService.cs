
using DFast.Seguridad.Api.DTOs;
using DFast.Seguridad.Api.Models;

namespace DFast.Seguridad.Api.Services
{
    public interface IRegistroService
    {
        Task<bool> GuardarAsync(UsuarioDto command, bool flag);
        Task<Registro> Guardar(UsuarioDto command);
        Task<UsuarioDto> RegistroValidarImei(string sistema, string imei);
       
    }
}