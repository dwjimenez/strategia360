

namespace DFast.Seguridad.Api.DTOs
{
    public partial class UsuarioSistemaDto 
    {
        public int IdUsuarioSistema { get; set; }
        public int IdUsuario { get; set; }
        public string Sistema { get; set; }
        public int? IdRelacion { get; set; }
        
    }
}
