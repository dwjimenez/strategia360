
namespace  Strategia.Service.Api.Models
{
    public partial class ResultadoAccion
    {
        public long IdResultadoAccion { get; set; }
        public long IdAccionRecomendada { get; set; }
        public DateTime FechaResultado { get; set; }
        public string TipoMetrica { get; set; } = null!;
        public int TotalAntes { get; set; }
        public int TotalDespues { get; set; }
        public int Delta { get; set; }
        public decimal Recompensa { get; set; }
        public string? Observacion { get; set; }
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

        public virtual AccionRecomendada IdAccionRecomendadaNavigation { get; set; } = null!;
    }
}
