namespace DFast.Seguridad.Api.DTOs
{
    public partial class RolDto
    {
        public int IdRol { get; set; }
        public string Codigo { get; set; } = null!;
        public string Sistema { get; set; } = null!;
        public string Canal { get; set; } = null!;
        public string Descripcion { get; set; }
        public bool? Activo { get; set; }
        public virtual List<RolOpcionDto> RolOpcionDto { get; set; }
    }
}