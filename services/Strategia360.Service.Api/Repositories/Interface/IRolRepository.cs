using DFast.Seguridad.Api.Models;


namespace DFast.Seguridad.Api.Repositories
{
    public interface IRolRepository
    {
        Task<bool> EncontrarXIdAsync(int codigo);
        Task<Rol> ObtenerAsync(string codigo, string sistema);

        Task<bool> BuscarAsync(string codigo, string sistema);
        Task<Rol> ObtenerXIdAsync(int codigo);

        Task<List<Rol>> ObtenerTodosAsync(string sistema);
        
        void EditarAsync(Rol cuenta);
        Task CrearAsync(Rol cuenta);

        Task<List<Menu>> ObtenerMenusAsync(int idRolOpciones);


    }
}