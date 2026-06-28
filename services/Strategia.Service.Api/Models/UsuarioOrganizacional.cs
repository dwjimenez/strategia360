namespace Strategia.Service.Api.Models
{
    public partial class UsuarioOrganizacional
    {
        public int IdUsuarioOrganizacional { get; set; }
        public string Tienda { get; set; } = null!;
        public string CodigoUsuario { get; set; } = null!;
        public string CodigoRol { get; set; } = null!;
        public string? CodigoCenturia { get; set; }
        public string Nombres { get; set; } = null!;
        public string? Apellidos { get; set; }
        public string? Telefono { get; set; }
        public string? UsuarioLogin { get; set; }
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