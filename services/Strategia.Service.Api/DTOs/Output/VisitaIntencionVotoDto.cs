using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace  Strategia.Service.Api.DTOs
{
    public partial class VisitaIntencionVotoDto
    {
        public long IdVisitaIntencionVoto { get; set; }
        public long IdVisita { get; set; }
        public string CodigoDignidad { get; set; } = null!;
        public string CodigoIntencionVotoOpcion { get; set; } = null!;
        public string? Observacion { get; set; }

        //[JsonIgnore]
        //public virtual VisitaDto IdVisitaNavigation { get; set; } = null!;
    }
}
