using DFast.Common.General;
using System.ComponentModel.DataAnnotations.Schema;
namespace DFast.Seguridad.Api.Models
{
    public partial class Usuario : ICoreEF
    {
        public Usuario()
        {
            Registros = new HashSet<Registro>();
            UsuarioRols = new HashSet<UsuarioRol>();
            UsuarioSistemas = new HashSet<UsuarioSistema>();
        }

        public int IdUsuario { get; set; }
        public Guid Id { get; set; }
        public string Key { get; set; } = null!;
        public string Email { get; set; }
        public string Sistema { get; set; } = null!;
        public string Institucion { get; set; } = null!;
        public string Rol { get; set; }
        public string Password { get; set; }
        public string TipoIdentificacion { get; set; }
        public string Identificacion { get; set; }
        public string Nombres { get; set; }
        public string Apellidos { get; set; }
        public string Telefono1 { get; set; }
        public string Telefono2 { get; set; }
        public string Direccion { get; set; }
        public bool? Activo { get; set; }
        public int? Oficina { get; set; }
        public string UbicacionGeografica2 { get; set; }
        public DateTime? FechaUltimoAcceso { get; set; }
        public string Estado { get; set; }
        public string Estacion { get; set; }
        public short? Intentos { get; set; }
        public DateTime? FechaCaducidadPass { get; set; }
        public DateTime? FechaCreacion { get; set; }
        public string UsuarioCreacion { get; set; }
        public int? OficinaCreacion { get; set; }
        public string EstacionCreacion { get; set; }
        public DateTime? FechaModificacion { get; set; }
        public string UsuarioModificacion { get; set; }
        public int? OficinaModificacion { get; set; }
        public string EstacionModificacion { get; set; }

        public virtual ICollection<Registro> Registros { get; set; }
        public virtual ICollection<UsuarioRol> UsuarioRols { get; set; }
        public virtual ICollection<UsuarioSistema> UsuarioSistemas { get; set; }
        [NotMapped]
        public bool AuditProcessed { get; set; }
    }
}