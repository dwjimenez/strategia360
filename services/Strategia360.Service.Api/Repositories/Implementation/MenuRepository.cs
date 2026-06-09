using DFast.Seguridad.Api.Persistences;
using DFast.Seguridad.Api.Models;
using Microsoft.EntityFrameworkCore;

namespace DFast.Seguridad.Api.Repositories
{
    public class MenuRepository : IMenuRepository
    {
        private readonly ContextDatabase _seguridadContext;
        
        public MenuRepository(ContextDatabase SeguridadContext
            
        )
        {
            _seguridadContext = SeguridadContext;
            
        }


        public async Task<List<Menu>> ObtenerAsync(string sistema)
        {
            var menus = await _seguridadContext.Menu.AsNoTracking().Where(x => x.Activo == true).ToListAsync();
            return menus;

        }

        public void EditarAsync(Menu menu) => _seguridadContext.Menu.Update(menu);

        public async Task<Menu> ObtenerXIDAsync(int id)
        {
            return await _seguridadContext.Menu.FirstOrDefaultAsync(item => item.IdMenu == id);
        }

        public async Task<List<Menu>> ObtenerAllMenusAsync()
        {
            var menus = await _seguridadContext.Menu.AsNoTracking().Where(x => x.Activo == true).ToListAsync();
            return menus;
        }

        public async  Task<Menu> ObtenerXIdMenu(int id)
        {
            var result = await _seguridadContext.Menu.AsNoTracking().Include(m => m.RolOpcions).FirstOrDefaultAsync(m => m.IdMenu==id);
            return result;

        }
    }
}