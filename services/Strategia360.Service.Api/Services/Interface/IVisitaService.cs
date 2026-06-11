using Strategia360.Service.Api.DTOs;
using Strategia360.Service.Api.Dtos;
using Strategia360.Service.Api.Models;

namespace Strategia360.Service.Api.Services
{
    public interface IVisitaService
    {
        Task<bool> NuevoAsync(RegistrarCiudadanoVisitaRequest request);

        Task<bool> ActualizarAsync(RegistrarCiudadanoVisitaRequest request);

        Task<List<CiudadanoDto>> ConsultarCiudadanosAsync(string tienda, string ciudad, string? nombres, string? apellidos);
        Task<List<CiudadanoDto>> ConsultarCiudadanosCercanosAsync(string tienda, string ciudad, decimal posX, decimal posY, double distanciaMetros);
    }
}
