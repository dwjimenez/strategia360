namespace Strategia.Service.Api.Models
{
    public partial class PoliticaAprendida
    {
        public int IdPoliticaAprendida { get; set; }
        public string Tienda { get; set; } = null!;
        public string Ciudad { get; set; } = null!;
        public string TipoEstado { get; set; } = null!;
        public string ClaveEstado { get; set; } = null!;
        public string TipoAccion { get; set; } = null!;
        public decimal ValorAprendido { get; set; }
        public int VecesProbado { get; set; }
        public decimal RecompensaPromedio { get; set; }
        public DateTime UltimaActualizacion { get; set; }
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