using AutoMapper;
using Strategia.Service.Api.DTOs;
using Strategia.Service.Api.Repositories;

namespace  Strategia.Service.Api.Services
{
    public class VoteIntentOptionService : IVoteIntentOptionService
    {
        private readonly IVoteIntentOptionRepository _intencionVotoOpcionRepository;
        private readonly IMapper _mapper;

        public VoteIntentOptionService(IVoteIntentOptionRepository intencionVotoOpcionRepository, IMapper mapper)
        {
            _intencionVotoOpcionRepository = intencionVotoOpcionRepository;
            _mapper = mapper;
        }

        public async Task<List<VoteIntentOptionDto>> GetByStoreAsync(string tienda, bool includeInactive)
        {
            if (string.IsNullOrWhiteSpace(tienda))
                throw new Exception("La tienda es obligatoria.");

            var opciones = await _intencionVotoOpcionRepository.GetByStoreAsync(tienda, includeInactive);

            return _mapper.Map<List<VoteIntentOptionDto>>(opciones);
        }
    }
}
