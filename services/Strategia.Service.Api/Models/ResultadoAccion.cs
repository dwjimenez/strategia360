namespace Strategia.Service.Api.Models
{
    public partial class ResultadoAccion
    {
        public int IdResultadoAccion { get; set; }
        public int IdAccionRecomendada { get; set; }
        public DateTime FechaResultado { get; set; }
        public string TipoMetrica { get; set; } = null!;
        public int TotalAntes { get; set; }
        public int TotalDespues { get; set; }
        public int Delta { get; set; }
        public decimal Recompensa { get; set; }
        public string? Observacion { get; set; }
        public DateTime? FechaCreacion { get; set; }
        public string? UsuarioCreacion { get; set; }
        public int? OficinaCreacion { get; set; }
        public string? EstacionCreacion { get; set; }
        public DateTime? FechaModificacion { get; set; }
        public string? UsuarioModificacion { get; set; }
        public int? OficinaModificacion { get; set; }
        public string? EstacionModificacion { get; set; }

        public virtual AccionRecomendada IdAccionRecomendadaNavigation { get; set; } = null!;
    }
}