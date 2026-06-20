
namespace  Strategia.Service.Api.DTOs
{
    public partial class VisitaDto
    {
        public VisitaDto()
        {
            VisitaIntencionVotos = new HashSet<VisitaIntencionVotoDto>();
        }

        public long IdVisita { get; set; }
        public long IdCiudadano { get; set; }
        public string Tienda { get; set; } = null!;
        public string Ciudad { get; set; } = null!;
        public string? CodigoUsuario { get; set; }
        public string? CodigoCenturia { get; set; }
        public string? CodigoTerritorio { get; set; }
        public DateTime FechaVisita { get; set; }
        public int? PersonasMayoresCasa { get; set; }
        public string? ProblemaPrincipal { get; set; }
        public string? ProblemaInterno { get; set; }
        public string? ResultadoVisita { get; set; }
        public string? RazonNoIndeciso { get; set; }
        public string TemasInteres { get; set; } = null!;
        public string? TemaInteresReal { get; set; }
        public bool TieneReferido { get; set; }
        public string? ReferidoNombres { get; set; }
        public string? ReferidoTelefono { get; set; }
        public string? NotaEncuestador { get; set; }
        public decimal? PosX { get; set; }
        public decimal? PosY { get; set; }
        public string EstadoSync { get; set; } = null!;
        public bool? Activo { get; set; }

        public virtual CiudadanoDto IdCiudadanoNavigation { get; set; } = null!;
        public virtual ICollection<VisitaIntencionVotoDto> VisitaIntencionVotos { get; set; }
    }
}
