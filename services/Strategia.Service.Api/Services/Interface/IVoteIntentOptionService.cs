using Strategia.Service.Api.DTOs;

namespace  Strategia.Service.Api.Services
{
    public interface IVoteIntentOptionService
    {
        Task<List<VoteIntentOptionGroupDto>> GetByStoreAsync(string tienda, bool includeInactive);
    }
}
