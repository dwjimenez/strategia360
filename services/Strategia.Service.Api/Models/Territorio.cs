namespace Strategia.Service.Api.Models
{
    public partial class Territorio
    {
        public int IdTerritorio { get; set; }
        public string Tienda { get; set; } = null!;
        public string Ciudad { get; set; } = null!;
        public string CodigoTerritorio { get; set; } = null!;
        public string CodigoCenturia { get; set; } = null!;
        public string TipoTerritorio { get; set; } = null!;
        public string NombreTerritorio { get; set; } = null!;
        public string? Parroquia { get; set; }
        public string? Barrio { get; set; }
        public string EstadoCobertura { get; set; } = null!;
        public bool? Activo { get; set; }
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