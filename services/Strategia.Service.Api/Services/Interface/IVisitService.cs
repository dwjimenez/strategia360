using Strategia.Service.Api.DTOs;

using Strategia.Service.Api.Models;

namespace  Strategia.Service.Api.Services
{
    public interface IVisitService
    {
        

        Task<bool> SaveCitizenVisitAsync(RegistrarCiudadanoVisitaRequest request);

        Task<List<VisitaDto>> GetCitizensAsync(string tienda, string ciudad, string? nombres, string? apellidos);
        Task<List<CiudadanoDto>> GetNearbyCitizensAsync(string tienda, string ciudad, decimal posX, decimal posY, double distanciaMetros);
        Task<List<VisitaDto>> GetVisitsByUserAndDateRangeAsync(string tienda, string codigoUsuario, DateTime fechaDesde, DateTime fechaHasta);
    }
}
