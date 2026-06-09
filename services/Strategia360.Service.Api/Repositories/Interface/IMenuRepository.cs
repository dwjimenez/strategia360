using DFast.Seguridad.Api.Models;


namespace DFast.Seguridad.Api.Repositories
{
    public interface IMenuRepository
    {
        Task<List<Menu>> ObtenerAsync(string sistema);
        Task<List<Menu>> ObtenerAllMenusAsync();
        Task<Menu> ObtenerXIdMenu(int id);
        void EditarAsync(Menu menu);

        Task<Menu> ObtenerXIDAsync(int id);

    }
}