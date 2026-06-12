namespace Strategia360.Service.Api.DTOs;

public class RegistrarCiudadanoVisitaRequest
{
    public int? IdCiudadano { get; set; }
    public string Tienda { get; set; }
    public string Ciudad { get; set; }

    public string? CodigoUsuario { get; set; }
    public string? CodigoCenturia { get; set; }
    public string? CodigoTerritorio { get; set; }
    public string? Codigo { get; set; }

    public string Nombres { get; set; }
    public string? Apellidos { get; set; }
    public string NumeroCelular { get; set; }

    public string Genero { get; set; }

    public int MiembrosFamilia { get; set; }
    public int MiembrosVotan { get; set; }
    public int MiembrosDiscapacidad { get; set; }

    public string Parroquia { get; set; }
    public string Barrio { get; set; }
    public string Direccion { get; set; }

    public decimal? PosX { get; set; }
    public decimal? PosY { get; set; }

    public int PersonasMayoresCasa { get; set; }

    public string? ProblemaPrincipal { get; set; }
    public string? ProblemaTexto { get; set; }

    public string? ResultadoVisita { get; set; }
    public string? RazonNoIndeciso { get; set; }

    public string TemasInteres { get; set; }
    public string? TemaInteresReal { get; set; }

    public bool TieneReferido { get; set; }
    public string? ReferidoNombres { get; set; }
    public string? ReferidoTelefono { get; set; }

    public string? NotaEncuestador { get; set; }

    public string EstadoSync { get; set; } = "SINCRONIZADO";

    public string? UsuarioCreacion { get; set; }
    public int? OficinaCreacion { get; set; }
    public string? EstacionCreacion { get; set; }

    public List<RegistrarIntencionVotoRequest> IntencionesVoto { get; set; } = new();
}
