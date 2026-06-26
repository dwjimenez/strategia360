using Strategia.Service.Api.DTOs;

namespace  Strategia.Service.Api.Services
{
    public interface ICenturiaService
    {
        Task<List<CenturiaDto>> GetByStoreAndCityAsync(string tienda, string ciudad, bool includeInactive);
    }
}
