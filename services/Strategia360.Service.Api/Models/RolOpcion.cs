
using DFast.Common.General;
using System.ComponentModel.DataAnnotations.Schema;
namespace DFast.Seguridad.Api.Models
{
    public partial class RolOpcion : ICoreEF
    {
        public int IdRolOpcion { get; set; }
        public int IdRol { get; set; }
        public int IdMenu { get; set; }
        public bool? Favorito { get; set; }
        public short? Orden { get; set; }
        public bool? Activo { get; set; }

        public virtual Menu IdMenuNavigation { get; set; }
        public virtual Rol IdRolNavigation { get; set; }
        [NotMapped]
        public bool AuditProcessed { get; set; }
    }
}