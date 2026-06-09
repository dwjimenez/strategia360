
using DFast.Seguridad.Api.Models;
using DFast.Seguridad.Api.Persistences;
using Microsoft.EntityFrameworkCore;

namespace DFast.Seguridad.Api.Repositories
{
    public class RolRepository : IRolRepository
    {
        private readonly ContextDatabase _seguridadContext;

        public RolRepository(ContextDatabase SeguridadContext

        )
        {
            _seguridadContext = SeguridadContext;

        }

        public async Task<bool> EncontrarXIdAsync(int codigo) => await _seguridadContext.Rol.AnyAsync(c => c.IdRol == codigo);

        public async Task<bool> BuscarAsync(string codigo, string sistema)
        {
            return await _seguridadContext.Rol.AnyAsync(h => h.Codigo == codigo && h.Sistema == sistema);
        }


        public async Task<Rol> ObtenerAsync(string codigo, string sistema)
        {
            return await _seguridadContext.Rol.Include(u => u.RolOpcions).AsNoTracking().FirstOrDefaultAsync(h => h.Codigo == codigo && h.Sistema == sistema);

        }
        public async Task<List<Rol>> ObtenerTodosAsync(string sistema)
        {
            return await _seguridadContext.Rol.AsNoTracking().Include(u => u.RolOpcions).Where(h => h.Sistema == sistema).ToListAsync();
            

        }
        public void EditarAsync(Rol rol) => _seguridadContext.Rol.Update(rol);

        public async Task CrearAsync(Rol rol) => await _seguridadContext.Rol.AddAsync(rol);

        public async Task<Rol> ObtenerXIdAsync(int codigo)
        {
            return await _seguridadContext.Rol.Include(item => item.RolOpcions).FirstOrDefaultAsync(h => h.IdRol==codigo);
   
        }


        public async Task<List<Menu>> ObtenerMenusAsync(int idRolOpciones)
        {
            var query = await _seguridadContext.Menu
                //.Where(item => item.IdRolOpcion==idRolOpciones && item.Activo ==true).ToListAsync();
            .Where(item => item.Tipo == "item" && item.Activo ==true).ToListAsync();
            return query;

        }
    }
}