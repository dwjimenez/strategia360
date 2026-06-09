using DFast.Seguridad.Api.DTOs;
using Microsoft.AspNetCore.Mvc;
using RestEase;

namespace DFast.Seguridad.Api.Proxy
{
    public class ApiResponse<T>
    {
        public bool state { get; set; }
        public string? message { get; set; }
        public string? code { get; set; }
        public T? data { get; set; }
    }
    public interface IConfiguracionService
    {
        [AllowAnyStatusCode]
        [Get("api/oficina/obtenerxid")]
        Task<ApiResponse<OficinaDto>> ObtenerXId([FromQuery] int codigo);
    }
}