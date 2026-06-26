using System;
using System.Collections.Generic;

namespace Strategia.Service.Api.Models
{
    public partial class ReporteOrganizacional
    {
        public int IdReporteOrganizacional { get; set; }
        public string Tienda { get; set; } = null!;
        public string Ciudad { get; set; } = null!;
        public string CodigoReporte { get; set; } = null!;
        public string TipoReporte { get; set; } = null!;
        public string CodigoUsuario { get; set; } = null!;
        public string CodigoRol { get; set; } = null!;
        public string CodigoCenturia { get; set; } = null!;
        public DateTime FechaReporte { get; set; }
        public DateTime FechaEnvio { get; set; }
        public int RelatoresActivos { get; set; }
        public int SoldadosActivos { get; set; }
        public decimal HorasCampo { get; set; }
        public int PromovidosCompletos { get; set; }
        public int PromovidosIncompletos { get; set; }
        public int ContactosSinDatos { get; set; }
        public decimal Vah { get; set; }
        public string? TendenciaVah { get; set; }
        public decimal CoberturaPorcentaje { get; set; }
        public string? SectoresCompletados { get; set; }
        public string? SectoresPendientes { get; set; }
        public string? ZonaPrioritariaManana { get; set; }
        public string? TemperaturaSocial { get; set; }
        public string? ObjecionFrecuente { get; set; }
        public bool ActividadAdversario { get; set; }
        public string? Adversario { get; set; }
        public string? TipoActividadAdversario { get; set; }
        public string? SectorActividadAdversario { get; set; }
        public string? NivelAlerta { get; set; }
        public bool NecesitaMaterial { get; set; }
        public string? MaterialSolicitado { get; set; }
        public bool NecesitaPresupuesto { get; set; }
        public decimal MontoPresupuesto { get; set; }
        public bool NecesitaLlamada { get; set; }
        public string? TemaLlamada { get; set; }
        public string? Observacion { get; set; }
        public string Estado { get; set; } = null!;
        public DateTime? FechaCreacion { get; set; }
        public string? UsuarioCreacion { get; set; }
        public int? OficinaCreacion { get; set; }
        public string? EstacionCreacion { get; set; }
        public DateTime? FechaModificacion { get; set; }
        public string? UsuarioModificacion { get; set; }
        public int? OficinaModificacion { get; set; }
        public string? EstacionModificacion { get; set; }
    }
}
