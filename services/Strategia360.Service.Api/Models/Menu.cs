using DFast.Common.General;
using System.ComponentModel.DataAnnotations.Schema;

namespace DFast.Seguridad.Api.Models
{
    public partial class Menu : ICoreEF
    {
        public Menu()
        {
            RolOpcions = new HashSet<RolOpcion>();
        }

        public int IdMenu { get; set; }
        public int? IdMenuOrigen { get; set; }
        public string Sistema { get; set; }
        public string Canal { get; set; }
        public string Titulo { get; set; }
        public string SubTitulo { get; set; }
        public string Descripcion { get; set; }
        public string Icono { get; set; }
        public bool? Activo { get; set; }
        public short? Orden { get; set; }
        public string Tipo { get; set; }
        public string Url { get; set; }
        public bool? Visible { get; set; }
        public DateTime? FechaCreacion { get; set; }
        public string UsuarioCreacion { get; set; }
        public int? OficinaCreacion { get; set; }
        public string EstacionCreacion { get; set; }
        public DateTime? FechaModificacion { get; set; }
        public string UsuarioModificacion { get; set; }
        public int? OficinaModificacion { get; set; }
        public string EstacionModificacion { get; set; }

        public virtual ICollection<RolOpcion> RolOpcions { get; set; }
        [NotMapped]
        public bool AuditProcessed { get; set; }
    }
}