using DFast.Common.General;
using System.ComponentModel.DataAnnotations.Schema;

namespace DFast.Seguridad.Api.Models
{
    public partial class UsuarioSistema : ICoreEF
    {
        public int IdUsuarioSistema { get; set; }
        public int IdUsuario { get; set; }
        public string Sistema { get; set; }
        public int? IdRelacion { get; set; }
        public DateTime? FechaCreacion { get; set; }
        public string UsuarioCreacion { get; set; }
        public int? OficinaCreacion { get; set; }
        public string EstacionCreacion { get; set; }
        public DateTime? FechaModificacion { get; set; }
        public string UsuarioModificacion { get; set; }
        public int? OficinaModificacion { get; set; }
        public string EstacionModificacion { get; set; }

        public virtual Usuario IdUsuarioNavigation { get; set; } = null!;
        [NotMapped]
        public bool AuditProcessed { get; set; }
    }
}
