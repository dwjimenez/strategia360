namespace DFast.Seguridad.Api.DTOs
{
    public partial class OficinaDto
    {
        public int IdOficina { get; set; }
        public int IdInstitucion { get; set; }
        public string Codigo { get; set; } = null!;
        public int? IdRegionInstitucion { get; set; }
        public string? Tipo { get; set; }
        public string? Categoria { get; set; }
        public string Nombre { get; set; } = null!;
        public string? Direccion { get; set; }
        public string? Telefono1 { get; set; }
        public string? Telefono2 { get; set; }
        public string? Telefono3 { get; set; }
        public string? CorreoElectronico { get; set; }
        public string Contacto { get; set; } = null!;
        public int? IdUbicacionGeografica1 { get; set; }
        public int? IdUbicacionGeografica2 { get; set; }
        public string? CoordenadaX { get; set; }
        public string? CoordenadaY { get; set; }
        public bool Activo { get; set; }
        public string? IdOficinaDependencia { get; set; }
        public int? IdOficinaCtb { get; set; }
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