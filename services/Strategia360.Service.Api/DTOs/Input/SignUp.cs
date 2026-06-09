using System;
using Newtonsoft.Json;

namespace DFast.Seguridad.Api.DTOs
{
    public class SignUp
    {
        public Guid Id { get; }
        public int IdUsuario { get; set; }
        public string Key { get; }

        public string Email { get; }
        public string Password { get; }
        public string Role { get; }
        public string Sistema { get; }

        public string TipoIdentificacion { get; }
        public string Identificacion { get; }
        public string Nombres { get; }
        public string Apellidos { get;  }
        public string Telefono1 { get;  }
        public string Telefono2 { get;  }

       
        public string Token { get; }
        public string Imei { get; }
        public string So { get; }
        public string Version { get; }

        public bool EditProfile { get; }


        [JsonConstructor]
        public SignUp(Guid id, int idusuario, string key, string email, string password, string role, string sistema, string telefono1, string nombres, string identificacion, string token, string so, string version, string imei, string apellidos, bool editProfile)
        {
            Id = id;
            IdUsuario = idusuario;
            Key = key;
            Email = email;
            Password = password;
            Role = role;
            Sistema = sistema;
            Telefono1 = telefono1;
            Nombres = nombres;
            Identificacion = identificacion;
            Token = token;
            So = so;
            Version = version;
            Imei = imei;
            Apellidos = apellidos;
            EditProfile = editProfile;
        }
    }
}