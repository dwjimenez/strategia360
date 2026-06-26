using System;
using System.Collections.Generic;

namespace Strategia.Service.Api.Models
{
    public partial class Centuria
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
