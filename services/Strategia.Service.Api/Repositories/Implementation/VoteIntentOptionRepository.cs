using Microsoft.EntityFrameworkCore;
using System.Data;
using Strategia.Service.Api.DTOs;
using Strategia.Service.Api.Persistences;

namespace  Strategia.Service.Api.Repositories
{
    public class VoteIntentOptionRepository : IVoteIntentOptionRepository
    {
        private readonly ContextDatabase _context;

        public VoteIntentOptionRepository(ContextDatabase context)
        {
            _context = context;
        }

        public async Task<List<VoteIntentOptionGroupDto>> GetByStoreAsync(string tienda, bool includeInactive)
        {
            var normalizedStore = tienda.Trim().ToUpper();
            var groups = new List<VoteIntentOptionGroupDto>();
            var groupsByKey = new Dictionary<string, VoteIntentOptionGroupDto>(StringComparer.OrdinalIgnoreCase);

            await using var connection = _context.Database.GetDbConnection();
            if (connection.State != ConnectionState.Open)
            {
                await connection.OpenAsync();
            }

            await using var command = connection.CreateCommand();
            command.CommandText = """
                SELECT
                    g.CodigoDignidad,
                    g.FieldName,
                    g.ObsFieldName,
                    g.ObsLabel,
                    g.Titulo,
                    g.Orden AS GrupoOrden,
                    o.CodigoIntencionVotoOpcion,
                    o.NombreOpcion,
                    o.Orden AS OpcionOrden
                FROM dbo.IntencionVotoGrupo g
                LEFT JOIN dbo.IntencionVotoOpcion o
                    ON o.IdIntencionVotoGrupo = g.IdIntencionVotoGrupo
                    AND (@IncludeInactive = 1 OR ISNULL(o.Activo, 1) = 1)
                WHERE UPPER(LTRIM(RTRIM(g.Tienda))) = @Tienda
                    AND (@IncludeInactive = 1 OR ISNULL(g.Activo, 1) = 1)
                ORDER BY
                    g.Orden,
                    g.CodigoDignidad,
                    o.Orden,
                    o.NombreOpcion;
                """;

            var tiendaParameter = command.CreateParameter();
            tiendaParameter.ParameterName = "@Tienda";
            tiendaParameter.Value = normalizedStore;
            command.Parameters.Add(tiendaParameter);

            var includeInactiveParameter = command.CreateParameter();
            includeInactiveParameter.ParameterName = "@IncludeInactive";
            includeInactiveParameter.Value = includeInactive ? 1 : 0;
            command.Parameters.Add(includeInactiveParameter);

            await using var reader = await command.ExecuteReaderAsync();
            while (await reader.ReadAsync())
            {
                var codigoDignidad = reader["CodigoDignidad"]?.ToString()?.Trim() ?? string.Empty;
                if (string.IsNullOrWhiteSpace(codigoDignidad))
                {
                    continue;
                }

                if (!groupsByKey.TryGetValue(codigoDignidad, out var group))
                {
                    group = new VoteIntentOptionGroupDto
                    {
                        CodigoDignidad = codigoDignidad,
                        FieldName = reader["FieldName"]?.ToString()?.Trim() ?? string.Empty,
                        ObsFieldName = reader["ObsFieldName"]?.ToString()?.Trim() ?? string.Empty,
                        ObsLabel = reader["ObsLabel"]?.ToString()?.Trim() ?? string.Empty,
                        Title = reader["Titulo"]?.ToString()?.Trim() ?? string.Empty
                    };

                    groupsByKey[codigoDignidad] = group;
                    groups.Add(group);
                }

                var optionValue = reader["CodigoIntencionVotoOpcion"]?.ToString()?.Trim();
                var optionLabel = reader["NombreOpcion"]?.ToString()?.Trim();

                if (string.IsNullOrWhiteSpace(optionValue) || string.IsNullOrWhiteSpace(optionLabel))
                {
                    continue;
                }

                group.Options.Add(new VoteIntentOptionItemDto
                {
                    Label = optionLabel,
                    Value = optionValue
                });
            }

            return groups;
        }
    }
}
