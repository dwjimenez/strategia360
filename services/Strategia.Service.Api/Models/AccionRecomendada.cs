using System;
using System.Collections.Generic;

namespace  Strategia.Service.Api.Models
{
    public partial class AccionRecomendada
    {
        public AccionRecomendada()
        {
            ResultadoAccions = new HashSet<ResultadoAccion>();
        }

        public long IdAccionRecomendada { get; set; }
        public string Tienda { get; set; } = null!;
        public string Ciudad { get; set; } = null!;
        public DateTime FechaGeneracion { get; set; }
        public string TipoAccion { get; set; } = null!;
        public string? CodigoCenturia { get; set; }
        public string? CodigoTerritorio { get; set; }
        public string? CodigoDignidad { get; set; }
        public string? CodigoIntencionVotoOpcion { get; set; }
        public string Titulo { get; set; } = null!;
        public string? Motivo { get; set; }
        public decimal Score { get; set; }
        public string Estado { get; set; } = null!;
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

        public virtual ICollection<ResultadoAccion> ResultadoAccions { get; set; }
    }
}
