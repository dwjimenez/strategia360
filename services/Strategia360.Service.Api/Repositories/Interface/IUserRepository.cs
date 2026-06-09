
using DFast.Seguridad.Api.Models;

namespace DFast.Seguridad.Api.Repositories
{
    public interface IUserRepository
    {
        Task<Usuario> GetAsync(Guid id);
        Task<Usuario> GetAsync(int id);
        Task<Usuario> GetAsync(string key, string sistema);
        Task<List<Usuario>> GetByNombreApellidosAsync(string nombre, string apellidos, string sistema);
        Task<bool> EncontrarAsync(string key, string sistema);
        Task<bool> EncontrarMailAsync(string mail, string sistema);
        Task AddAsync(Usuario user);
        Usuario Update(Usuario user);
        List<Usuario> ObtenerTodosAsync(string sistema);
    }
}
