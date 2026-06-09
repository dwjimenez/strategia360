using DFast.Seguridad.Api.DTOs;
using DFast.Seguridad.Api.Models;
using Docufy.Seguridad.Api.DTOs;

namespace DFast.Seguridad.Api.Services
{
    public interface IIdentityService
    {
        List<Usuario> ObtenerTodos(string institucion);
        Task<UsuarioDto> SignUpSimpleAsync(UsuarioDto command);
        Task<UsuarioDto> ActivarAsync(UsuarioDto command);
        Task<UsuarioDto> SignUpFullAsync(UsuarioDto usuariodto);
        Task<object> SignInAsync(string key, string password,string sistema, string estacion, bool validarActivos);
        Task<UsuarioDto> ActualizarAsync(UsuarioDto usuariodto);

        Task<UsuarioDto> RegistrarIngresoAsync(UsuarioDto command);
        Task<bool> ForgetPasswordAsync(string key, string sistema);
        Task<bool> ChangePasswordAsync(string key, string currentPassword, string newPassword, string sistema);
        Task<bool> UpdatePasswordAsync(string key, string currentPassword, string newPassword, string sistema);
        Task<string> TokenAsync(string key, string sistema);

        Task<string> CrearOtpAsync(UsuarioDto command);
        Task<bool> ValidarOtpAsync(UsuarioDto command);
        Task<bool> EnviarPushAsync(MessagePush mensagePush);
        Task<bool> EnviarListaPushAsync(List<MessagePush> mensagePush);
        Task<List<UsuarioSistemaDto>> ObtenerUsuariosComercioAsync(int idComercio);
        Task<UsuarioDtoIng> GetUser(string key, string sistema);
        Task<List<UsuarioDtoIng>> GetUsersByNombreApellidos(string nombres, string apellidos, string sistema);
    }
}
