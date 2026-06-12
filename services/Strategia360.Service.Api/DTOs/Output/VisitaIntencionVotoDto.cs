using System;
using System.Collections.Generic;

namespace Strategia360.Service.Api.Dtos
{
    public partial class VisitaIntencionVotoDto
    {
        public long IdVisitaIntencionVoto { get; set; }
        public long IdVisita { get; set; }
        public string CodigoDignidad { get; set; } = null!;
        public string CodigoIntencionVotoOpcion { get; set; } = null!;
        public string? Observacion { get; set; }
        
        public virtual VisitaDto IdVisitaNavigation { get; set; } = null!;
    }
}
