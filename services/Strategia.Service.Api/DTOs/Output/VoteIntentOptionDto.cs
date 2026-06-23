namespace  Strategia.Service.Api.DTOs
{
    public partial class VoteIntentOptionDto
    {
        public int IdIntencionVotoOpcion { get; set; }
        public string Tienda { get; set; } = null!;
        public string CodigoIntencionVotoOpcion { get; set; } = null!;
        public string CodigoDignidad { get; set; } = null!;
        public string NombreOpcion { get; set; } = null!;
        public int Orden { get; set; }
        public bool? Activo { get; set; }
    }
}
