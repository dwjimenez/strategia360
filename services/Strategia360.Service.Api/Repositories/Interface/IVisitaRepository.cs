using Strategia360.Service.Api.DTOs;
using Strategia360.Service.Api.Models;
using System.Threading.Tasks;


namespace Strategia360.Service.Api.Repositories
{
    public interface IVisitaRepository
    {

        Task<Visita> NuevaAsync(Ciudadano ciudadano,
        Visita visita,
        List<VisitaIntencionVoto> visitaIntencionVoto);

        Task<Visita> ActualizarAsync(Ciudadano ciudadanoEditado,
        Visita nuevaVisita,
        List<VisitaIntencionVoto> nuevasIntencionesVoto);

        Task<List<Ciudadano>> ConsultarCiudadanosAsync(string tienda, string ciudad, string? nombres, string? apellidos);
    }
}
