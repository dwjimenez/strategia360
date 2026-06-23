using Microsoft.EntityFrameworkCore;
using Strategia.Service.Api.Models;
using Strategia.Service.Api.Persistences;

namespace  Strategia.Service.Api.Repositories
{
    public class VoteIntentOptionRepository : IVoteIntentOptionRepository
    {
        private readonly ContextDatabase _context;

        public VoteIntentOptionRepository(ContextDatabase context)
        {
            _context = context;
        }

        public async Task<List<IntencionVotoOpcion>> GetByStoreAsync(string tienda)
        {
            var normalizedStore = tienda.Trim().ToUpper();

            return await _context.IntencionVotoOpcion
                .AsNoTracking()
                .Where(x => x.Tienda != null
                    && x.Tienda.Trim().ToUpper() == normalizedStore
                    && x.Activo != false)
                .OrderBy(x => x.CodigoDignidad)
                .ThenBy(x => x.Orden)
                .ThenBy(x => x.NombreOpcion)
                .ToListAsync();
        }
    }
}
