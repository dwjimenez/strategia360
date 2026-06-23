using Strategia.Service.Api.DTOs;

namespace  Strategia.Service.Api.Services
{
    public interface IVoteIntentOptionService
    {
        Task<List<VoteIntentOptionDto>> GetByStoreAsync(string tienda);
    }
}
