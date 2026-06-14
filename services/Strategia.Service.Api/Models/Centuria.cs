using System;
using System.Collections.Generic;

namespace  Strategia.Service.Api.Models
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
        /// <summary>
        /// Fecha de Creación
        /// </summary>
        public DateTime? FechaCreacion { get; set; }
        /// <summary>
        /// Usuario de Creación
        /// </summary>
        public string? UsuarioCreacion { get; set; }
        /// <summary>
        /// Oficina de Creación
        /// </summary>
        public int? OficinaCreacion { get; set; }
        /// <summary>
        /// Estacion Creacion
        /// </summary>
        public string? EstacionCreacion { get; set; }
        /// <summary>
        /// Fecha de Actualización
        /// </summary>
        public DateTime? FechaModificacion { get; set; }
        /// <summary>
        /// Usuario de Actualización
        /// </summary>
        public string? UsuarioModificacion { get; set; }
        /// <summary>
        /// Oficina de Actualización
        /// </summary>
        public int? OficinaModificacion { get; set; }
        /// <summary>
        /// Estacion Creacion
        /// </summary>
        public string? EstacionModificacion { get; set; }
    }
}
