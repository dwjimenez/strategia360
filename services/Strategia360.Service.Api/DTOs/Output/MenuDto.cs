
namespace DFast.Seguridad.Api.DTOs
{
    public partial class MenuDto
    {
        public int IdMenu { get; set; }
        public int? IdMenuOrigen { get; set; }
        public string Sistema { get; set; }
        public string Canal { get; set; }
        public string Titulo { get; set; }
        public string SubTitulo { get; set; }
        public string Descripcion { get; set; }
        public string Icono { get; set; }
        public bool? Activo { get; set; }
        public short? Orden { get; set; }
        public string Tipo { get; set; }
        public string Url { get; set; }
        public bool? Visible { get; set; }
       // public virtual List<RolOpcionDto> RolOpcions { get; set; }

    }
}
