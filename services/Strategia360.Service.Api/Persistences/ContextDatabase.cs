using DFast.Common.DataBaseSQL;
using Strategia360.Service.Api.Models;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel;


namespace Strategia360.Service.Api.Persistences;
public partial class ContextDatabase : CommonContext
{
    public ContextDatabase(DbContextOptions<ContextDatabase> options) : base(options)
    {
    }

    public virtual DbSet<AccionRecomendada> AccionRecomendada { get; set; } = null!;
    public virtual DbSet<Centuria> Centuria { get; set; } = null!;
    public virtual DbSet<Ciudadano> Ciudadano { get; set; } = null!;
    public virtual DbSet<DashboardContador> DashboardContador { get; set; } = null!;
    public virtual DbSet<IntencionVotoOpcion> IntencionVotoOpcion { get; set; } = null!;
    public virtual DbSet<PoliticaAprendida> PoliticaAprendida { get; set; } = null!;
    public virtual DbSet<ReporteOrganizacional> ReporteOrganizacional { get; set; } = null!;
    public virtual DbSet<ResultadoAccion> ResultadoAccion { get; set; } = null!;
    public virtual DbSet<RolOrganizacional> RolOrganizacional { get; set; } = null!;
    public virtual DbSet<Territorio> Territorio { get; set; } = null!;
    public virtual DbSet<UsuarioOrganizacional> UsuarioOrganizacional { get; set; } = null!;
    public virtual DbSet<VisitaIntencionVoto> VisitaIntencionVoto { get; set; } = null!;
    public virtual DbSet<Visita> Visita { get; set; } = null!;
    public virtual DbSet<VwMejoresAccionesPorSegmento> VwMejoresAccionesPorSegmentos { get; set; } = null!;


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<AccionRecomendada>(entity =>
        {
            entity.HasKey(e => e.IdAccionRecomendada);

            entity.HasIndex(e => new { e.Tienda, e.Ciudad, e.Estado, e.FechaGeneracion }, "IX_AccionRecomendada_Estado");

            entity.Property(e => e.Ciudad)
                .HasMaxLength(64)
                .IsUnicode(false);

            entity.Property(e => e.CodigoCenturia)
                .HasMaxLength(32)
                .IsUnicode(false);

            entity.Property(e => e.CodigoDignidad)
                .HasMaxLength(32)
                .IsUnicode(false);

            entity.Property(e => e.CodigoIntencionVotoOpcion)
                .HasMaxLength(32)
                .IsUnicode(false);

            entity.Property(e => e.CodigoTerritorio)
                .HasMaxLength(32)
                .IsUnicode(false);

            entity.Property(e => e.EstacionCreacion)
                .HasMaxLength(32)
                .IsUnicode(false)
                .HasComment("Estacion Creacion");

            entity.Property(e => e.EstacionModificacion)
                .HasMaxLength(32)
                .IsUnicode(false)
                .HasComment("Estacion Creacion");

            entity.Property(e => e.Estado)
                .HasMaxLength(32)
                .IsUnicode(false)
                .HasDefaultValueSql("('PENDIENTE')");

            entity.Property(e => e.FechaCreacion)
                .HasColumnType("datetime")
                .HasComment("Fecha de Creación");

            entity.Property(e => e.FechaGeneracion)
                .HasColumnType("datetime")
                .HasDefaultValueSql("(getdate())");

            entity.Property(e => e.FechaModificacion)
                .HasColumnType("datetime")
                .HasComment("Fecha de Actualización");

            entity.Property(e => e.Motivo)
                .HasMaxLength(500)
                .IsUnicode(false);

            entity.Property(e => e.OficinaCreacion).HasComment("Oficina de Creación");

            entity.Property(e => e.OficinaModificacion).HasComment("Oficina de Actualización");

            entity.Property(e => e.Score).HasColumnType("decimal(10, 4)");

            entity.Property(e => e.Tienda)
                .HasMaxLength(32)
                .IsUnicode(false);

            entity.Property(e => e.TipoAccion)
                .HasMaxLength(32)
                .IsUnicode(false);

            entity.Property(e => e.Titulo)
                .HasMaxLength(128)
                .IsUnicode(false);

            entity.Property(e => e.UsuarioCreacion)
                .HasMaxLength(32)
                .IsUnicode(false)
                .HasComment("Usuario de Creación");

            entity.Property(e => e.UsuarioModificacion)
                .HasMaxLength(32)
                .IsUnicode(false)
                .HasComment("Usuario de Actualización");
        });

        modelBuilder.Entity<Centuria>(entity =>
        {
            entity.HasKey(e => e.IdCenturia);

            entity.HasIndex(e => new { e.Tienda, e.Ciudad, e.CodigoCenturia }, "UX_Centuria_Codigo")
                .IsUnique();

            entity.Property(e => e.Activo)
                .IsRequired()
                .HasDefaultValueSql("((1))");

            entity.Property(e => e.Ciudad)
                .HasMaxLength(64)
                .IsUnicode(false);

            entity.Property(e => e.CodigoCenturia)
                .HasMaxLength(32)
                .IsUnicode(false);

            entity.Property(e => e.Descripcion)
                .HasMaxLength(300)
                .IsUnicode(false);

            entity.Property(e => e.EstacionCreacion)
                .HasMaxLength(32)
                .IsUnicode(false)
                .HasComment("Estacion Creacion");

            entity.Property(e => e.EstacionModificacion)
                .HasMaxLength(32)
                .IsUnicode(false)
                .HasComment("Estacion Creacion");

            entity.Property(e => e.FechaCreacion)
                .HasColumnType("datetime")
                .HasComment("Fecha de Creación");

            entity.Property(e => e.FechaModificacion)
                .HasColumnType("datetime")
                .HasComment("Fecha de Actualización");

            entity.Property(e => e.NombreCenturia)
                .HasMaxLength(128)
                .IsUnicode(false);

            entity.Property(e => e.OficinaCreacion).HasComment("Oficina de Creación");

            entity.Property(e => e.OficinaModificacion).HasComment("Oficina de Actualización");

            entity.Property(e => e.ParroquiaPrincipal)
                .HasMaxLength(128)
                .IsUnicode(false);

            entity.Property(e => e.Tienda)
                .HasMaxLength(32)
                .IsUnicode(false);

            entity.Property(e => e.UsuarioCreacion)
                .HasMaxLength(32)
                .IsUnicode(false)
                .HasComment("Usuario de Creación");

            entity.Property(e => e.UsuarioModificacion)
                .HasMaxLength(32)
                .IsUnicode(false)
                .HasComment("Usuario de Actualización");
        });

        modelBuilder.Entity<Ciudadano>(entity =>
        {
            entity.HasKey(e => e.IdCiudadano);

            entity.ToTable("Ciudadano");

            entity.HasIndex(e => new { e.Tienda, e.Ciudad, e.CodigoCenturia, e.CodigoTerritorio, e.Parroquia, e.Barrio }, "IX_Ciudadano_Ubicacion");

            entity.HasIndex(e => new { e.Tienda, e.Ciudad, e.Codigo }, "UX_Ciudadano_Ciudad_NumeroCelular")
                .IsUnique()
                .HasFilter("([Activo]=(1))");

            entity.Property(e => e.Activo)
                .IsRequired()
                .HasDefaultValueSql("((1))");

            entity.Property(e => e.Apellidos)
                .HasMaxLength(128)
                .IsUnicode(false);

            entity.Property(e => e.Barrio)
                .HasMaxLength(128)
                .IsUnicode(false);

            entity.Property(e => e.Ciudad)
                .HasMaxLength(64)
                .IsUnicode(false)
                .HasDefaultValueSql("('PEDERNALES')");

            entity.Property(e => e.Codigo)
                .HasMaxLength(32)
                .IsUnicode(false);

            entity.Property(e => e.CodigoCenturia)
                .HasMaxLength(32)
                .IsUnicode(false);

            entity.Property(e => e.CodigoTerritorio)
                .HasMaxLength(32)
                .IsUnicode(false);

            entity.Property(e => e.Direccion)
                .HasMaxLength(300)
                .IsUnicode(false);

            entity.Property(e => e.EstacionCreacion)
                .HasMaxLength(32)
                .IsUnicode(false)
                .HasComment("Estacion Creacion");

            entity.Property(e => e.EstacionModificacion)
                .HasMaxLength(32)
                .IsUnicode(false)
                .HasComment("Estacion Creacion");

            entity.Property(e => e.FechaCreacion)
                .HasColumnType("datetime")
                .HasComment("Fecha de Creación");

            entity.Property(e => e.FechaModificacion)
                .HasColumnType("datetime")
                .HasComment("Fecha de Actualización");

            entity.Property(e => e.Genero)
                .HasMaxLength(32)
                .IsUnicode(false);

            entity.Property(e => e.Nombres)
                .HasMaxLength(128)
                .IsUnicode(false);

            entity.Property(e => e.NumeroCelular)
                .HasMaxLength(16)
                .IsUnicode(false);

            entity.Property(e => e.OficinaCreacion).HasComment("Oficina de Creación");

            entity.Property(e => e.OficinaModificacion).HasComment("Oficina de Actualización");

            entity.Property(e => e.Parroquia)
                .HasMaxLength(128)
                .IsUnicode(false);

            entity.Property(e => e.PosX).HasColumnType("decimal(18, 10)");

            entity.Property(e => e.PosY).HasColumnType("decimal(18, 10)");

            entity.Property(e => e.Tienda)
                .HasMaxLength(32)
                .IsUnicode(false);

            entity.Property(e => e.UsuarioCreacion)
                .HasMaxLength(32)
                .IsUnicode(false)
                .HasComment("Usuario de Creación");

            entity.Property(e => e.UsuarioModificacion)
                .HasMaxLength(32)
                .IsUnicode(false)
                .HasComment("Usuario de Actualización");
        });

        modelBuilder.Entity<DashboardContador>(entity =>
        {
            entity.HasKey(e => e.IdDashboardContador);

            entity.ToTable("DashboardContador");

            entity.HasIndex(e => new { e.Tienda, e.Ciudad, e.TipoCorte, e.FechaInicio, e.FechaFin, e.CodigoCenturia, e.CodigoTerritorio, e.Parroquia, e.Barrio, e.TipoContador, e.CodigoDignidad, e.CodigoIntencionVotoOpcion }, "UX_DashboardContador_Corte")
                .IsUnique();

            entity.Property(e => e.Barrio)
                .HasMaxLength(128)
                .IsUnicode(false)
                .HasDefaultValueSql("('TODOS')");

            entity.Property(e => e.Ciudad)
                .HasMaxLength(64)
                .IsUnicode(false);

            entity.Property(e => e.CodigoCenturia)
                .HasMaxLength(32)
                .IsUnicode(false)
                .HasDefaultValueSql("('TODAS')");

            entity.Property(e => e.CodigoDignidad)
                .HasMaxLength(32)
                .IsUnicode(false)
                .HasDefaultValueSql("('TODAS')");

            entity.Property(e => e.CodigoIntencionVotoOpcion)
                .HasMaxLength(32)
                .IsUnicode(false)
                .HasDefaultValueSql("('TODAS')");

            entity.Property(e => e.CodigoTerritorio)
                .HasMaxLength(32)
                .IsUnicode(false)
                .HasDefaultValueSql("('TODOS')");

            entity.Property(e => e.EstacionCreacion)
                .HasMaxLength(32)
                .IsUnicode(false)
                .HasComment("Estacion Creacion");

            entity.Property(e => e.EstacionModificacion)
                .HasMaxLength(32)
                .IsUnicode(false)
                .HasComment("Estacion Creacion");

            entity.Property(e => e.FechaCreacion)
                .HasColumnType("datetime")
                .HasComment("Fecha de Creación");

            entity.Property(e => e.FechaFin).HasColumnType("date");

            entity.Property(e => e.FechaInicio).HasColumnType("date");

            entity.Property(e => e.FechaModificacion)
                .HasColumnType("datetime")
                .HasComment("Fecha de Actualización");

            entity.Property(e => e.OficinaCreacion).HasComment("Oficina de Creación");

            entity.Property(e => e.OficinaModificacion).HasComment("Oficina de Actualización");

            entity.Property(e => e.Parroquia)
                .HasMaxLength(128)
                .IsUnicode(false)
                .HasDefaultValueSql("('TODAS')");

            entity.Property(e => e.Tienda)
                .HasMaxLength(32)
                .IsUnicode(false);

            entity.Property(e => e.TipoContador)
                .HasMaxLength(32)
                .IsUnicode(false);

            entity.Property(e => e.TipoCorte)
                .HasMaxLength(32)
                .IsUnicode(false);

            entity.Property(e => e.UsuarioCreacion)
                .HasMaxLength(32)
                .IsUnicode(false)
                .HasComment("Usuario de Creación");

            entity.Property(e => e.UsuarioModificacion)
                .HasMaxLength(32)
                .IsUnicode(false)
                .HasComment("Usuario de Actualización");
        });

        modelBuilder.Entity<IntencionVotoOpcion>(entity =>
        {
            entity.HasKey(e => e.IdIntencionVotoOpcion);

            entity.ToTable("IntencionVotoOpcion");

            entity.HasIndex(e => new { e.Tienda, e.CodigoDignidad, e.Activo, e.Orden }, "IX_IntencionVotoOpcion_Dignidad");

            entity.HasIndex(e => new { e.Tienda, e.CodigoIntencionVotoOpcion }, "UX_IntencionVotoOpcion_Codigo")
                .IsUnique();

            entity.Property(e => e.Activo)
                .IsRequired()
                .HasDefaultValueSql("((1))");

            entity.Property(e => e.CodigoDignidad)
                .HasMaxLength(32)
                .IsUnicode(false);

            entity.Property(e => e.CodigoIntencionVotoOpcion)
                .HasMaxLength(32)
                .IsUnicode(false);

            entity.Property(e => e.EstacionCreacion)
                .HasMaxLength(32)
                .IsUnicode(false)
                .HasComment("Estacion Creacion");

            entity.Property(e => e.EstacionModificacion)
                .HasMaxLength(32)
                .IsUnicode(false)
                .HasComment("Estacion Creacion");

            entity.Property(e => e.FechaCreacion)
                .HasColumnType("datetime")
                .HasComment("Fecha de Creación");

            entity.Property(e => e.FechaModificacion)
                .HasColumnType("datetime")
                .HasComment("Fecha de Actualización");

            entity.Property(e => e.NombreOpcion)
                .HasMaxLength(128)
                .IsUnicode(false);

            entity.Property(e => e.OficinaCreacion).HasComment("Oficina de Creación");

            entity.Property(e => e.OficinaModificacion).HasComment("Oficina de Actualización");

            entity.Property(e => e.Tienda)
                .HasMaxLength(32)
                .IsUnicode(false);

            entity.Property(e => e.UsuarioCreacion)
                .HasMaxLength(32)
                .IsUnicode(false)
                .HasComment("Usuario de Creación");

            entity.Property(e => e.UsuarioModificacion)
                .HasMaxLength(32)
                .IsUnicode(false)
                .HasComment("Usuario de Actualización");
        });

        modelBuilder.Entity<PoliticaAprendida>(entity =>
        {
            entity.HasKey(e => e.IdPoliticaAprendida);

            entity.HasIndex(e => new { e.Tienda, e.Ciudad, e.TipoEstado, e.ClaveEstado, e.TipoAccion }, "UX_PoliticaAprendida_Estado_Accion")
                .IsUnique();

            entity.Property(e => e.Activo)
                .IsRequired()
                .HasDefaultValueSql("((1))");

            entity.Property(e => e.Ciudad)
                .HasMaxLength(64)
                .IsUnicode(false);

            entity.Property(e => e.ClaveEstado)
                .HasMaxLength(128)
                .IsUnicode(false);

            entity.Property(e => e.EstacionCreacion)
                .HasMaxLength(32)
                .IsUnicode(false)
                .HasComment("Estacion Creacion");

            entity.Property(e => e.EstacionModificacion)
                .HasMaxLength(32)
                .IsUnicode(false)
                .HasComment("Estacion Creacion");

            entity.Property(e => e.FechaCreacion)
                .HasColumnType("datetime")
                .HasComment("Fecha de Creación");

            entity.Property(e => e.FechaModificacion)
                .HasColumnType("datetime")
                .HasComment("Fecha de Actualización");

            entity.Property(e => e.OficinaCreacion).HasComment("Oficina de Creación");

            entity.Property(e => e.OficinaModificacion).HasComment("Oficina de Actualización");

            entity.Property(e => e.RecompensaPromedio).HasColumnType("decimal(18, 6)");

            entity.Property(e => e.Tienda)
                .HasMaxLength(32)
                .IsUnicode(false);

            entity.Property(e => e.TipoAccion)
                .HasMaxLength(32)
                .IsUnicode(false);

            entity.Property(e => e.TipoEstado)
                .HasMaxLength(32)
                .IsUnicode(false);

            entity.Property(e => e.UltimaActualizacion)
                .HasColumnType("datetime")
                .HasDefaultValueSql("(getdate())");

            entity.Property(e => e.UsuarioCreacion)
                .HasMaxLength(32)
                .IsUnicode(false)
                .HasComment("Usuario de Creación");

            entity.Property(e => e.UsuarioModificacion)
                .HasMaxLength(32)
                .IsUnicode(false)
                .HasComment("Usuario de Actualización");

            entity.Property(e => e.ValorAprendido).HasColumnType("decimal(18, 6)");
        });

        modelBuilder.Entity<ReporteOrganizacional>(entity =>
        {
            entity.HasKey(e => e.IdReporteOrganizacional);

            entity.ToTable("ReporteOrganizacional");

            entity.HasIndex(e => new { e.Tienda, e.CodigoUsuario, e.FechaReporte }, "IX_ReporteOrganizacional_Usuario_Fecha");

            entity.HasIndex(e => new { e.Tienda, e.CodigoReporte }, "UX_ReporteOrganizacional_Codigo")
                .IsUnique();

            entity.HasIndex(e => new { e.Tienda, e.Ciudad, e.CodigoCenturia, e.TipoReporte, e.FechaReporte }, "UX_ReporteOrganizacional_Corte")
                .IsUnique()
                .HasFilter("([Estado]<>'ANULADO')");

            entity.Property(e => e.Adversario)
                .HasMaxLength(128)
                .IsUnicode(false);

            entity.Property(e => e.Ciudad)
                .HasMaxLength(64)
                .IsUnicode(false);

            entity.Property(e => e.CoberturaPorcentaje).HasColumnType("decimal(5, 2)");

            entity.Property(e => e.CodigoCenturia)
                .HasMaxLength(32)
                .IsUnicode(false);

            entity.Property(e => e.CodigoReporte)
                .HasMaxLength(32)
                .IsUnicode(false);

            entity.Property(e => e.CodigoRol)
                .HasMaxLength(32)
                .IsUnicode(false);

            entity.Property(e => e.CodigoUsuario)
                .HasMaxLength(32)
                .IsUnicode(false);

            entity.Property(e => e.EstacionCreacion)
                .HasMaxLength(32)
                .IsUnicode(false)
                .HasComment("Estacion Creacion");

            entity.Property(e => e.EstacionModificacion)
                .HasMaxLength(32)
                .IsUnicode(false)
                .HasComment("Estacion Creacion");

            entity.Property(e => e.Estado)
                .HasMaxLength(32)
                .IsUnicode(false)
                .HasDefaultValueSql("('ENVIADO')");

            entity.Property(e => e.FechaCreacion)
                .HasColumnType("datetime")
                .HasComment("Fecha de Creación");

            entity.Property(e => e.FechaEnvio)
                .HasColumnType("datetime")
                .HasDefaultValueSql("(getdate())");

            entity.Property(e => e.FechaModificacion)
                .HasColumnType("datetime")
                .HasComment("Fecha de Actualización");

            entity.Property(e => e.FechaReporte).HasColumnType("date");

            entity.Property(e => e.HorasCampo).HasColumnType("decimal(10, 2)");

            entity.Property(e => e.MaterialSolicitado)
                .HasMaxLength(300)
                .IsUnicode(false);

            entity.Property(e => e.MontoPresupuesto).HasColumnType("decimal(12, 2)");

            entity.Property(e => e.NivelAlerta)
                .HasMaxLength(32)
                .IsUnicode(false);

            entity.Property(e => e.ObjecionFrecuente)
                .HasMaxLength(128)
                .IsUnicode(false);

            entity.Property(e => e.Observacion)
                .HasMaxLength(500)
                .IsUnicode(false);

            entity.Property(e => e.OficinaCreacion).HasComment("Oficina de Creación");

            entity.Property(e => e.OficinaModificacion).HasComment("Oficina de Actualización");

            entity.Property(e => e.SectorActividadAdversario)
                .HasMaxLength(128)
                .IsUnicode(false);

            entity.Property(e => e.SectoresCompletados)
                .HasMaxLength(500)
                .IsUnicode(false);

            entity.Property(e => e.SectoresPendientes)
                .HasMaxLength(500)
                .IsUnicode(false);

            entity.Property(e => e.TemaLlamada)
                .HasMaxLength(128)
                .IsUnicode(false);

            entity.Property(e => e.TemperaturaSocial)
                .HasMaxLength(32)
                .IsUnicode(false);

            entity.Property(e => e.TendenciaVah)
                .HasMaxLength(32)
                .IsUnicode(false)
                .HasColumnName("TendenciaVAH");

            entity.Property(e => e.Tienda)
                .HasMaxLength(32)
                .IsUnicode(false);

            entity.Property(e => e.TipoActividadAdversario)
                .HasMaxLength(32)
                .IsUnicode(false);

            entity.Property(e => e.TipoReporte)
                .HasMaxLength(32)
                .IsUnicode(false);

            entity.Property(e => e.UsuarioCreacion)
                .HasMaxLength(32)
                .IsUnicode(false)
                .HasComment("Usuario de Creación");

            entity.Property(e => e.UsuarioModificacion)
                .HasMaxLength(32)
                .IsUnicode(false)
                .HasComment("Usuario de Actualización");

            entity.Property(e => e.Vah)
                .HasColumnType("decimal(10, 2)")
                .HasColumnName("VAH");

            entity.Property(e => e.ZonaPrioritariaManana)
                .HasMaxLength(128)
                .IsUnicode(false);
        });

        modelBuilder.Entity<ResultadoAccion>(entity =>
        {
            entity.HasKey(e => e.IdResultadoAccion);

            entity.ToTable("ResultadoAccion");

            entity.HasIndex(e => new { e.IdAccionRecomendada, e.FechaResultado }, "IX_ResultadoAccion_Accion");

            entity.Property(e => e.EstacionCreacion)
                .HasMaxLength(32)
                .IsUnicode(false)
                .HasComment("Estacion Creacion");

            entity.Property(e => e.EstacionModificacion)
                .HasMaxLength(32)
                .IsUnicode(false)
                .HasComment("Estacion Creacion");

            entity.Property(e => e.FechaCreacion)
                .HasColumnType("datetime")
                .HasComment("Fecha de Creación");

            entity.Property(e => e.FechaModificacion)
                .HasColumnType("datetime")
                .HasComment("Fecha de Actualización");

            entity.Property(e => e.FechaResultado)
                .HasColumnType("datetime")
                .HasDefaultValueSql("(getdate())");

            entity.Property(e => e.Observacion)
                .HasMaxLength(500)
                .IsUnicode(false);

            entity.Property(e => e.OficinaCreacion).HasComment("Oficina de Creación");

            entity.Property(e => e.OficinaModificacion).HasComment("Oficina de Actualización");

            entity.Property(e => e.Recompensa).HasColumnType("decimal(10, 4)");

            entity.Property(e => e.TipoMetrica)
                .HasMaxLength(32)
                .IsUnicode(false);

            entity.Property(e => e.UsuarioCreacion)
                .HasMaxLength(32)
                .IsUnicode(false)
                .HasComment("Usuario de Creación");

            entity.Property(e => e.UsuarioModificacion)
                .HasMaxLength(32)
                .IsUnicode(false)
                .HasComment("Usuario de Actualización");

            entity.HasOne(d => d.IdAccionRecomendadaNavigation)
                .WithMany(p => p.ResultadoAccions)
                .HasForeignKey(d => d.IdAccionRecomendada)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_ResultadoAccion_AccionRecomendada");
        });

        modelBuilder.Entity<RolOrganizacional>(entity =>
        {
            entity.HasKey(e => e.IdRolOrganizacional);

            entity.ToTable("RolOrganizacional");

            entity.HasIndex(e => new { e.Tienda, e.CodigoRol }, "UX_RolOrganizacional")
                .IsUnique();

            entity.Property(e => e.Activo)
                .IsRequired()
                .HasDefaultValueSql("((1))");

            entity.Property(e => e.CodigoRol)
                .HasMaxLength(32)
                .IsUnicode(false);

            entity.Property(e => e.EstacionCreacion)
                .HasMaxLength(32)
                .IsUnicode(false)
                .HasComment("Estacion Creacion");

            entity.Property(e => e.EstacionModificacion)
                .HasMaxLength(32)
                .IsUnicode(false)
                .HasComment("Estacion Creacion");

            entity.Property(e => e.FechaCreacion)
                .HasColumnType("datetime")
                .HasComment("Fecha de Creación");

            entity.Property(e => e.FechaModificacion)
                .HasColumnType("datetime")
                .HasComment("Fecha de Actualización");

            entity.Property(e => e.NombreRol)
                .HasMaxLength(128)
                .IsUnicode(false);

            entity.Property(e => e.OficinaCreacion).HasComment("Oficina de Creación");

            entity.Property(e => e.OficinaModificacion).HasComment("Oficina de Actualización");

            entity.Property(e => e.Tienda)
                .HasMaxLength(32)
                .IsUnicode(false);

            entity.Property(e => e.UsuarioCreacion)
                .HasMaxLength(32)
                .IsUnicode(false)
                .HasComment("Usuario de Creación");

            entity.Property(e => e.UsuarioModificacion)
                .HasMaxLength(32)
                .IsUnicode(false)
                .HasComment("Usuario de Actualización");
        });

        modelBuilder.Entity<Territorio>(entity =>
        {
            entity.HasKey(e => e.IdTerritorio);

            entity.ToTable("Territorio");

            entity.HasIndex(e => new { e.Tienda, e.Ciudad, e.CodigoCenturia, e.TipoTerritorio, e.Parroquia, e.Barrio }, "IX_Territorio_Centuria");

            entity.HasIndex(e => new { e.Tienda, e.Ciudad, e.CodigoTerritorio }, "UX_Territorio_Codigo")
                .IsUnique();

            entity.Property(e => e.Activo)
                .IsRequired()
                .HasDefaultValueSql("((1))");

            entity.Property(e => e.Barrio)
                .HasMaxLength(128)
                .IsUnicode(false);

            entity.Property(e => e.Ciudad)
                .HasMaxLength(64)
                .IsUnicode(false);

            entity.Property(e => e.CodigoCenturia)
                .HasMaxLength(32)
                .IsUnicode(false);

            entity.Property(e => e.CodigoTerritorio)
                .HasMaxLength(32)
                .IsUnicode(false);

            entity.Property(e => e.EstacionCreacion)
                .HasMaxLength(32)
                .IsUnicode(false)
                .HasComment("Estacion Creacion");

            entity.Property(e => e.EstacionModificacion)
                .HasMaxLength(32)
                .IsUnicode(false)
                .HasComment("Estacion Creacion");

            entity.Property(e => e.EstadoCobertura)
                .HasMaxLength(32)
                .IsUnicode(false)
                .HasDefaultValueSql("('SIN_CONTACTO')");

            entity.Property(e => e.FechaCreacion)
                .HasColumnType("datetime")
                .HasComment("Fecha de Creación");

            entity.Property(e => e.FechaModificacion)
                .HasColumnType("datetime")
                .HasComment("Fecha de Actualización");

            entity.Property(e => e.NombreTerritorio)
                .HasMaxLength(128)
                .IsUnicode(false);

            entity.Property(e => e.OficinaCreacion).HasComment("Oficina de Creación");

            entity.Property(e => e.OficinaModificacion).HasComment("Oficina de Actualización");

            entity.Property(e => e.Parroquia)
                .HasMaxLength(128)
                .IsUnicode(false);

            entity.Property(e => e.Tienda)
                .HasMaxLength(32)
                .IsUnicode(false);

            entity.Property(e => e.TipoTerritorio)
                .HasMaxLength(32)
                .IsUnicode(false);

            entity.Property(e => e.UsuarioCreacion)
                .HasMaxLength(32)
                .IsUnicode(false)
                .HasComment("Usuario de Creación");

            entity.Property(e => e.UsuarioModificacion)
                .HasMaxLength(32)
                .IsUnicode(false)
                .HasComment("Usuario de Actualización");
        });

        modelBuilder.Entity<UsuarioOrganizacional>(entity =>
        {
            entity.HasKey(e => e.IdUsuarioOrganizacional);

            entity.ToTable("UsuarioOrganizacional");

            entity.HasIndex(e => new { e.Tienda, e.CodigoRol, e.CodigoCenturia, e.Activo }, "IX_UsuarioOrganizacional_Rol_Centuria");

            entity.HasIndex(e => new { e.Tienda, e.CodigoUsuario }, "UX_UsuarioOrganizacional_Codigo")
                .IsUnique();

            entity.Property(e => e.Activo)
                .IsRequired()
                .HasDefaultValueSql("((1))");

            entity.Property(e => e.Apellidos)
                .HasMaxLength(128)
                .IsUnicode(false);

            entity.Property(e => e.CodigoCenturia)
                .HasMaxLength(32)
                .IsUnicode(false);

            entity.Property(e => e.CodigoRol)
                .HasMaxLength(32)
                .IsUnicode(false);

            entity.Property(e => e.CodigoUsuario)
                .HasMaxLength(32)
                .IsUnicode(false);

            entity.Property(e => e.EstacionCreacion)
                .HasMaxLength(32)
                .IsUnicode(false)
                .HasComment("Estacion Creacion");

            entity.Property(e => e.EstacionModificacion)
                .HasMaxLength(32)
                .IsUnicode(false)
                .HasComment("Estacion Creacion");

            entity.Property(e => e.FechaCreacion)
                .HasColumnType("datetime")
                .HasComment("Fecha de Creación");

            entity.Property(e => e.FechaModificacion)
                .HasColumnType("datetime")
                .HasComment("Fecha de Actualización");

            entity.Property(e => e.Nombres)
                .HasMaxLength(128)
                .IsUnicode(false);

            entity.Property(e => e.OficinaCreacion).HasComment("Oficina de Creación");

            entity.Property(e => e.OficinaModificacion).HasComment("Oficina de Actualización");

            entity.Property(e => e.Telefono)
                .HasMaxLength(16)
                .IsUnicode(false);

            entity.Property(e => e.Tienda)
                .HasMaxLength(32)
                .IsUnicode(false);

            entity.Property(e => e.UsuarioCreacion)
                .HasMaxLength(32)
                .IsUnicode(false)
                .HasComment("Usuario de Creación");

            entity.Property(e => e.UsuarioLogin)
                .HasMaxLength(120)
                .IsUnicode(false);

            entity.Property(e => e.UsuarioModificacion)
                .HasMaxLength(32)
                .IsUnicode(false)
                .HasComment("Usuario de Actualización");
        });

        modelBuilder.Entity<VisitaIntencionVoto>(entity =>
        {
            entity.HasKey(e => e.IdVisitaIntencionVoto);

            entity.ToTable("VisitaIntencionVoto");

            entity.HasIndex(e => new { e.CodigoDignidad, e.CodigoIntencionVotoOpcion }, "IX_VisitaIntencionVoto_Opcion");

            entity.HasIndex(e => new { e.IdVisita, e.CodigoDignidad }, "UX_VisitaIntencionVoto_Visita_Dignidad")
                .IsUnique();

            entity.Property(e => e.CodigoDignidad)
                .HasMaxLength(32)
                .IsUnicode(false);

            entity.Property(e => e.CodigoIntencionVotoOpcion)
                .HasMaxLength(32)
                .IsUnicode(false);

            entity.Property(e => e.EstacionCreacion)
                .HasMaxLength(32)
                .IsUnicode(false)
                .HasComment("Estacion Creacion");

            entity.Property(e => e.EstacionModificacion)
                .HasMaxLength(32)
                .IsUnicode(false)
                .HasComment("Estacion Creacion");

            entity.Property(e => e.FechaCreacion)
                .HasColumnType("datetime")
                .HasComment("Fecha de Creación");

            entity.Property(e => e.FechaModificacion)
                .HasColumnType("datetime")
                .HasComment("Fecha de Actualización");

            entity.Property(e => e.Observacion)
                .HasMaxLength(500)
                .IsUnicode(false);

            entity.Property(e => e.OficinaCreacion).HasComment("Oficina de Creación");

            entity.Property(e => e.OficinaModificacion).HasComment("Oficina de Actualización");

            entity.Property(e => e.UsuarioCreacion)
                .HasMaxLength(32)
                .IsUnicode(false)
                .HasComment("Usuario de Creación");

            entity.Property(e => e.UsuarioModificacion)
                .HasMaxLength(32)
                .IsUnicode(false)
                .HasComment("Usuario de Actualización");

            entity.HasOne(d => d.IdVisitaNavigation)
                .WithMany(p => p.VisitaIntencionVotos)
                .HasForeignKey(d => d.IdVisita)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_VisitaIntencionVoto_Visita");
        });

        modelBuilder.Entity<Visita>(entity =>
        {
            entity.HasKey(e => e.IdVisita);

            entity.HasIndex(e => new { e.IdCiudadano, e.FechaVisita }, "IX_Visita_Ciudadano_Fecha");

            entity.HasIndex(e => new { e.Tienda, e.Ciudad, e.CodigoCenturia, e.CodigoTerritorio, e.FechaVisita }, "IX_Visita_Territorio_Fecha");

            entity.Property(e => e.Activo)
                .IsRequired()
                .HasDefaultValueSql("((1))");

            entity.Property(e => e.Ciudad)
                .HasMaxLength(64)
                .IsUnicode(false);

            entity.Property(e => e.CodigoCenturia)
                .HasMaxLength(32)
                .IsUnicode(false);

            entity.Property(e => e.CodigoTerritorio)
                .HasMaxLength(32)
                .IsUnicode(false);

            entity.Property(e => e.CodigoUsuario)
                .HasMaxLength(32)
                .IsUnicode(false);

            entity.Property(e => e.EstacionCreacion)
                .HasMaxLength(32)
                .IsUnicode(false)
                .HasComment("Estacion Creacion");

            entity.Property(e => e.EstacionModificacion)
                .HasMaxLength(32)
                .IsUnicode(false)
                .HasComment("Estacion Creacion");

            entity.Property(e => e.EstadoSync)
                .HasMaxLength(32)
                .IsUnicode(false)
                .HasDefaultValueSql("('SINCRONIZADO')");

            entity.Property(e => e.FechaCreacion)
                .HasColumnType("datetime")
                .HasComment("Fecha de Creación");

            entity.Property(e => e.FechaModificacion)
                .HasColumnType("datetime")
                .HasComment("Fecha de Actualización");

            entity.Property(e => e.FechaVisita)
                .HasColumnType("datetime")
                .HasDefaultValueSql("(getdate())");

            entity.Property(e => e.NotaEncuestador)
                .HasMaxLength(500)
                .IsUnicode(false);

            entity.Property(e => e.OficinaCreacion).HasComment("Oficina de Creación");

            entity.Property(e => e.OficinaModificacion).HasComment("Oficina de Actualización");

            entity.Property(e => e.PosX).HasColumnType("decimal(18, 10)");

            entity.Property(e => e.PosY).HasColumnType("decimal(18, 10)");

            entity.Property(e => e.ProblemaTexto)
                .HasMaxLength(300)
                .IsUnicode(false);

            entity.Property(e => e.ReferidoNombres)
                .HasMaxLength(128)
                .IsUnicode(false);

            entity.Property(e => e.ReferidoTelefono)
                .HasMaxLength(16)
                .IsUnicode(false);

            entity.Property(e => e.TemaInteresReal)
                .HasMaxLength(500)
                .IsUnicode(false);

            entity.Property(e => e.Tienda)
                .HasMaxLength(32)
                .IsUnicode(false);

            entity.Property(e => e.UsuarioCreacion)
                .HasMaxLength(32)
                .IsUnicode(false)
                .HasComment("Usuario de Creación");

            entity.Property(e => e.UsuarioModificacion)
                .HasMaxLength(32)
                .IsUnicode(false)
                .HasComment("Usuario de Actualización");

            entity.HasOne(d => d.IdCiudadanoNavigation)
                .WithMany(p => p.Visita)
                .HasForeignKey(d => d.IdCiudadano)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Visita_Ciudadano");
        });

        modelBuilder.Entity<VwMejoresAccionesPorSegmento>(entity =>
        {
            entity.HasNoKey();

            entity.ToView("vw_MejoresAccionesPorSegmento");

            entity.Property(e => e.AccionCodigo)
                .HasMaxLength(64)
                .IsUnicode(false);

            entity.Property(e => e.AccionNombre)
                .HasMaxLength(256)
                .IsUnicode(false);

            entity.Property(e => e.ModeloOrigen)
                .HasMaxLength(128)
                .IsUnicode(false);

            entity.Property(e => e.RecompensaPromedio).HasColumnType("decimal(10, 4)");

            entity.Property(e => e.SegmentoCodigo)
                .HasMaxLength(256)
                .IsUnicode(false);

            entity.Property(e => e.SegmentoDescripcion)
                .HasMaxLength(512)
                .IsUnicode(false);

            entity.Property(e => e.ValorQ).HasColumnType("decimal(10, 4)");

            entity.Property(e => e.VersionModelo)
                .HasMaxLength(64)
                .IsUnicode(false);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}

