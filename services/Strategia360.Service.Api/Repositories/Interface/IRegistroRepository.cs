
using DFast.Seguridad.Api.Models;

namespace DFast.Seguridad.Api.Repositories
{
    public interface IRegistroRepository
    {
        Task<Registro> GetAsync(int id);

        Task<Registro> ObtenerxImeiAsync(string sistema, string imei);
        Task<Registro> ObtenerxIdUsuarioAsync(string sistema, int idUsuario);
        Task AddAsync(Registro user);
        Registro Update(Registro user);
    }
}