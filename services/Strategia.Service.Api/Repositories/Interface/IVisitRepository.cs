using Strategia.Service.Api.DTOs;
using Strategia.Service.Api.Models;
using System.Threading.Tasks;


namespace  Strategia.Service.Api.Repositories
{
    public interface IVisitRepository
    {

        Task<Visita> SaveCitizenAndVisitAsync(
            Ciudadano ciudadano,
            Visita visita,
            List<VisitaIntencionVoto> visitaIntencionesVoto);

        Task<List<Visita>> GetCitizensAsync(string tienda, string ciudad, string? nombres, string? apellidos);
        Task<List<Ciudadano>> GetNearbyCitizensAsync(string tienda, string ciudad, decimal posX, decimal posY, double distanciaMetros);
        Task<List<Visita>> GetVisitsByUserAndDateRangeAsync(string tienda, string codigoUsuario, DateTime fechaDesde, DateTime fechaHasta);
    }
}
