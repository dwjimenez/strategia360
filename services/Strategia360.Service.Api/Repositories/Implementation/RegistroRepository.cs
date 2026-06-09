
using DFast.Seguridad.Api.Models;
using DFast.Seguridad.Api.Persistences;
using Microsoft.EntityFrameworkCore;

namespace DFast.Seguridad.Api.Repositories
{
    public class RegistroRepository : IRegistroRepository
    {
        private readonly ContextDatabase _seguridadfContext;

        public RegistroRepository(ContextDatabase seguridadfContext)
        {
            _seguridadfContext = seguridadfContext;
        }


        public async Task<Registro> GetAsync(int id) =>
            await _seguridadfContext.Registro.FirstOrDefaultAsync(x => x.IdUsuario == id);

        public async Task<Registro> ObtenerxImeiAsync(string sistema, string imei) =>
        await _seguridadfContext.Registro.AsNoTracking().FirstOrDefaultAsync(x => x.Sistema == sistema && x.Imei == imei);

        public async Task<Registro> ObtenerxIdUsuarioAsync(string sistema, int idUsuario) =>
      await _seguridadfContext.Registro.AsNoTracking().FirstOrDefaultAsync(x => x.Sistema == sistema && x.IdUsuario == idUsuario);


        public async Task AddAsync(Registro user)
            =>  await _seguridadfContext.Registro.AddAsync(user);


        public Registro Update(Registro user)
        {
            _seguridadfContext.Registro.Update(user);
            return user;
        }
    }
}