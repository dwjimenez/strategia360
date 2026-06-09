using System;
using System.Collections.Generic;

namespace DFast.Services.Identity.Domain
{
    /// <summary>
    /// Registros de clientes prospección
    /// </summary>
    public partial class RegistroCliente
    {
        /// <summary>
        /// Identificador de prospeccion
        /// </summary>
        public int IdRegistroCliente { get; set; }
        /// <summary>
        /// Password del cliente
        /// </summary>
        public string Clave { get; set; } = null!;
        /// <summary>
        /// Origen de donde proviene el cliente
        /// </summary>
        public string Origen { get; set; } = null!;
        /// <summary>
        /// Identificacion del cliente
        /// </summary>
        public string Identificacion { get; set; } = null!;
        /// <summary>
        /// Codigo Dactilar del cliente
        /// </summary>
        public string Dactilar { get; set; } = null!;
        /// <summary>
        /// Identificador de grupo empresarial
        /// </summary>
        public int IdGrupo { get; set; }
        /// <summary>
        /// Numero Celular del cliente
        /// </summary>
        public string Celular { get; set; } = null!;
        /// <summary>
        /// Correo electronico del cliente
        /// </summary>
        public string Email { get; set; } = null!;
        /// <summary>
        /// Nombre del cliente
        /// </summary>
        public string Nombre { get; set; } = null!;
        /// <summary>
        /// Fecha Ultimo Acceso
        /// </summary>
        public DateTime FechaUltimoAcceso { get; set; }
        /// <summary>
        /// Numero de intentos de conexion
        /// </summary>
        public short Intentos { get; set; }
        /// <summary>
        /// Estado de conexion del cliente
        /// </summary>
        public string EstadoConexion { get; set; } = null!;
        /// <summary>
        /// Fecha de caducidad del password
        /// </summary>
        public DateTime? FechaCaducidad { get; set; }
        /// <summary>
        /// Determina si la prospeccion ha sido procesada en su totalidad
        /// </summary>
        public bool Procesado { get; set; }
        /// <summary>
        /// Secuencia o paso en el que se encuentra el flujo prospeccion
        /// </summary>
        public int Secuencia { get; set; }
        /// <summary>
        /// Identificador de flujo origen
        /// </summary>
        public int? IdFlujo { get; set; }
        /// <summary>
        /// Identificador de cliente
        /// </summary>
        public int? IdCliente { get; set; }
        /// <summary>
        /// Usuario del cliente (prospeccion o cliente)
        /// </summary>
        public string Usuario { get; set; } = null!;
        /// <summary>
        /// Se ha enviado o no el Mensaje Retarjeting de registro del cliente (sin flujo)
        /// </summary>
        public bool? MsjeRegistro { get; set; }
        /// <summary>
        /// Se ha enviado o no el Mensaje Retarjeting de continuacion del flujo
        /// </summary>
        public bool? MsjeFlujo { get; set; }
        public string? Tienda { get; set; }
        public string? TokenAcceso { get; set; }
        /// <summary>
        /// Estado del registro
        /// </summary>
        public bool EsActivo { get; set; }
        /// <summary>
        /// Fecha de creacion del registro
        /// </summary>
        public DateTime? FechaCreacion { get; set; }
        /// <summary>
        /// Usuario de creacion del registro
        /// </summary>
        public string? UsuarioCreacion { get; set; }
        /// <summary>
        /// Estacion de creacion del registro
        /// </summary>
        public string? EstacionCreacion { get; set; }
        /// <summary>
        /// Fecha de modificacion del registro
        /// </summary>
        public DateTime? FechaModificacion { get; set; }
        /// <summary>
        /// Usuario de modificacion del registro
        /// </summary>
        public string? UsuarioModificacion { get; set; }
        /// <summary>
        /// Estacion de modificacion del registro
        /// </summary>
        public string? EstacionModificacion { get; set; }
    }
}
