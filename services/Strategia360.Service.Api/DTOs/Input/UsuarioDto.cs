
namespace DFast.Seguridad.Api.DTOs
{
    public partial class UsuarioDto
    {
        public int IdUsuario { get; set; }
        public Guid Id { get; set; }
        public string Key { get; set; } = null!;
        public string Email { get; set; }
        public string Sistema { get; set; } = null!;
        public string Institucion { get; set; } = null!;
        public string Rol { get; set; }
        //public string Password { get; set; }
        public string TipoIdentificacion { get; set; }
        public string Identificacion { get; set; }
        public string Nombres { get; set; }
        public string Apellidos { get; set; }
        public string Telefono1 { get; set; }
        public string Telefono2 { get; set; }
        public string Direccion { get; set; }
        public bool? Activo { get; set; }
        public string UbicacionGeografica2 { get; set; }
        public int? Oficina { get; set; }
        public string? CcdigoOficina { get; set; }
        public short? Intentos { get; set; }
        public string Estacion { get; set; }
        public string Estado { get; set; }
        public string Token { get; set; }
        public string Imei { get; set; }
        public string So { get; set; }
        public string Version { get; set; }
        public DateTime? FechaUltimoAcceso { get; set; }
        public DateTime? FechaCaducidadPass { get; set; }
        //public  List<RegistroDto> Registros { get; set; }
        public List<UsuarioRolDto> UsuarioRol { get; set; } 
        public List<UsuarioSistemaDto> UsuarioSistemas { get; set; }
        public OficinaDto OficinaRegistro { get; set; }
    }
}
