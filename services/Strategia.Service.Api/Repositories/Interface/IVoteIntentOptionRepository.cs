using Strategia.Service.Api.DTOs;

namespace  Strategia.Service.Api.Repositories
{
    public interface IVoteIntentOptionRepository
    {
        Task<List<VoteIntentOptionGroupDto>> GetByStoreAsync(string tienda, bool includeInactive);
    }
}
