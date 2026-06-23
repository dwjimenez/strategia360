using Strategia.Service.Api.DTOs;

namespace  Strategia.Service.Api.Services
{
    public interface ITerritoryService
    {
        Task<List<TerritoryDto>> GetByStoreAndCityAsync(string tienda, string ciudad);
    }
}
