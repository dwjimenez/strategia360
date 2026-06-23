using AutoMapper;
using Strategia.Service.Api.DTOs;
using Strategia.Service.Api.Repositories;

namespace  Strategia.Service.Api.Services
{
    public class CenturiaService : ICenturiaService
    {
        private readonly ICenturiaRepository _centuriaRepository;
        private readonly IMapper _mapper;

        public CenturiaService(ICenturiaRepository centuriaRepository, IMapper mapper)
        {
            _centuriaRepository = centuriaRepository;
            _mapper = mapper;
        }

        public async Task<List<CenturiaDto>> GetByStoreAndCityAsync(string tienda, string ciudad)
        {
            if (string.IsNullOrWhiteSpace(tienda))
                throw new Exception("La tienda es obligatoria.");

            if (string.IsNullOrWhiteSpace(ciudad))
                throw new Exception("La ciudad es obligatoria.");

            var centurias = await _centuriaRepository.GetByStoreAndCityAsync(tienda, ciudad);

            return _mapper.Map<List<CenturiaDto>>(centurias);
        }
    }
}
