using AutoMapper;
using Strategia.Service.Api.DTOs;
using Strategia.Service.Api.Repositories;

namespace  Strategia.Service.Api.Services
{
    public class TerritoryService : ITerritoryService
    {
        private readonly ITerritoryRepository _territorioRepository;
        private readonly IMapper _mapper;

        public TerritoryService(ITerritoryRepository territorioRepository, IMapper mapper)
        {
            _territorioRepository = territorioRepository;
            _mapper = mapper;
        }

        public async Task<List<TerritoryDto>> GetByStoreAndCityAsync(string tienda, string ciudad, bool includeInactive)
        {
            if (string.IsNullOrWhiteSpace(tienda))
                throw new Exception("La tienda es obligatoria.");

            if (string.IsNullOrWhiteSpace(ciudad))
                throw new Exception("La ciudad es obligatoria.");

            var territorios = await _territorioRepository.GetByStoreAndCityAsync(tienda, ciudad, includeInactive);

            return _mapper.Map<List<TerritoryDto>>(territorios);
        }
    }
}
