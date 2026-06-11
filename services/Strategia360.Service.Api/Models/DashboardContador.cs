using System;
using System.Collections.Generic;

namespace Strategia360.Service.Api.Models
{
    public partial class DashboardContador
    {
        public long IdDashboardContador { get; set; }
        public string Tienda { get; set; } = null!;
        public string Ciudad { get; set; } = null!;
        public string TipoCorte { get; set; } = null!;
        public DateTime FechaInicio { get; set; }
        public DateTime FechaFin { get; set; }
        public string CodigoCenturia { get; set; } = null!;
        public string CodigoTerritorio { get; set; } = null!;
        public string Parroquia { get; set; } = null!;
        public string Barrio { get; set; } = null!;
        public string TipoContador { get; set; } = null!;
        public string CodigoDignidad { get; set; } = null!;
        public string CodigoIntencionVotoOpcion { get; set; } = null!;
        public int Total { get; set; }
        /// <summary>
        /// Fecha de Creación
        /// </summary>
        public DateTime? FechaCreacion { get; set; }
        /// <summary>
        /// Usuario de Creación
        /// </summary>
        public string? UsuarioCreacion { get; set; }
        /// <summary>
        /// Oficina de Creación
        /// </summary>
        public int? OficinaCreacion { get; set; }
        /// <summary>
        /// Estacion Creacion
        /// </summary>
        public string? EstacionCreacion { get; set; }
        /// <summary>
        /// Fecha de Actualización
        /// </summary>
        public DateTime? FechaModificacion { get; set; }
        /// <summary>
        /// Usuario de Actualización
        /// </summary>
        public string? UsuarioModificacion { get; set; }
        /// <summary>
        /// Oficina de Actualización
        /// </summary>
        public int? OficinaModificacion { get; set; }
        /// <summary>
        /// Estacion Creacion
        /// </summary>
        public string? EstacionModificacion { get; set; }
    }
}
