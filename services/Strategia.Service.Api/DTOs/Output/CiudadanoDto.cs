using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace  Strategia.Service.Api.DTOs
{
    public partial class CiudadanoDto
    {
        public CiudadanoDto()
        {
            Visita = new HashSet<VisitaDto>();
        }

        public long IdCiudadano { get; set; }
        public string Tienda { get; set; } = null!;
        public string Ciudad { get; set; } = null!;
        public string? CodigoCenturia { get; set; }
        public string? CodigoTerritorio { get; set; }
        public string? Codigo { get; set; }
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

        [JsonIgnore]
        public virtual ICollection<VisitaDto> Visita { get; set; }
    }
}
