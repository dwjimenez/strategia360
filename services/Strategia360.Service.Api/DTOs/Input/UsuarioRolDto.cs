using System;
using System.Collections.Generic;

namespace DFast.Seguridad.Api.DTOs
{
    public partial class UsuarioRolDto
    {
        public int IdUsuarioRol { get; set; }
        public int? IdUsuario { get; set; }
        public int? IdRol { get; set; }
        public bool? Estado { get; set; }
        public string Descripcion { get; set; }
       

        
    }
}
