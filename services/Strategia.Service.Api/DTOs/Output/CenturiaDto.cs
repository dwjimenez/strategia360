namespace  Strategia.Service.Api.DTOs
{
    public partial class CenturiaDto
    {
        public int IdCenturia { get; set; }
        public string Tienda { get; set; } = null!;
        public string Ciudad { get; set; } = null!;
        public string CodigoCenturia { get; set; } = null!;
        public string NombreCenturia { get; set; } = null!;
        public string ParroquiaPrincipal { get; set; } = null!;
        public string? Descripcion { get; set; }
        public int MetaContactosSemana { get; set; }
        public bool? Activo { get; set; }
    }
}
