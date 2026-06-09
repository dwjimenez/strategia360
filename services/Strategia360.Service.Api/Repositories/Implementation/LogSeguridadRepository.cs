using DFast.Seguridad.Api.Models;
using DFast.Seguridad.Api.Persistences;

namespace DFast.Seguridad.Api.Repositories;

public class LogSeguridadRepository : ILogSeguridadRepository
{
    private readonly ContextDatabase _seguridadfContext;

    public LogSeguridadRepository(ContextDatabase seguridadfContext)
    {
        _seguridadfContext = seguridadfContext;
    }


    
    public async Task AddAsync(LogSeguridad logseguridad)
        =>  await _seguridadfContext.LogSeguridad.AddAsync(logseguridad);
    
}