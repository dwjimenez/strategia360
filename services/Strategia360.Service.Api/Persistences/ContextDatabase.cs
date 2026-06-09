using DFast.Common.DataBaseSQL;
using DFast.Seguridad.Api.Models;
using Microsoft.EntityFrameworkCore;

namespace DFast.Seguridad.Api.Persistences;
public partial class ContextDatabase : CommonContext
{
    public ContextDatabase(DbContextOptions<ContextDatabase> options) : base(options)
    {
    }

    public virtual DbSet<CambioUsuarioPerfil> CambioUsuarioPerfil { get; set; } = null!;
    public virtual DbSet<LogContrasenia> LogContrasenia { get; set; } = null!;
    public virtual DbSet<LogSeguridad> LogSeguridad { get; set; } = null!;
    public virtual DbSet<Menu> Menu { get; set; } = null!;
    public virtual DbSet<Otp> Otp { get; set; } = null!;
    public virtual DbSet<Registro> Registro { get; set; } = null!;
    public virtual DbSet<Rol> Rol { get; set; } = null!;
    public virtual DbSet<RolOpcion> RolOpcion { get; set; } = null!;
    public virtual DbSet<Usuario> Usuario { get; set; } = null!;
    public virtual DbSet<UsuarioRol> UsuarioRol { get; set; } = null!;
    public virtual DbSet<UsuarioSistema> UsuarioSistema { get; set; } = null!;

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<CambioUsuarioPerfil>(entity =>
        {
            entity.HasKey(e => e.IdCambioUsuarioPerfil)
                .HasName("PK_CAMBIOUSUARIOPERFIL");

            entity.ToTable("CambioUsuarioPerfil");

            entity.HasIndex(e => e.Usuario, "IX_CambioUsuarioPerfil");

            entity.Property(e => e.EstacionCreacion)
                .HasMaxLength(32)
                .IsUnicode(false);

            entity.Property(e => e.EstacionModificacion)
                .HasMaxLength(32)
                .IsUnicode(false);

            entity.Property(e => e.FechaCambio).HasColumnType("smalldatetime");

            entity.Property(e => e.FechaCreacion).HasColumnType("datetime");

            entity.Property(e => e.FechaModificacion).HasColumnType("datetime");

            entity.Property(e => e.Oficina)
                .HasMaxLength(32)
                .IsUnicode(false);

            entity.Property(e => e.Usuario)
                .HasMaxLength(32)
                .IsUnicode(false);

            entity.Property(e => e.UsuarioCreacion)
                .HasMaxLength(32)
                .IsUnicode(false);

            entity.Property(e => e.UsuarioModificacion)
                .HasMaxLength(32)
                .IsUnicode(false);
        });

        modelBuilder.Entity<LogContrasenia>(entity =>
        {
            entity.HasKey(e => e.IdUsuarioContrasenia)
                .HasName("PK_USERPASSWORD");

            entity.HasIndex(e => e.IdUsuario, "IX_LogContrasenia");

            entity.Property(e => e.Contrasenia)
                .HasMaxLength(128)
                .IsUnicode(false)
                .UseCollation("Modern_Spanish_CI_AS");

            entity.Property(e => e.EstacionCreacion)
                .HasMaxLength(32)
                .IsUnicode(false);

            entity.Property(e => e.FechaCreacion).HasColumnType("datetime");

            entity.Property(e => e.UsuarioCreacion)
                .HasMaxLength(32)
                .IsUnicode(false);
        });

        modelBuilder.Entity<LogSeguridad>(entity =>
        {
            entity.HasKey(e => e.IdLogSeguridad)
                .HasName("PK_LOGSECURITY");

            entity.ToTable("LogSeguridad");

            entity.HasIndex(e => e.CodigoUsuario, "IX_LogSeguridad");

            entity.Property(e => e.CodigoUsuario)
                .HasMaxLength(32)
                .IsUnicode(false)
                .UseCollation("Modern_Spanish_CI_AS");

            entity.Property(e => e.EstacionCreacion)
                .HasMaxLength(32)
                .IsUnicode(false);

            entity.Property(e => e.Evento)
                .HasMaxLength(16)
                .IsUnicode(false)
                .UseCollation("Modern_Spanish_CI_AS");

            entity.Property(e => e.FechaCreacion).HasColumnType("datetime");

            entity.Property(e => e.Maquina)
                .HasMaxLength(64)
                .IsUnicode(false)
                .UseCollation("Modern_Spanish_CI_AS");

            entity.Property(e => e.Observacion)
                .HasMaxLength(128)
                .IsUnicode(false)
                .UseCollation("Modern_Spanish_CI_AS");

            entity.Property(e => e.RegistroFecha).HasColumnType("datetime");

            entity.Property(e => e.UsuarioCreacion)
                .HasMaxLength(32)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Menu>(entity =>
        {
            entity.HasKey(e => e.IdMenu)
                .HasName("PK_MENU");

            entity.ToTable("Menu");

            entity.HasIndex(e => e.Canal, "IX_Menu");

            entity.Property(e => e.Canal)
                .HasMaxLength(32)
                .IsUnicode(false)
                .UseCollation("Modern_Spanish_CI_AS");

            entity.Property(e => e.Descripcion)
                .HasMaxLength(128)
                .IsUnicode(false);

            entity.Property(e => e.EstacionCreacion)
                .HasMaxLength(32)
                .IsUnicode(false);

            entity.Property(e => e.EstacionModificacion)
                .HasMaxLength(32)
                .IsUnicode(false);

            entity.Property(e => e.FechaCreacion).HasColumnType("datetime");

            entity.Property(e => e.FechaModificacion).HasColumnType("datetime");

            entity.Property(e => e.Icono)
                .HasMaxLength(128)
                .IsUnicode(false)
                .UseCollation("Modern_Spanish_CI_AS");

            entity.Property(e => e.Orden).HasDefaultValueSql("((0))");

            entity.Property(e => e.Sistema)
                .HasMaxLength(32)
                .IsUnicode(false);

            entity.Property(e => e.SubTitulo)
                .HasMaxLength(128)
                .IsUnicode(false)
                .UseCollation("Modern_Spanish_CI_AS");

            entity.Property(e => e.Tipo)
                .HasMaxLength(32)
                .IsUnicode(false)
                .UseCollation("Modern_Spanish_CI_AS");

            entity.Property(e => e.Titulo)
                .HasMaxLength(128)
                .IsUnicode(false)
                .UseCollation("Modern_Spanish_CI_AS");

            entity.Property(e => e.Url)
                .HasMaxLength(128)
                .IsUnicode(false)
                .UseCollation("Modern_Spanish_CI_AS");

            entity.Property(e => e.UsuarioCreacion)
                .HasMaxLength(32)
                .IsUnicode(false);

            entity.Property(e => e.UsuarioModificacion)
                .HasMaxLength(32)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Otp>(entity =>
        {
            entity.HasKey(e => e.IdOtp);

            entity.ToTable("OTP", "dbo");

            entity.HasIndex(e => e.Dato, "IX_Otp");

            entity.Property(e => e.IdOtp).HasColumnName("IdOTP");

            entity.Property(e => e.Clave)
                .HasMaxLength(128)
                .IsUnicode(false);

            entity.Property(e => e.Dato)
                .HasMaxLength(64)
                .IsUnicode(false);

            entity.Property(e => e.Estado)
               .HasMaxLength(16)
               .IsUnicode(false);

            entity.Property(e => e.EstacionCreacion)
                .HasMaxLength(32)
                .IsUnicode(false);

            entity.Property(e => e.EstacionModificacion)
                .HasMaxLength(32)
                .IsUnicode(false);

            entity.Property(e => e.FechaCreacion).HasColumnType("datetime");
            entity.Property(e => e.FechaVigencia).HasColumnType("datetime");

            entity.Property(e => e.FechaModificacion).HasColumnType("datetime");

            entity.Property(e => e.UsuarioCreacion)
                .HasMaxLength(32)
                .IsUnicode(false);

            entity.Property(e => e.UsuarioModificacion)
                .HasMaxLength(32)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Registro>(entity =>
        {
            entity.HasKey(e => e.IdRegistro)
                .HasName("PK_REGISTRO");

            entity.ToTable("Registro");

            entity.HasIndex(e => e.IdUsuario, "IX_Registro");

            entity.HasIndex(e => new { e.Imei, e.Sistema }, "IX_Registro1")
                .IsUnique();

            entity.Property(e => e.FechaCreacion).HasColumnType("datetime");

            entity.Property(e => e.FechaModificacion).HasColumnType("datetime");

            entity.Property(e => e.Imei)
                .HasMaxLength(256)
                .IsUnicode(false);

            entity.Property(e => e.Sistema)
                .HasMaxLength(64)
                .IsUnicode(false);

            entity.Property(e => e.So)
                .HasMaxLength(16)
                .IsUnicode(false);

            entity.Property(e => e.Token)
                .HasMaxLength(256)
                .IsUnicode(false);

            entity.HasOne(d => d.IdUsuarioNavigation)
                .WithMany(p => p.Registros)
                .HasForeignKey(d => d.IdUsuario)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_REGISTRO_REFERENCE_USUARIO");
        });

        modelBuilder.Entity<Rol>(entity =>
        {
            entity.HasKey(e => e.IdRol)
                .HasName("PK_PROFILE");

            entity.ToTable("Rol");

            entity.HasIndex(e => new { e.Codigo, e.Sistema, e.Canal }, "IX_Rol")
                .IsUnique();

            entity.Property(e => e.Canal)
                .HasMaxLength(16)
                .IsUnicode(false)
                .UseCollation("Modern_Spanish_CI_AS");

            entity.Property(e => e.Codigo)
                .HasMaxLength(32)
                .IsUnicode(false)
                .UseCollation("Modern_Spanish_CI_AS");

            entity.Property(e => e.Descripcion)
                .HasMaxLength(128)
                .IsUnicode(false)
                .UseCollation("Modern_Spanish_CI_AS");

            entity.Property(e => e.EstacionCreacion)
                .HasMaxLength(32)
                .IsUnicode(false);

            entity.Property(e => e.EstacionModificacion)
                .HasMaxLength(32)
                .IsUnicode(false);

            entity.Property(e => e.FechaCreacion).HasColumnType("datetime");

            entity.Property(e => e.FechaModificacion).HasColumnType("datetime");

            entity.Property(e => e.Sistema)
                .HasMaxLength(32)
                .IsUnicode(false);

            entity.Property(e => e.UsuarioCreacion)
                .HasMaxLength(32)
                .IsUnicode(false);

            entity.Property(e => e.UsuarioModificacion)
                .HasMaxLength(32)
                .IsUnicode(false);
        });

        modelBuilder.Entity<RolOpcion>(entity =>
        {
            entity.HasKey(e => e.IdRolOpcion)
                .HasName("PK_PROFILEOPTION");

            entity.ToTable("RolOpcion");

            entity.HasIndex(e => new { e.IdRol, e.IdMenu }, "IX_RolOpcion")
                .IsUnique();

            entity.Property(e => e.Orden).HasDefaultValueSql("((0))");

            entity.HasOne(d => d.IdMenuNavigation)
                .WithMany(p => p.RolOpcions)
                .HasForeignKey(d => d.IdMenu)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_ROLOPCIO_REFERENCE_MENU");

            entity.HasOne(d => d.IdRolNavigation)
                .WithMany(p => p.RolOpcions)
                .HasForeignKey(d => d.IdRol)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_ROLOPCIO_REFERENCE_ROL");
        });

        modelBuilder.Entity<Usuario>(entity =>
        {
            entity.HasKey(e => e.IdUsuario)
                .HasName("PK_USER");

            entity.ToTable("Usuario");

            entity.HasIndex(e => new { e.Sistema, e.Key }, "IX_Usuario")
                .IsUnique();

            entity.Property(e => e.Activo).HasDefaultValueSql("((1))");

            entity.Property(e => e.Apellidos)
                .HasMaxLength(32)
                .IsUnicode(false)
                .UseCollation("Modern_Spanish_CI_AS");

            entity.Property(e => e.Direccion)
                .HasMaxLength(16)
                .IsUnicode(false);

            entity.Property(e => e.Email)
                .HasMaxLength(64)
                .IsUnicode(false);

            entity.Property(e => e.Estacion)
                .HasMaxLength(32)
                .IsUnicode(false);

            entity.Property(e => e.EstacionCreacion)
                .HasMaxLength(32)
                .IsUnicode(false);

            entity.Property(e => e.EstacionModificacion)
                .HasMaxLength(32)
                .IsUnicode(false);

            entity.Property(e => e.Estado)
                .HasMaxLength(16)
                .IsUnicode(false);

            entity.Property(e => e.FechaCaducidadPass).HasColumnType("smalldatetime");

            entity.Property(e => e.FechaCreacion).HasColumnType("datetime");

            entity.Property(e => e.FechaModificacion).HasColumnType("datetime");

            entity.Property(e => e.FechaUltimoAcceso).HasColumnType("datetime");

            entity.Property(e => e.Identificacion)
                .HasMaxLength(16)
                .IsUnicode(false)
                .UseCollation("Modern_Spanish_CI_AS");

            entity.Property(e => e.Intentos).HasDefaultValueSql("((0))");

            entity.Property(e => e.Key)
                .HasMaxLength(32)
                .IsUnicode(false);

            entity.Property(e => e.Nombres)
                .HasMaxLength(32)
                .IsUnicode(false)
                .UseCollation("Modern_Spanish_CI_AS");

            entity.Property(e => e.Oficina).HasDefaultValueSql("((0))");

            entity.Property(e => e.Password)
                .HasMaxLength(128)
                .IsUnicode(false);

            entity.Property(e => e.Rol)
                .HasMaxLength(32)
                .IsUnicode(false);

            entity.Property(e => e.Sistema)
                .HasMaxLength(32)
                .IsUnicode(false);

            entity.Property(e => e.Institucion)
            .HasMaxLength(32)
            .IsUnicode(false);

            entity.Property(e => e.Telefono1)
                .HasMaxLength(16)
                .IsUnicode(false)
                .UseCollation("Modern_Spanish_CI_AS");

            entity.Property(e => e.Telefono2)
                .HasMaxLength(16)
                .IsUnicode(false)
                .UseCollation("Modern_Spanish_CI_AS");

            entity.Property(e => e.TipoIdentificacion)
                .HasMaxLength(16)
                .IsUnicode(false)
                .UseCollation("Modern_Spanish_CI_AS");

            entity.Property(e => e.UbicacionGeografica2)
                .HasMaxLength(16)
                .IsUnicode(false);

            entity.Property(e => e.UsuarioCreacion)
                .HasMaxLength(32)
                .IsUnicode(false);

            entity.Property(e => e.UsuarioModificacion)
                .HasMaxLength(32)
                .IsUnicode(false);
        });

        modelBuilder.Entity<UsuarioRol>(entity =>
        {
            entity.HasKey(e => e.IdUsuarioRol)
                .HasName("PK_USUARIOROL");

            entity.ToTable("UsuarioRol");

            entity.HasIndex(e => new { e.IdUsuario, e.IdRol }, "IX_UsuarioRol");

            entity.Property(e => e.EstacionCreacion)
                .HasMaxLength(32)
                .IsUnicode(false);

            entity.Property(e => e.EstacionModificacion)
                .HasMaxLength(32)
                .IsUnicode(false);

            entity.Property(e => e.FechaCreacion).HasColumnType("datetime");

            entity.Property(e => e.FechaModificacion).HasColumnType("datetime");

            entity.Property(e => e.UsuarioCreacion)
                .HasMaxLength(32)
                .IsUnicode(false);

            entity.Property(e => e.UsuarioModificacion)
                .HasMaxLength(32)
                .IsUnicode(false);

            entity.HasOne(d => d.IdUsuarioNavigation)
                .WithMany(p => p.UsuarioRols)
                .HasForeignKey(d => d.IdUsuario)
                .HasConstraintName("FK_USUARIOR_REFERENCE_USUARIO");
        });

        modelBuilder.Entity<UsuarioSistema>(entity =>
        {
            entity.HasKey(e => e.IdUsuarioSistema)
                .HasName("PK_USUARIOSISTEMA");

            entity.ToTable("UsuarioSistema");

            entity.HasIndex(e => new { e.IdUsuario, e.Sistema }, "IX_UsuarioSistema");

            entity.Property(e => e.EstacionCreacion)
                .HasMaxLength(32)
                .IsUnicode(false);

            entity.Property(e => e.EstacionModificacion)
                .HasMaxLength(32)
                .IsUnicode(false);

            entity.Property(e => e.FechaCreacion).HasColumnType("datetime");

            entity.Property(e => e.FechaModificacion).HasColumnType("datetime");

            entity.Property(e => e.Sistema).HasMaxLength(32);

            entity.Property(e => e.UsuarioCreacion)
                .HasMaxLength(32)
                .IsUnicode(false);

            entity.Property(e => e.UsuarioModificacion)
                .HasMaxLength(32)
                .IsUnicode(false);

            entity.HasOne(d => d.IdUsuarioNavigation)
                .WithMany(p => p.UsuarioSistemas)
                .HasForeignKey(d => d.IdUsuario)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_USUARIOS_REFERENCE_USUARIO");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
