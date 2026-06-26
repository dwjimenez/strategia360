using System;
using System.Collections.Generic;

namespace Strategia.Service.Api.Models
{
    public partial class Ciudadano
    {
        public Ciudadano()
        {
            Visita = new HashSet<Visita>();
        }

        public int IdCiudadano { get; set; }
        public string Tienda { get; set; } = null!;
        public string Ciudad { get; set; } = null!;
        public string? CodigoTerritorio { get; set; }
        public string? CodigoCenturia { get; set; }
        public string Codigo { get; set; } = null!;
        public string Nombres { get; set; } = null!;
        public string? Apellidos { get; set; }
        public string NumeroCelular { get; set; } = null!;
        public string Genero { get; set; } = null!;
        public int MiembrosFamilia { get; set; }
        public int MiembrosVotan { get; set; }
        public int MiembrosDiscapacidad { get; set; }
        public string Parroquia { get; set; } = null!;
        public string Barrio { get; set; } = null!;
        public string Direccion { get; set; } = null!;
        public decimal? PosX { get; set; }
        public decimal? PosY { get; set; }
        public bool? Activo { get; set; }
        public DateTime? FechaCreacion { get; set; }
        public string? UsuarioCreacion { get; set; }
        public int? OficinaCreacion { get; set; }
        public string? EstacionCreacion { get; set; }
        public DateTime? FechaModificacion { get; set; }
        public string? UsuarioModificacion { get; set; }
        public int? OficinaModificacion { get; set; }
        public string? EstacionModificacion { get; set; }

        public virtual ICollection<Visita> Visita { get; set; }
    }
}
