using Strategia.Service.Api.Models;

namespace  Strategia.Service.Api.Repositories
{
    public interface IVoteIntentOptionRepository
    {
        Task<List<IntencionVotoOpcion>> GetByStoreAsync(string tienda, bool includeInactive);
    }
}
