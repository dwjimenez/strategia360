using Strategia.Service.Api.Models;

namespace  Strategia.Service.Api.Repositories
{
    public interface ICenturiaRepository
    {
        Task<List<Centuria>> GetByStoreAndCityAsync(string tienda, string ciudad, bool includeInactive);
    }
}
