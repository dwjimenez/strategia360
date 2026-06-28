namespace Strategia.Service.Api.Models
{
    public partial class AccionRecomendada
    {
        public AccionRecomendada()
        {
            ResultadoAccion = new HashSet<ResultadoAccion>();
        }

        public int IdAccionRecomendada { get; set; }
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
        public DateTime? FechaCreacion { get; set; }
        public string? UsuarioCreacion { get; set; }
        public int? OficinaCreacion { get; set; }
        public string? EstacionCreacion { get; set; }
        public DateTime? FechaModificacion { get; set; }
        public string? UsuarioModificacion { get; set; }
        public int? OficinaModificacion { get; set; }
        public string? EstacionModificacion { get; set; }

        public virtual ICollection<ResultadoAccion> ResultadoAccion { get; set; }
    }
}