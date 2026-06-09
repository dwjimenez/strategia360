using DFast.Common.General;
using System.ComponentModel.DataAnnotations.Schema;
namespace DFast.Seguridad.Api.Models
{
    public partial class Rol : ICoreEF
    {
        public Rol()
        {
            RolOpcions = new HashSet<RolOpcion>();
        }

        public int IdRol { get; set; }
        public string Codigo { get; set; }
        public string Sistema { get; set; }
        public string Canal { get; set; }
        public string Descripcion { get; set; }
        public bool? Activo { get; set; }
        public DateTime? FechaCreacion { get; set; }
        public string UsuarioCreacion { get; set; }
        public int? OficinaCreacion { get; set; }
        public string EstacionCreacion { get; set; }
        public DateTime? FechaModificacion { get; set; }
        public string UsuarioModificacion { get; set; }
        public int? OficinaModificacion { get; set; }
        public string EstacionModificacion { get; set; }

        public virtual ICollection<RolOpcion> RolOpcions { get; set; }
        [NotMapped]
        public bool AuditProcessed { get; set; }
    }
}