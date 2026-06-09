
namespace DFast.Seguridad.Api.DTOs
{
    public partial class UsuarioDtoIng
    {
        public int UserId { get; set; }
        public Guid Id { get; set; }
        public string Key { get; set; } = null!;
        public string Email { get; set; }
        public string System { get; set; } = null!;
        public string Institution { get; set; } = null!;
        public string Role { get; set; }
        // public string Password { get; set; }
        public string IdentificationType { get; set; }
        public string Identification { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Phone1 { get; set; }
        public string Phone2 { get; set; }
        public string Address { get; set; }
        public bool? IsActive { get; set; }
        public string GeoLocation2 { get; set; }
        public int? Office { get; set; }
        public string? CodeOffice { get; set; }
        public short? Attempts { get; set; }
        public string Station { get; set; }
        public string Status { get; set; }
        public string Token { get; set; }
        public string Imei { get; set; }
        public string Os { get; set; } // (SO = Sistema Operativo → OS: Operating System)
        public string Version { get; set; }
        public string DateSytem { get; set; }
        public DateTime? LastAccessDate { get; set; }
        public DateTime? PasswordExpirationDate { get; set; }

        public List<UsuarioRolDto> UsuarioRol { get; set; } 
        public List<UsuarioSistemaDto> UsuarioSistemas { get; set; }
        public OficinaDto OficinaRegistro { get; set; }
    }
}
