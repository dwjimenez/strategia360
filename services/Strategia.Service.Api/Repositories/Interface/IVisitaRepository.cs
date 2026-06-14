using Strategia.Service.Api.DTOs;
using Strategia.Service.Api.Models;
using System.Threading.Tasks;


namespace  Strategia.Service.Api.Repositories
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
        Task<List<Ciudadano>> ConsultarCiudadanosCercanosAsync(string tienda, string ciudad, decimal posX, decimal posY, double distanciaMetros);
    }
}
