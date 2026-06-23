using Microsoft.EntityFrameworkCore;
using Strategia.Service.Api.Models;
using Strategia.Service.Api.Persistences;

namespace  Strategia.Service.Api.Repositories
{
    public class CenturiaRepository : ICenturiaRepository
    {
        private readonly ContextDatabase _context;

        public CenturiaRepository(ContextDatabase context)
        {
            _context = context;
        }

        public async Task<List<Centuria>> GetByStoreAndCityAsync(string tienda, string ciudad)
        {
            var normalizedStore = tienda.Trim().ToUpper();
            var normalizedCity = ciudad.Trim().ToUpper();

            return await _context.Centuria
                .AsNoTracking()
                .Where(x =>
                    x.Tienda.Trim().ToUpper() == normalizedStore
                    && x.Ciudad.Trim().ToUpper() == normalizedCity
                    && x.Activo != false)
                .OrderBy(x => x.NombreCenturia)
                .ToListAsync();
        }
    }
}
