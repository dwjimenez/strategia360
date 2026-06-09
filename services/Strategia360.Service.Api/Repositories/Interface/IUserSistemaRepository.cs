
using DFast.Seguridad.Api.Models;

namespace DFast.Seguridad.Api.Repositories
{
    public interface IUserSistemaRepository
    {

        Task CrearAsync(UsuarioSistema user);
        Task<UsuarioSistema> ObtenerAsync(int id, string sistema);
        Task<List<UsuarioSistema>> ObtenerTodosxRelacionAsync(int id);
        

    }
}