namespace Strategia.Service.Api.Models
{
    public partial class DashboardContador
    {
        public int IdDashboardContador { get; set; }
        public string Tienda { get; set; } = null!;
        public string Ciudad { get; set; } = null!;
        public string TipoCorte { get; set; } = null!;
        public DateTime FechaInicio { get; set; }
        public DateTime FechaFin { get; set; }
        public string CodigoCenturia { get; set; } = null!;
        public string CodigoTerritorio { get; set; } = null!;
        public string Parroquia { get; set; } = null!;
        public string Barrio { get; set; } = null!;
        public string TipoContador { get; set; } = null!;
        public string CodigoDignidad { get; set; } = null!;
        public string CodigoIntencionVotoOpcion { get; set; } = null!;
        public int Total { get; set; }
        public DateTime? FechaCreacion { get; set; }
        public string? UsuarioCreacion { get; set; }
        public int? OficinaCreacion { get; set; }
        public string? EstacionCreacion { get; set; }
        public DateTime? FechaModificacion { get; set; }
        public string? UsuarioModificacion { get; set; }
        public int? OficinaModificacion { get; set; }
        public string? EstacionModificacion { get; set; }
    }
}