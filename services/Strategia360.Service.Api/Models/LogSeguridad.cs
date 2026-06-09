using DFast.Common.General;
using System.ComponentModel.DataAnnotations.Schema;

namespace DFast.Seguridad.Api.Models
{
    public partial class LogSeguridad : ICoreEF
    {
        public int IdLogSeguridad { get; set; }
        public string Evento { get; set; }
        public DateTime? RegistroFecha { get; set; }
        public int? IdOficina { get; set; }
        public string Maquina { get; set; }
        public int? IdUsuario { get; set; }
        public string CodigoUsuario { get; set; }
        public int? Intentos { get; set; }
        public int? IdPerfil { get; set; }
        public string Observacion { get; set; }
        public DateTime? FechaCreacion { get; set; }
        public string UsuarioCreacion { get; set; }
        public int? OficinaCreacion { get; set; }
        public string EstacionCreacion { get; set; }

        [NotMapped]
        public bool AuditProcessed { get; set; }
    }
}