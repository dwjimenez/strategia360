
using DFast.Seguridad.Api.Models;
using DFast.Seguridad.Api.Persistences;
using Microsoft.EntityFrameworkCore;

namespace DFast.Seguridad.Api.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly ContextDatabase _seguridadfContext;

        public UserRepository(ContextDatabase seguridadfContext)
        {
            _seguridadfContext = seguridadfContext;
        }


        public async Task<Usuario> GetAsync(Guid id) =>
            await _seguridadfContext.Usuario.FirstOrDefaultAsync(x => x.Id == id);

        public async Task<Usuario> GetAsync(int id) =>
            await _seguridadfContext.Usuario.Include(us => us.UsuarioSistemas ).FirstOrDefaultAsync(x => x.IdUsuario == id);


        public async Task<Usuario> GetAsync(string key, string sistema)

            => await _seguridadfContext.Usuario.Include(us => us.UsuarioSistemas).Include(ur=>ur.UsuarioRols).FirstOrDefaultAsync(x => x.Key == key  && x.Sistema == sistema);

        public async Task<List<Usuario>> GetByNombreApellidosAsync(string nombre, string apellidos, string sistema)
            => await _seguridadfContext.Usuario
                .Include(us => us.UsuarioSistemas)
                .Include(ur => ur.UsuarioRols)
                .Where(x => x.Sistema == sistema
                    && (string.IsNullOrWhiteSpace(nombre) || EF.Functions.Like(x.Nombres, $"%{nombre}%"))
                    && (string.IsNullOrWhiteSpace(apellidos) || EF.Functions.Like(x.Apellidos, $"%{apellidos}%")))
                .ToListAsync();

        public async Task<bool> EncontrarAsync(string key, string sistema)
        {
           return await _seguridadfContext.Usuario.AsNoTracking().AnyAsync(p => p.Key == key && p.Sistema== sistema);
        }
        public async Task<bool> EncontrarMailAsync(string mail, string sistema)
        {
            return await _seguridadfContext.Usuario.AsNoTracking().AnyAsync(p => p.Email == mail&& p.Sistema == sistema);
        }

        public async Task AddAsync(Usuario user)
            =>  await _seguridadfContext.Usuario.AddAsync(user);

        public Usuario Update(Usuario user)
        {
            _seguridadfContext.Usuario.Update(user);
            
            return user;
        }
        public List<Usuario> ObtenerTodosAsync(string sistema)
        {
            return _seguridadfContext.Usuario.AsNoTracking().Where(x => x.Sistema== sistema).Include(item=>item.UsuarioRols).ToList();
        }



    }
}
