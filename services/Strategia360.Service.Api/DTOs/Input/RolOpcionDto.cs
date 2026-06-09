
namespace DFast.Seguridad.Api.DTOs
{
    public partial class RolOpcionDto 
    {
        public int IdRolOpcion { get; set; }
        public int IdRol { get; set; }
        public int IdMenu { get; set; }
        public bool? Favorito { get; set; }
        public short? Orden { get; set; }
        public bool? Activo { get; set; }
        
     }
}
