namespace Docufy.Seguridad.Api.DTOs;
public class LogSeguridadCreated
{
    public LogSeguridadCreated(
            string evento,
            int? idOficina,
            string maquina,
            int idUsuario,
            string codigoUsuario,
            int intentos,
            int idPerfil,
            string observacion

       )
    {
        Evento = evento;
        IdOficina = idOficina;
        Maquina = maquina;
        IdUsuario = idUsuario;
        CodigoUsuario = codigoUsuario;
        Intentos = intentos;
        IdPerfil = idPerfil;
        Observacion = observacion;
    }

    public LogSeguridadCreated(string evento, int? idOficina, string maquina, int? idUsuario, string codigoUsuario, int? intentos, int? idPerfil, string observacion)
    {
        Evento = evento;
        IdOficina = idOficina;
        Maquina = maquina;
        IdUsuario = idUsuario;
        CodigoUsuario = codigoUsuario;
        Intentos = intentos;
        IdPerfil = idPerfil;
        Observacion = observacion;
    }
    public string Evento { get; set; }
    public int? IdOficina { get; set; }
    public string Maquina { get; set; }
    public int? IdUsuario { get; set; }
    public string CodigoUsuario { get; set; }
    public int? Intentos { get; set; }
    public int? IdPerfil { get; set; }
    public string Observacion { get; set; }
}
