

using DFast.Common.General;
using System.ComponentModel.DataAnnotations.Schema;

namespace DFast.Seguridad.Api.Models
{
    public partial class Otp : ICoreEF
    {
        public int IdOtp { get; set; }
        public string Dato { get; set; } = null!;
        public string Clave { get; set; }
        public string Estado { get; set; }
        public DateTime? FechaVigencia { get; set; }
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
