using DFast.Common.General;
using System.ComponentModel.DataAnnotations.Schema;

namespace DFast.Seguridad.Api.Models
{
    public partial class CambioUsuarioPerfil : ICoreEF
    
    {
        public int IdCambioUsuarioPerfil { get; set; }
        public string Usuario { get; set; }
        public DateTime? FechaCambio { get; set; }
        public string Oficina { get; set; }
        public int? Perfil { get; set; }
        public bool? Activo { get; set; }
        public DateTime? FechaCreacion { get; set; }
        public string UsuarioCreacion { get; set; }
        public int? OficinaCreacion { get; set; }
        public string EstacionCreacion { get; set; }
        public DateTime? FechaModificacion { get; set; }
        public string UsuarioModificacion { get; set; }
        public int? OficinaModificacion { get; set; }
        public string EstacionModificacion { get; set; }
        [NotMapped]
        public bool AuditProcessed { get; set; }
    }
}
