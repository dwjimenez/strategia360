namespace DFast.Seguridad.Api.DTOs
{
    public partial class ChangePasswordDto {
        public string Key { get; set; }
        public string Sistema { get; set; }

        public string Password { get; set; }
        public string NewPassword { get; set; }

        
    }
}