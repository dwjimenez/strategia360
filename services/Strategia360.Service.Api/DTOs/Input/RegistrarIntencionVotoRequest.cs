namespace Strategia360.Service.Api.DTOs
{
    public class RegistrarIntencionVotoRequest
    {
        // Valores permitidos: ALCALDE / CONCEJAL / VOCALES
        public string CodigoDignidad { get; set; }

        public string CodigoIntencionVotoOpcion { get; set; }

        public string Observacion { get; set; }
    }
}