using Strategia.Service.Api.DTOs;
using Strategia.Service.Api.Repositories;

namespace  Strategia.Service.Api.Services
{
    public class VoteIntentOptionService : IVoteIntentOptionService
    {
        private readonly IVoteIntentOptionRepository _intencionVotoOpcionRepository;

        public VoteIntentOptionService(IVoteIntentOptionRepository intencionVotoOpcionRepository)
        {
            _intencionVotoOpcionRepository = intencionVotoOpcionRepository;
        }

        public async Task<List<VoteIntentOptionGroupDto>> GetByStoreAsync(string tienda, bool includeInactive)
        {
            if (string.IsNullOrWhiteSpace(tienda))
                throw new Exception("La tienda es obligatoria.");

            return await _intencionVotoOpcionRepository.GetByStoreAsync(tienda, includeInactive);
        }
    }
}
