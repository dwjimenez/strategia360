using AutoMapper;
using Strategia360.Service.Api.DTOs;
using Strategia360.Service.Api.Models;
using Strategia360.Service.Api.Persistences;
using Strategia360.Service.Api.Repositories;


namespace Strategia360.Service.Api.Services
{
    public class VisitaService : IVisitaService
    {
        private readonly IVisitaRepository _visitaRepository;
        private readonly IMapper _mapper;
        private readonly ContextDatabase _contextDatabase;
        public VisitaService(
            IVisitaRepository visitaRepository,
            IMapper mapper,
           ContextDatabase contextDatabase            )
        {
            _visitaRepository = visitaRepository;
            _mapper = mapper;
            _contextDatabase = contextDatabase;
        }

        private void ValidarRegistroCiudadanoVisita(RegistrarCiudadanoVisitaRequest request)
        {
            if (string.IsNullOrWhiteSpace(request.Tienda))
                throw new Exception("La tienda es obligatoria.");

            if (string.IsNullOrWhiteSpace(request.Nombres))
                throw new Exception("El nombre del ciudadano es obligatorio.");

            if (string.IsNullOrWhiteSpace(request.NumeroCelular))
                throw new Exception("El número celular es obligatorio.");

            if (string.IsNullOrWhiteSpace(request.Genero))
                throw new Exception("El género es obligatorio.");

            if (request.Genero != "masculino" && request.Genero != "femenino")
                throw new Exception("El género debe ser masculino o femenino.");

            if (string.IsNullOrWhiteSpace(request.Parroquia))
                throw new Exception("La parroquia es obligatoria.");

            if (string.IsNullOrWhiteSpace(request.Barrio))
                throw new Exception("El barrio es obligatorio.");

            if (string.IsNullOrWhiteSpace(request.Direccion))
                throw new Exception("La dirección es obligatoria.");

            if (string.IsNullOrWhiteSpace(request.TemasInteres))
                throw new Exception("Los temas de interés son obligatorios.");

            if (!string.IsNullOrWhiteSpace(request.ResultadoVisita))
            {
                var resultadosPermitidos = new[] { "PROMOVIDO", "INDECISO", "NO" };

                if (!resultadosPermitidos.Contains(request.ResultadoVisita))
                    throw new Exception("El resultado de visita debe ser PROMOVIDO, INDECISO o NO.");
            }

            var estadosPermitidos = new[] { "PENDIENTE", "SINCRONIZADO", "ERROR" };

            if (!estadosPermitidos.Contains(request.EstadoSync))
                throw new Exception("El estado de sincronización debe ser PENDIENTE, SINCRONIZADO o ERROR.");

            var dignidadesPermitidas = new[] { "ALCALDE", "CONCEJAL", "VOCALES" };

            foreach (var item in request.IntencionesVoto)
            {
                if (!dignidadesPermitidas.Contains(item.CodigoDignidad))
                    throw new Exception($"La dignidad {item.CodigoDignidad} no es válida.");
            }
        }

        public async Task<bool> NuevoAsync(RegistrarCiudadanoVisitaRequest request)
        {
            ValidarRegistroCiudadanoVisita(request);

            var fechaActual = DateTime.Now;

            var ciudadano = new Ciudadano
            {
                Tienda = request.Tienda,
                Ciudad = request.Ciudad,

                CodigoCenturia = request.CodigoCenturia,
                CodigoTerritorio = request.CodigoTerritorio,
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

            var visita = new Visita
            {
                Tienda = request.Tienda,
                Ciudad = request.Ciudad,

                CodigoUsuario = request.CodigoUsuario,
                CodigoCenturia = request.CodigoCenturia,
                CodigoTerritorio = request.CodigoTerritorio,

                FechaVisita = fechaActual,

                PersonasMayoresCasa = request.PersonasMayoresCasa,
                ProblemaPrincipal = request.ProblemaPrincipal,
                ProblemaTexto = request.ProblemaTexto,

                ResultadoVisita = request.ResultadoVisita,
                RazonNoIndeciso = request.RazonNoIndeciso,

                TemasInteres = request.TemasInteres,
                TemaInteresReal = request.TemaInteresReal,

                TieneReferido = request.TieneReferido,
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

            var intencionesVoto = request.IntencionesVoto
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

            await _visitaRepository.NuevaAsync(
                ciudadano,
                visita,
                intencionesVoto
            );

            return true;
        }

        public async Task<bool> ActualizarAsync(RegistrarCiudadanoVisitaRequest request)
        {
            ValidarRegistroCiudadanoVisita(request);

            if (request.IdCiudadano <= 0)
                throw new Exception("El IdCiudadano es obligatorio para actualizar el ciudadano.");

            var fechaActual = DateTime.Now;

            var ciudadano = new Ciudadano
            {
                IdCiudadano = request.IdCiudadano,

                Tienda = request.Tienda,
                Ciudad = request.Ciudad,

                CodigoCenturia = request.CodigoCenturia,
                CodigoTerritorio = request.CodigoTerritorio,
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

                Activo = true
            };

            var visita = new Visita
            {
                Tienda = request.Tienda,
                Ciudad = request.Ciudad,

                CodigoUsuario = request.CodigoUsuario,
                CodigoCenturia = request.CodigoCenturia,
                CodigoTerritorio = request.CodigoTerritorio,

                FechaVisita = fechaActual,

                PersonasMayoresCasa = request.PersonasMayoresCasa,
                ProblemaPrincipal = request.ProblemaPrincipal,
                ProblemaTexto = request.ProblemaTexto,

                ResultadoVisita = request.ResultadoVisita,
                RazonNoIndeciso = request.RazonNoIndeciso,

                TemasInteres = request.TemasInteres,
                TemaInteresReal = request.TemaInteresReal,

                TieneReferido = request.TieneReferido,
                ReferidoNombres = request.ReferidoNombres,
                ReferidoTelefono = request.ReferidoTelefono,

                NotaEncuestador = request.NotaEncuestador,

                PosX = request.PosX,
                PosY = request.PosY,

                EstadoSync = string.IsNullOrWhiteSpace(request.EstadoSync)
                    ? "SINCRONIZADO"
                    : request.EstadoSync,

                Activo = true
            };

            var intencionesVoto = request.IntencionesVoto == null
                ? new List<VisitaIntencionVoto>()
                : request.IntencionesVoto
                    .Where(x => !string.IsNullOrWhiteSpace(x.CodigoDignidad))
                    .GroupBy(x => x.CodigoDignidad)
                    .Select(x => x.First())
                    .Select(x => new VisitaIntencionVoto
                    {
                        CodigoDignidad = x.CodigoDignidad,
                        CodigoIntencionVotoOpcion = x.CodigoIntencionVotoOpcion,
                        Observacion = x.Observacion
                    })
                    .ToList();

            await _visitaRepository.ActualizarAsync(
                ciudadano,
                visita,
                intencionesVoto
            );
            return true;
        }

    }
}