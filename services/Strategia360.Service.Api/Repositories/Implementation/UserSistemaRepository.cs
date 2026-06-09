
using DFast.Seguridad.Api.Models;
using DFast.Seguridad.Api.Persistences;
using Microsoft.EntityFrameworkCore;

namespace DFast.Seguridad.Api.Repositories
{
    public class UserSistemaRepository : IUserSistemaRepository
    {
        private readonly ContextDatabase _seguridadfContext;

        public UserSistemaRepository(ContextDatabase seguridadfContext)
        {
            _seguridadfContext = seguridadfContext;
        }


        public async Task CrearAsync(UsuarioSistema user)
            =>  await _seguridadfContext.UsuarioSistema.AddAsync(user);


        public async Task<UsuarioSistema> ObtenerAsync(int id, string sistema) =>
         await _seguridadfContext.UsuarioSistema.FirstOrDefaultAsync(x => x.IdUsuario == id && x.Sistema == sistema );

        // obtener todos los usuarios por Id de establecimiento opor relacion de otros 
        public async Task<List<UsuarioSistema>> ObtenerTodosxRelacionAsync(int id)
        {
           return  await _seguridadfContext.UsuarioSistema
          .Where(e => e.IdRelacion == id)
          .AsNoTracking().ToListAsync();
        }

    }
}