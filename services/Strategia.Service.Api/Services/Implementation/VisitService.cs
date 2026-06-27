using AutoMapper;
using Strategia.Service.Api.DTOs;

using Strategia.Service.Api.Models;
using Strategia.Service.Api.Persistences;
using Strategia.Service.Api.Repositories;

namespace  Strategia.Service.Api.Services
{
    public class VisitService : IVisitService
    {
        private readonly IVisitRepository _visitaRepository;
        private readonly IMapper _mapper;
        private readonly ContextDatabase _contextDatabase;

        public VisitService(
            IVisitRepository visitaRepository,
            IMapper mapper,
            ContextDatabase contextDatabase)
        {
            _visitaRepository = visitaRepository;
            _mapper = mapper;
            _contextDatabase = contextDatabase;
        }

        private void ValidarRegistroCiudadanoVisita(RegistrarCiudadanoVisitaRequest request)
        {
            if (string.IsNullOrWhiteSpace(request.Tienda))
                throw new Exception("La tienda es obligatoria.");

            if (string.IsNullOrWhiteSpace(request.Ciudad))
                throw new Exception("La ciudad es obligatoria.");

            if (string.IsNullOrWhiteSpace(request.Nombres))
                throw new Exception("El nombre del ciudadano es obligatorio.");

            if (string.IsNullOrWhiteSpace(request.NumeroCelular))
                throw new Exception("El numero celular es obligatorio.");

            if (string.IsNullOrWhiteSpace(request.Genero))
                throw new Exception("El genero es obligatorio.");

            if (request.Genero != "masculino" && request.Genero != "femenino")
                throw new Exception("El genero debe ser masculino o femenino.");

            if (string.IsNullOrWhiteSpace(request.Parroquia))
                throw new Exception("La parroquia es obligatoria.");

            if (string.IsNullOrWhiteSpace(request.Barrio))
                throw new Exception("El barrio es obligatorio.");

            if (string.IsNullOrWhiteSpace(request.Direccion))
                throw new Exception("La direccion es obligatoria.");


            
            var estadosPermitidos = new[] { "PENDIENTE", "SINCRONIZADO", "ERROR" };

            if (!estadosPermitidos.Contains(request.EstadoSync))
                throw new Exception("El estado de sincronizacion debe ser PENDIENTE, SINCRONIZADO o ERROR.");

            var dignidadesPermitidas = new[] { "ALCALDE", "CONCEJAL", "VOCALES" };

            var intencionesVoto = request.IntencionesVoto ?? new List<RegistrarIntencionVotoRequest>();

            foreach (var item in intencionesVoto)
            {
                if (!dignidadesPermitidas.Contains(item.CodigoDignidad))
                    throw new Exception($"La dignidad {item.CodigoDignidad} no es valida.");
            }

          
            if (string.IsNullOrWhiteSpace(request.ReferidoNombres))
                throw new Exception("El nombre del referido es obligatorio cuando TieneReferido es verdadero.");

            if (string.IsNullOrWhiteSpace(request.ReferidoTelefono))
                throw new Exception("El telefono del referido es obligatorio cuando TieneReferido es verdadero.");
          
        }

        private Ciudadano ConstruirCiudadano(RegistrarCiudadanoVisitaRequest request)
        {
            return new Ciudadano
            {
                IdCiudadano = request.IdCiudadano ?? 0,
                Tienda = request.Tienda,
                Ciudad = request.Ciudad,
                CodigoTerritorio = request.CodigoTerritorio,
                CodigoCenturia = request.CodigoCenturia,
                Codigo = request.Codigo,
                Nombres = request.Nombres,
                Apellidos = request.Apellidos,
                NumeroCelular = request.NumeroCelular,
                Genero = request.Genero,
                MiembrosFamilia = request.MiembrosFamilia,
                MiembrosVotan = request.MiembrosVotan,
                MiembrosDiscapacidad = request.MiembrosDiscapacidad,
                Parroquia = request.Parroquia,
                Barrio = request.Barrio,
                Direccion = request.Direccion,
                PosX = request.PosX,
                PosY = request.PosY,
                Activo = true,
            };
        }

        private Visita ConstruirVisita(RegistrarCiudadanoVisitaRequest request, DateTime fechaActual)
        {
            return new Visita
            {
                Tienda = request.Tienda,
                Ciudad = request.Ciudad,
                CodigoUsuario = request.CodigoUsuario,
                CodigoCenturia = request.CodigoCenturia,
                CodigoTerritorio = request.CodigoTerritorio,
                FechaVisita = fechaActual,
                ProblemaFamiliar = request.ProblemaFamiliar,
                ProblemaInterno = request.ProblemaInterno,
                TemaInteresReal = request.TemaInteresReal,
                ReferidoNombres = request.ReferidoNombres,
                ReferidoTelefono = request.ReferidoTelefono,
                NotaEncuestador = request.NotaEncuestador,
                PosX = request.PosX,
                PosY = request.PosY,
                EstadoSync = string.IsNullOrWhiteSpace(request.EstadoSync)
                    ? "SINCRONIZADO"
                    : request.EstadoSync,
                Activo = true,
            };
        }

        private List<VisitaIntencionVoto> ConstruirIntencionesVoto(RegistrarCiudadanoVisitaRequest request)
        {
            return (request.IntencionesVoto ?? new List<RegistrarIntencionVotoRequest>())
                .Where(x => !string.IsNullOrWhiteSpace(x.CodigoDignidad))
                .GroupBy(x => x.CodigoDignidad)
                .Select(x => x.First())
                .Select(x => new VisitaIntencionVoto
                {
                    CodigoDignidad = x.CodigoDignidad,
                    CodigoIntencionVotoOpcion = x.CodigoIntencionVotoOpcion,
                    Observacion = x.Observacion,
                })
                .ToList();
        }

      

        public async Task<bool> SaveCitizenVisitAsync(RegistrarCiudadanoVisitaRequest request)
        {
            // ValidarRegistroCiudadanoVisita(request);

            var fechaActual = DateTime.Now;
            var ciudadano = ConstruirCiudadano(request);
            var visita = ConstruirVisita(request, fechaActual);
            var intencionesVoto = ConstruirIntencionesVoto(request);

            await _visitaRepository.SaveCitizenAndVisitAsync(
                ciudadano,
                visita,
                intencionesVoto);

            return true;
        }

        public async Task<List<VisitaDto>> GetCitizensAsync(string tienda, string ciudad, string? nombres, string? apellidos, bool includeInactive)
        {
            if (string.IsNullOrWhiteSpace(tienda))
                throw new Exception("La tienda es obligatoria.");

            if (string.IsNullOrWhiteSpace(ciudad))
                throw new Exception("La ciudad es obligatoria.");

            var visitas = await _visitaRepository.GetCitizensAsync(tienda, ciudad, nombres, apellidos, includeInactive);

            return _mapper.Map<List<VisitaDto>>(visitas);
        }

        public async Task<List<CiudadanoDto>> GetNearbyCitizensAsync(string tienda, string ciudad, decimal posX, decimal posY, double distanciaMetros, bool includeInactive)
        {
            if (string.IsNullOrWhiteSpace(tienda))
                throw new Exception("La tienda es obligatoria.");

            if (string.IsNullOrWhiteSpace(ciudad))
                throw new Exception("La ciudad es obligatoria.");

            if (distanciaMetros <= 0)
                throw new Exception("La distancia en metros debe ser mayor a cero.");

            var ciudadanos = await _visitaRepository.GetNearbyCitizensAsync(tienda, ciudad, posX, posY, distanciaMetros, includeInactive);

            return _mapper.Map<List<CiudadanoDto>>(ciudadanos);
        }

        public async Task<List<VisitaDto>> GetVisitsByUserAndDateRangeAsync(string tienda, string codigoUsuario, DateTime fechaDesde, DateTime fechaHasta, bool includeInactive)
        {
            if (string.IsNullOrWhiteSpace(tienda))
                throw new Exception("La tienda es obligatoria.");

            if (string.IsNullOrWhiteSpace(codigoUsuario))
                throw new Exception("El codigo de usuario es obligatorio.");

            if (fechaHasta.Date < fechaDesde.Date)
                throw new Exception("La fecha hasta no puede ser menor a la fecha desde.");

            var visitas = await _visitaRepository.GetVisitsByUserAndDateRangeAsync(
                tienda,
                codigoUsuario,
                fechaDesde,
                fechaHasta,
                includeInactive);

            return _mapper.Map<List<VisitaDto>>(visitas);
        }
    }
}
