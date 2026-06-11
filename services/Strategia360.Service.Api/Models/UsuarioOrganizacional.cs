using System;
using System.Collections.Generic;

namespace Strategia360.Service.Api.Models
{
    public partial class UsuarioOrganizacional
    {
        public int IdUsuarioOrganizacional { get; set; }
        public string Tienda { get; set; } = null!;
        public string CodigoUsuario { get; set; } = null!;
        public string CodigoRol { get; set; } = null!;
        public string? CodigoCenturia { get; set; }
        public string Nombres { get; set; } = null!;
        public string? Apellidos { get; set; }
        public string? Telefono { get; set; }
        public string? UsuarioLogin { get; set; }
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
