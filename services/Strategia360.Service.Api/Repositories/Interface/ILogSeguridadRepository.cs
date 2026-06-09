
using DFast.Seguridad.Api.Models;

namespace DFast.Seguridad.Api.Repositories
{
    public interface ILogSeguridadRepository
    {
        Task AddAsync(LogSeguridad logseguridad);
        
    }
}