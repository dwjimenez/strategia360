using System;
using System.Collections.Generic;

namespace Strategia.Service.Api.Models
{
    public partial class VisitaIntencionVoto
    {
        public int IdVisitaIntencionVoto { get; set; }
        public int IdVisita { get; set; }
        public string CodigoDignidad { get; set; } = null!;
        public string CodigoIntencionVotoOpcion { get; set; } = null!;
        public string? Observacion { get; set; }
        public DateTime? FechaCreacion { get; set; }
        public string? UsuarioCreacion { get; set; }
        public int? OficinaCreacion { get; set; }
        public string? EstacionCreacion { get; set; }
        public DateTime? FechaModificacion { get; set; }
        public string? UsuarioModificacion { get; set; }
        public int? OficinaModificacion { get; set; }
        public string? EstacionModificacion { get; set; }

        public virtual Visita IdVisitaNavigation { get; set; } = null!;
    }
}
