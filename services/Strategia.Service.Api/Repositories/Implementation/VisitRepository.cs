using Strategia.Service.Api.Persistences;
using Strategia.Service.Api.Models;
using Microsoft.EntityFrameworkCore;


namespace  Strategia.Service.Api.Repositories
{
    public class VisitRepository : IVisitRepository
    {
        private readonly ContextDatabase _Context;
        
        public VisitRepository(ContextDatabase Context )
        {
            _Context = Context;
        }


       

        public async Task<Visita> SaveCitizenAndVisitAsync(
            Ciudadano ciudadano,
            Visita visita,
            List<VisitaIntencionVoto> visitaIntencionesVoto)
        {
            await using var transaction = await _Context.Database.BeginTransactionAsync();

            try
            {
                Ciudadano? ciudadanoActual = null;

                if (ciudadano.IdCiudadano > 0)
                {
                    ciudadanoActual = await _Context.Ciudadano
                        .FirstOrDefaultAsync(x => x.IdCiudadano == ciudadano.IdCiudadano);
                }

                if (ciudadanoActual == null && !string.IsNullOrWhiteSpace(ciudadano.Codigo))
                {
                    ciudadanoActual = await _Context.Ciudadano
                        .FirstOrDefaultAsync(x => x.Tienda == ciudadano.Tienda
                            && x.Ciudad == ciudadano.Ciudad
                            && x.Codigo == ciudadano.Codigo);
                }

                //if (ciudadanoActual == null && !string.IsNullOrWhiteSpace(ciudadano.NumeroCelular))
                //{
                //    ciudadanoActual = await _Context.Ciudadano
                //        .FirstOrDefaultAsync(x => x.Tienda == ciudadano.Tienda
                //            && x.Ciudad == ciudadano.Ciudad
                //            && x.NumeroCelular == ciudadano.NumeroCelular);
                //}

                if (ciudadanoActual == null)
                {
                    await _Context.Ciudadano.AddAsync(ciudadano);
                    await _Context.SaveChangesAsync();
                    ciudadanoActual = ciudadano;
                }
                else
                {
                    ciudadano.IdCiudadano = ciudadanoActual.IdCiudadano;
                    _Context.Entry(ciudadanoActual).CurrentValues.SetValues(ciudadano);
                    await _Context.SaveChangesAsync();
                }

                visita.IdCiudadano = ciudadanoActual.IdCiudadano;

                await _Context.Visita.AddAsync(visita);
                await _Context.SaveChangesAsync();

                if (visitaIntencionesVoto?.Any() == true)
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

        public async Task<List<Visita>> GetCitizensAsync(string tienda, string ciudad, string? nombres, string? apellidos, bool includeInactive)
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
                    && (includeInactive || x.Activo == true));

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

        public async Task<List<Ciudadano>> GetNearbyCitizensAsync(string tienda, string ciudad, decimal posX, decimal posY, double distanciaMetros, bool includeInactive)
        {
            var tiendaNormalizada = tienda.Trim();
            var ciudadNormalizada = ciudad.Trim();

            var visitas = await _Context.Visita
                .AsNoTracking()
                .Include(x => x.IdCiudadanoNavigation)
                .Include(x => x.VisitaIntencionVotos)
                .Where(x => x.Tienda == tiendaNormalizada
                    && x.Ciudad == ciudadNormalizada
                    && (includeInactive || x.Activo == true)
                    && (includeInactive || x.IdCiudadanoNavigation.Activo == true)
                    && x.PosX.HasValue
                    && x.PosY.HasValue)
                .ToListAsync();

            return visitas
                .Select(x => new
                {
                    Visita = x,
                    Distancia = CalculateDistanceInMeters(
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

        public async Task<List<Visita>> GetVisitsByUserAndDateRangeAsync(
            string tienda,
            string codigoUsuario,
            DateTime fechaDesde,
            DateTime fechaHasta,
            bool includeInactive)
        {
            var tiendaNormalizada = tienda.Trim().ToUpper();
            var codigoUsuarioNormalizado = codigoUsuario.Trim().ToUpper();
            var fechaInicio = fechaDesde.Date;
            var fechaFinExclusiva = fechaHasta.Date.AddDays(1);

            return await _Context.Visita
                .AsNoTracking()
                .Include(x => x.IdCiudadanoNavigation)
                .Include(x => x.VisitaIntencionVotos)
                .Where(x => x.Tienda != null
                    && x.CodigoUsuario != null
                    && x.Tienda.Trim().ToUpper() == tiendaNormalizada
                    && x.CodigoUsuario.Trim().ToUpper() == codigoUsuarioNormalizado
                    && x.FechaVisita >= fechaInicio
                    && x.FechaVisita < fechaFinExclusiva
                    && (includeInactive || x.Activo != false))
                .OrderByDescending(x => x.FechaVisita)
                .ToListAsync();
        }

        private static double CalculateDistanceInMeters(double lat1, double lon1, double lat2, double lon2)
        {
            const double radioTierraMetros = 6371000d;
            var dLat = DegreesToRadians(lat2 - lat1);
            var dLon = DegreesToRadians(lon2 - lon1);
            var origenLat = DegreesToRadians(lat1);
            var destinoLat = DegreesToRadians(lat2);

            var a = Math.Sin(dLat / 2) * Math.Sin(dLat / 2) +
                    Math.Cos(origenLat) * Math.Cos(destinoLat) *
                    Math.Sin(dLon / 2) * Math.Sin(dLon / 2);

            var c = 2 * Math.Atan2(Math.Sqrt(a), Math.Sqrt(1 - a));

            return radioTierraMetros * c;
        }

        private static double DegreesToRadians(double grados)
        {
            return grados * (Math.PI / 180d);
        }


    }
}
