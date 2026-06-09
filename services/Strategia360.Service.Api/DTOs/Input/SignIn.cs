using Newtonsoft.Json;

namespace DFast.Seguridad.Api.DTOs
{
    public class SignIn 
    {

        public string Key { get; }
        public string Email { get; }
        public string Password { get; }
        public string Sistema { get; }

        public string Estacion { get; set; }

        public bool ValidarActivos { get; set; }

        public List<UsuarioRolDto> UsuarioRol { get; set; }

        [JsonConstructor]
        public SignIn(string key , string email, string password, string sistema, string estacion, bool validarActivos)
        {
            Key = key;
            Email = email;
            Password = password;
            Sistema = sistema;
            Estacion = estacion;
            ValidarActivos = validarActivos;
        }
    }
}