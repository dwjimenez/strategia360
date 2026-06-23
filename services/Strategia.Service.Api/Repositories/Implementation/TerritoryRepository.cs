using Microsoft.EntityFrameworkCore;
using Strategia.Service.Api.Models;
using Strategia.Service.Api.Persistences;

namespace  Strategia.Service.Api.Repositories
{
    public class TerritoryRepository : ITerritoryRepository
    {
        private readonly ContextDatabase _context;

        public TerritoryRepository(ContextDatabase context)
        {
            _context = context;
        }

        public async Task<List<Territorio>> GetByStoreAndCityAsync(string tienda, string ciudad)
        {
            var normalizedStore = tienda.Trim().ToUpper();
            var normalizedCity = ciudad.Trim().ToUpper();

            return await _context.Territorio
                .AsNoTracking()
                .Where(x => x.Tienda != null
                    && x.Ciudad != null
                    && x.Tienda.Trim().ToUpper() == normalizedStore
                    && x.Ciudad.Trim().ToUpper() == normalizedCity
                    && x.Activo != false)
                .OrderBy(x => x.NombreTerritorio)
                .ToListAsync();
        }
    }
}
