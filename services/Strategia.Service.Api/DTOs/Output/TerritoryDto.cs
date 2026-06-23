namespace  Strategia.Service.Api.DTOs
{
    public partial class TerritoryDto
    {
        public int IdTerritorio { get; set; }
        public string Tienda { get; set; } = null!;
        public string Ciudad { get; set; } = null!;
        public string CodigoTerritorio { get; set; } = null!;
        public string CodigoCenturia { get; set; } = null!;
        public string TipoTerritorio { get; set; } = null!;
        public string NombreTerritorio { get; set; } = null!;
        public string? Parroquia { get; set; }
        public string? Barrio { get; set; }
        public string EstadoCobertura { get; set; } = null!;
        public bool? Activo { get; set; }
    }
}
