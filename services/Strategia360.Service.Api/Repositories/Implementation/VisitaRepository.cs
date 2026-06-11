using Strategia360.Service.Api.Persistences;
using Strategia360.Service.Api.Models;
using Microsoft.EntityFrameworkCore;


namespace Strategia360.Service.Api.Repositories
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


    }
}