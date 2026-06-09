using DFast.Common.General;
using System.ComponentModel.DataAnnotations.Schema;

namespace DFast.Seguridad.Api.Models
{
    public partial class LogContrasenia : ICoreEF
    {
        public int IdUsuarioContrasenia { get; set; }
        public int? IdUsuario { get; set; }
        public string Contrasenia { get; set; }
        public DateTime? FechaCreacion { get; set; }
        public string UsuarioCreacion { get; set; }
        public int? OficinaCreacion { get; set; }
        public string EstacionCreacion { get; set; }
        [NotMapped]
        public bool AuditProcessed { get; set; }
    }
}