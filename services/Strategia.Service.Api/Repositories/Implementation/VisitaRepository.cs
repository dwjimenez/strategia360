using Strategia.Service.Api.Persistences;
using Strategia.Service.Api.Models;
using Microsoft.EntityFrameworkCore;


namespace  Strategia.Service.Api.Repositories
{
    public class VisitaRepository : IVisitaRepository
    {
        private readonly ContextDatabase _Context;
        
        public VisitaRepository(ContextDatabase Context )
        {
            _Context = Context;
        }


        public async Task<Visita> NuevaAsync(
                Ciudadano ciudadano,
                Visita visita,
                List<VisitaIntencionVoto> visitaIntencionesVoto
            )
        {
            await using var transaction = await _Context.Database.BeginTransactionAsync();

            try
            {
                await _Context.Ciudadano.AddAsync(ciudadano);
                await _Context.SaveChangesAsync();

                visita.IdCiudadano = ciudadano.IdCiudadano;

                await _Context.Visita.AddAsync(visita);
                await _Context.SaveChangesAsync();

                if (visitaIntencionesVoto != null && visitaIntencionesVoto.Any())
                {
                    foreach (var item in visitaIntencionesVoto)
                    {
                        item.IdVisita = visita.IdVisita;
                    }

                    await _Context.VisitaIntencionVoto.AddRangeAsync(visitaIntencionesVoto);
                    await _Context.SaveChangesAsync();
                }

                await transaction.CommitAsync();

                return visita;
            }
            catch
            {
                await transaction.RollbackAsync();
                throw;
            }
        }

        public async Task<Visita> ActualizarAsync(
                Ciudadano ciudadanoEditado,
                Visita nuevaVisita,
                List<VisitaIntencionVoto> nuevasIntencionesVoto)
        {
            await using var transaction = await _Context.Database.BeginTransactionAsync();

            try
            {
                // 1. Buscar ciudadano existente
                var ciudadanoActual = await _Context.Ciudadano.FirstOrDefaultAsync(x => x.IdCiudadano == ciudadanoEditado.IdCiudadano);

                if (ciudadanoActual == null)
                    throw new Exception("No se encontró el ciudadano que desea actualizar.");

                // 2. Actualizar datos del ciudadano
                _Context.Entry(ciudadanoActual).CurrentValues.SetValues(ciudadanoEditado);

                // 3. Crear nueva visita relacionada al ciudadano existente
                nuevaVisita.IdCiudadano = ciudadanoActual.IdCiudadano;

                await _Context.Visita.AddAsync(nuevaVisita);
                

                // 4. Crear nueva lista de intenciones de voto para la nueva visita
                if (nuevasIntencionesVoto?.Any() == true)
                {
                    foreach (var item in nuevasIntencionesVoto)
                    {
                        item.IdVisita = nuevaVisita.IdVisita;
                    }

                    await _Context.VisitaIntencionVoto.AddRangeAsync(nuevasIntencionesVoto);
                }

                // 5. Guardar todo
                await _Context.SaveChangesAsync();

                await transaction.CommitAsync();

                return nuevaVisita;
            }
            catch
            {
                await transaction.RollbackAsync();
                throw;
            }
        }

        public async Task<List<Visita>> ConsultarCiudadanosAsync(string tienda, string ciudad, string? nombres, string? apellidos)
        {
            var tiendaNormalizada = tienda.Trim();
            var ciudadNormalizada = ciudad.Trim();
            var nombresNormalizados = nombres?.Trim();
            var apellidosNormalizados = apellidos?.Trim();

            var query = _Context.Visita
                .AsNoTracking()
                .Include(x => x.IdCiudadanoNavigation)
                .Include(x => x.VisitaIntencionVotos)
                .Where(x => x.Tienda == tiendaNormalizada
                    && x.Ciudad == ciudadNormalizada
                    && x.Activo == true);

            if (!string.IsNullOrWhiteSpace(nombresNormalizados))
            {
                query = query.Where(x => EF.Functions.Like(x.IdCiudadanoNavigation.Nombres, $"%{nombresNormalizados}%"));
            }

            if (!string.IsNullOrWhiteSpace(apellidosNormalizados))
            {
                query = query.Where(x => x.IdCiudadanoNavigation.Apellidos != null
                    && EF.Functions.Like(x.IdCiudadanoNavigation.Apellidos, $"%{apellidosNormalizados}%"));
            }

            return await query
                .OrderByDescending(x => x.FechaVisita)
                .ThenBy(x => x.IdCiudadanoNavigation.Apellidos)
                .ThenBy(x => x.IdCiudadanoNavigation.Nombres)
                .ToListAsync();
        }

        public async Task<List<Ciudadano>> ConsultarCiudadanosCercanosAsync(string tienda, string ciudad, decimal posX, decimal posY, double distanciaMetros)
        {
            var tiendaNormalizada = tienda.Trim();
            var ciudadNormalizada = ciudad.Trim();

            var visitas = await _Context.Visita
                .AsNoTracking()
                .Include(x => x.IdCiudadanoNavigation)
                .Include(x => x.VisitaIntencionVotos)
                .Where(x => x.Tienda == tiendaNormalizada
                    && x.Ciudad == ciudadNormalizada
                    && x.Activo == true
                    && x.IdCiudadanoNavigation.Activo == true
                    && x.PosX.HasValue
                    && x.PosY.HasValue)
                .ToListAsync();

            return visitas
                .Select(x => new
                {
                    Visita = x,
                    Distancia = CalcularDistanciaMetros(
                        (double)posX,
                        (double)posY,
                        (double)x.PosX!.Value,
                        (double)x.PosY!.Value)
                })
                .Where(x => x.Distancia <= distanciaMetros)
                .GroupBy(x => x.Visita.IdCiudadano)
                .Select(x =>
                {
                    var ciudadano = x.First().Visita.IdCiudadanoNavigation;
                    ciudadano.Visita = x
                        .OrderByDescending(v => v.Visita.FechaVisita)
                        .Select(v => v.Visita)
                        .ToList();
                    return new
                    {
                        Ciudadano = ciudadano,
                        Distancia = x.Min(v => v.Distancia)
                    };
                })
                .OrderBy(x => x.Distancia)
                .ThenBy(x => x.Ciudadano.Apellidos)
                .ThenBy(x => x.Ciudadano.Nombres)
                .Select(x => x.Ciudadano)
                .ToList();
        }

        public async Task<List<Visita>> ConsultarVisitasPorUsuarioYFechasAsync(
            string tienda,
            string codigoUsuario,
            DateTime fechaDesde,
            DateTime fechaHasta)
        {
            var tiendaNormalizada = tienda.Trim();
            var codigoUsuarioNormalizado = codigoUsuario.Trim();
            var fechaInicio = fechaDesde.Date;
            var fechaFinExclusiva = fechaHasta.Date.AddDays(1);

            return await _Context.Visita
                .AsNoTracking()
                .Include(x => x.IdCiudadanoNavigation)
                .Include(x => x.VisitaIntencionVotos)
                .Where(x => x.Tienda == tiendaNormalizada
                    && x.CodigoUsuario == codigoUsuarioNormalizado
                    && x.FechaVisita >= fechaInicio
                    && x.FechaVisita < fechaFinExclusiva
                    && x.Activo == true)
                .OrderByDescending(x => x.FechaVisita)
                .ToListAsync();
        }

        private static double CalcularDistanciaMetros(double lat1, double lon1, double lat2, double lon2)
        {
            const double radioTierraMetros = 6371000d;
            var dLat = GradosARadianes(lat2 - lat1);
            var dLon = GradosARadianes(lon2 - lon1);
            var origenLat = GradosARadianes(lat1);
            var destinoLat = GradosARadianes(lat2);

            var a = Math.Sin(dLat / 2) * Math.Sin(dLat / 2) +
                    Math.Cos(origenLat) * Math.Cos(destinoLat) *
                    Math.Sin(dLon / 2) * Math.Sin(dLon / 2);

            var c = 2 * Math.Atan2(Math.Sqrt(a), Math.Sqrt(1 - a));

            return radioTierraMetros * c;
        }

        private static double GradosARadianes(double grados)
        {
            return grados * (Math.PI / 180d);
        }


    }
}
