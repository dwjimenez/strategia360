
using Strategia360.Service.Api.DTOs;
using Strategia360.Service.Api.Models;

namespace Strategia360.Service.Api.Services
{
    public interface IVisitaService
    {
        
        Task<bool> NuevoAsync(RegistrarCiudadanoVisitaRequest request);

        Task<bool> ActualizarAsync(RegistrarCiudadanoVisitaRequest request);


    }
}