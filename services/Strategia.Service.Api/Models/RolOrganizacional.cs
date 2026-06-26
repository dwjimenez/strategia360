using System;
using System.Collections.Generic;

namespace Strategia.Service.Api.Models
{
    public partial class RolOrganizacional
    {
        public int IdRolOrganizacional { get; set; }
        public string Tienda { get; set; } = null!;
        public string CodigoRol { get; set; } = null!;
        public string NombreRol { get; set; } = null!;
        public int NivelJerarquico { get; set; }
        public bool EsComando { get; set; }
        public bool? Activo { get; set; }
        public DateTime? FechaCreacion { get; set; }
        public string? UsuarioCreacion { get; set; }
        public int? OficinaCreacion { get; set; }
        public string? EstacionCreacion { get; set; }
        public DateTime? FechaModificacion { get; set; }
        public string? UsuarioModificacion { get; set; }
        public int? OficinaModificacion { get; set; }
        public string? EstacionModificacion { get; set; }
    }
}
