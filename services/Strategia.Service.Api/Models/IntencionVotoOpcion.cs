namespace Strategia.Service.Api.Models
{
    public partial class IntencionVotoOpcion
    {
        public int IdIntencionVotoOpcion { get; set; }
        public string Tienda { get; set; } = null!;
        public string CodigoIntencionVotoOpcion { get; set; } = null!;
        public string CodigoDignidad { get; set; } = null!;
        public string NombreOpcion { get; set; } = null!;
        public int Orden { get; set; }
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