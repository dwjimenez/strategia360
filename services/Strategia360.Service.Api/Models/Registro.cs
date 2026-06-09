using DFast.Common.General;
using System.ComponentModel.DataAnnotations.Schema;

namespace DFast.Seguridad.Api.Models
{
    public partial class Registro : ICoreEF
    {
        public int IdRegistro { get; set; }
        public int IdUsuario { get; set; }
        public string Imei { get; set; }
        public string Sistema { get; set; }
        public string So { get; set; }
        public string Token { get; set; }
        public DateTime? FechaCreacion { get; set; }
        public DateTime? FechaModificacion { get; set; }

        public virtual Usuario IdUsuarioNavigation { get; set; }
        [NotMapped]
        public bool AuditProcessed { get; set; }
    }
}