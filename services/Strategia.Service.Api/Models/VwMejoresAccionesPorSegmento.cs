using System;
using System.Collections.Generic;

namespace  Strategia.Service.Api.Models
{
    public partial class VwMejoresAccionesPorSegmento
    {
        public int SegmentoEstrategicoId { get; set; }
        public string SegmentoCodigo { get; set; } = null!;
        public string SegmentoDescripcion { get; set; } = null!;
        public int AccionEstrategicaId { get; set; }
        public string AccionCodigo { get; set; } = null!;
        public string AccionNombre { get; set; } = null!;
        public decimal ValorQ { get; set; }
        public int CantidadInteracciones { get; set; }
        public decimal RecompensaPromedio { get; set; }
        public string ModeloOrigen { get; set; } = null!;
        public string VersionModelo { get; set; } = null!;
        public DateTime UltimaActualizacion { get; set; }
    }
}
