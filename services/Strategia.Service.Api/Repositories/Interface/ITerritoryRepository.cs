using Strategia.Service.Api.Models;

namespace  Strategia.Service.Api.Repositories
{
    public interface ITerritoryRepository
    {
        Task<List<Territorio>> GetByStoreAndCityAsync(string tienda, string ciudad);
    }
}
