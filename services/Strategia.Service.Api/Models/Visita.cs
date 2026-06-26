using System;
using System.Collections.Generic;

namespace Strategia.Service.Api.Models
{
    public partial class Visita
    {
        public Visita()
        {
            VisitaIntencionVoto = new HashSet<VisitaIntencionVoto>();
        }

        public int IdVisita { get; set; }
        public int IdCiudadano { get; set; }
        public string Tienda { get; set; } = null!;
        public string Ciudad { get; set; } = null!;
        public string? CodigoUsuario { get; set; }
        public string? CodigoCenturia { get; set; }
        public string? CodigoTerritorio { get; set; }
        public DateTime? FechaVisita { get; set; }
        public string? ProblemaInterno { get; set; }
        public string? ProblemaExterno { get; set; }
        public string? TemaInteresReal { get; set; }
        public string? ReferidoNombres { get; set; }
        public string? ReferidoTelefono { get; set; }
        public string? NotaEncuestador { get; set; }
        public decimal? PosX { get; set; }
        public decimal? PosY { get; set; }
        public string EstadoSync { get; set; } = null!;
        public bool? Activo { get; set; }
        public DateTime? FechaCreacion { get; set; }
        public string? UsuarioCreacion { get; set; }
        public int? OficinaCreacion { get; set; }
        public string? EstacionCreacion { get; set; }
        public DateTime? FechaModificacion { get; set; }
        public string? UsuarioModificacion { get; set; }
        public int? OficinaModificacion { get; set; }
        public string? EstacionModificacion { get; set; }

        public virtual Ciudadano IdCiudadanoNavigation { get; set; } = null!;
        public virtual ICollection<VisitaIntencionVoto> VisitaIntencionVoto { get; set; }
    }
}
