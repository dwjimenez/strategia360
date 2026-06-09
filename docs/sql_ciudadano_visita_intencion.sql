/*
  StrategIA360 - Tablas base: ciudadano, visita e intencion de voto
  Motor: SQL Server

  Basado en el formulario actual de la app:
  - src/screens/visits/CitizenFormScreen.js
  - src/data/opcionesCatalog.js
*/

set ansi_nulls on;
set quoted_identifier on;
go

create table RolOrganizacional (
  IdRolOrganizacional int identity(1,1) not null,
  Tienda varchar(32) not null,
  CodigoRol varchar(32) not null,
  NombreRol varchar(128) not null,
  NivelJerarquico int not null constraint DF_RolOrganizacional_NivelJerarquico default 0,
  EsComando bit not null constraint DF_RolOrganizacional_EsComando default 0,
  Activo bit not null constraint DF_RolOrganizacional_Activo default 1,
  constraint PK_RolOrganizacional primary key (IdRolOrganizacional)
);
go

create unique index UX_RolOrganizacional_Codigo
on RolOrganizacional (Tienda, CodigoRol);
go

create table Centuria (
  IdCenturia int identity(1,1) not null,
  Tienda varchar(32) not null,
  Ciudad varchar(64) not null,
  CodigoCenturia varchar(32) not null,
  NombreCenturia varchar(128) not null,
  ParroquiaPrincipal varchar(128) not null,
  Descripcion varchar(300) null,
  MetaContactosSemana int not null constraint DF_Centuria_MetaContactosSemana default 0,
  Activo bit not null constraint DF_Centuria_Activo default 1,
  constraint PK_Centuria primary key (IdCenturia)
);
go

create unique index UX_Centuria_Codigo
on Centuria (Tienda, Ciudad, CodigoCenturia);
go

create table Territorio (
  IdTerritorio int identity(1,1) not null,
  Tienda varchar(32) not null,
  Ciudad varchar(64) not null,
  CodigoTerritorio varchar(32) not null,
  CodigoCenturia varchar(32) not null,
  TipoTerritorio varchar(32) not null,
  NombreTerritorio varchar(128) not null,
  Parroquia varchar(128) null,
  Barrio varchar(128) null,
  EstadoCobertura varchar(32) not null constraint DF_Territorio_EstadoCobertura default 'SIN_CONTACTO',
  Activo bit not null constraint DF_Territorio_Activo default 1,
  constraint PK_Territorio primary key (IdTerritorio),
  constraint CK_Territorio_TipoTerritorio check (
    TipoTerritorio in ('PARROQUIA','BARRIO','COMUNIDAD')
  ),
  constraint CK_Territorio_EstadoCobertura check (
    EstadoCobertura in ('CUBIERTO','EN_PROCESO','SIN_CONTACTO','CRITICO')
  )
);
go

create unique index UX_Territorio_Codigo
on Territorio (Tienda, Ciudad, CodigoTerritorio);
go

create index IX_Territorio_Centuria
on Territorio (Tienda, Ciudad, CodigoCenturia, TipoTerritorio, Parroquia, Barrio);
go

create table UsuarioOrganizacional (
  IdUsuarioOrganizacional int identity(1,1) not null,
  Tienda varchar(32) not null,
  CodigoUsuario varchar(32) not null,
  CodigoRol varchar(32) not null,
  CodigoCenturia varchar(32) null,
  Nombres varchar(128) not null,
  Apellidos varchar(128) null,
  Telefono varchar(16) null,
  UsuarioLogin varchar(120) null,
  Activo bit not null constraint DF_UsuarioOrganizacional_Activo default 1,
  FechaCreacion datetime not null constraint DF_UsuarioOrganizacional_FechaCreacion default getdate(),
  constraint PK_UsuarioOrganizacional primary key (IdUsuarioOrganizacional)
);
go

create unique index UX_UsuarioOrganizacional_Codigo
on UsuarioOrganizacional (Tienda, CodigoUsuario);
go

create index IX_UsuarioOrganizacional_Rol_Centuria
on UsuarioOrganizacional (Tienda, CodigoRol, CodigoCenturia, Activo);
go

create table Ciudadano (
  IdCiudadano bigint identity(1,1) not null,
  Tienda varchar(32) not null,
  Ciudad varchar(64) not null constraint DF_Ciudadano_Ciudad default 'PEDERNALES',
  CodigoCenturia varchar(32) null,
  CodigoTerritorio varchar(32) null,
  Codigo varchar(32) null,
  Nombres varchar(128) not null,
  Apellidos varchar(128) null,
  NumeroCelular varchar(16) not null,
  Genero varchar(32) not null,
  MiembrosFamilia int not null constraint DF_Ciudadano_MiembrosFamilia default 0,
  MiembrosVotan int not null constraint DF_Ciudadano_MiembrosVotan default 0,
  MiembrosDiscapacidad int not null constraint DF_Ciudadano_MiembrosDiscapacidad default 0,
  Parroquia varchar(128) not null,
  Barrio varchar(128) not null,
  Direccion varchar(300) not null,
  PosX decimal(18,10) null,
  PosY decimal(18,10) null,
  FechaRegistro date not null constraint DF_Ciudadano_FechaRegistro default convert(date, getdate()),
  FechaCreacion datetime not null constraint DF_Ciudadano_FechaCreacion default getdate(),
  FechaActualizacion datetime null,
  Activo bit not null constraint DF_Ciudadano_Activo default 1,
  constraint PK_Ciudadano primary key (IdCiudadano),
  constraint CK_Ciudadano_Genero check (Genero in ('masculino','femenino'))
);
go

create unique index UX_Ciudadano_Ciudad_NumeroCelular
on Ciudadano (Tienda, Ciudad, NumeroCelular)
where Activo = 1;
go

create index IX_Ciudadano_Ubicacion
on Ciudadano (Tienda, Ciudad, CodigoCenturia, CodigoTerritorio, Parroquia, Barrio);
go

create table Visita (
  IdVisita bigint identity(1,1) not null,
  IdCiudadano bigint not null,
  Tienda varchar(32) not null,
  Ciudad varchar(64) not null,
  CodigoUsuario varchar(32) null,
  CodigoCenturia varchar(32) null,
  CodigoTerritorio varchar(32) null,
  FechaVisita datetime not null constraint DF_Visita_FechaVisita default getdate(),
  PersonasMayoresCasa int null constraint DF_Visita_PersonasMayoresCasa default 0,
  ProblemaPrincipal varchar(32) null,
  ProblemaTexto varchar(300) null,
  ResultadoVisita varchar(32) null,
  RazonNoIndeciso varchar(32) null,
  TemasInteres varchar(500) not null,
  TemaInteresReal varchar(500) null,
  TieneReferido bit not null constraint DF_Visita_TieneReferido default 0,
  ReferidoNombres varchar(128) null,
  ReferidoTelefono varchar(16) null,
  NotaEncuestador varchar(500) null,
  PosX decimal(18,10) null,
  PosY decimal(18,10) null,
  EstadoSync varchar(32) not null constraint DF_Visita_EstadoSync default 'SINCRONIZADO',
  FechaCreacion datetime not null constraint DF_Visita_FechaCreacion default getdate(),
  Activo bit not null constraint DF_Visita_Activo default 1,
  constraint PK_Visita primary key (IdVisita),
  constraint FK_Visita_Ciudadano foreign key (IdCiudadano)
    references Ciudadano (IdCiudadano),
  constraint CK_Visita_ResultadoVisita check (
    ResultadoVisita is null or ResultadoVisita in ('PROMOVIDO','INDECISO','NO')
  ),
  constraint CK_Visita_EstadoSync check (EstadoSync in ('PENDIENTE','SINCRONIZADO','ERROR'))
);
go

create index IX_Visita_Ciudadano_Fecha
on Visita (IdCiudadano, FechaVisita);
go

create index IX_Visita_Territorio_Fecha
on Visita (Tienda, Ciudad, CodigoCenturia, CodigoTerritorio, FechaVisita);
go

create table IntencionVotoOpcion (
  IdIntencionVotoOpcion int identity(1,1) not null,
  Tienda varchar(32) not null,
  CodigoIntencionVotoOpcion varchar(32) not null,
  CodigoDignidad varchar(32) not null,
  NombreOpcion varchar(128) not null,
  Orden int not null constraint DF_IntencionVotoOpcion_Orden default 0,
  Activo bit not null constraint DF_IntencionVotoOpcion_Activo default 1,
  constraint PK_IntencionVotoOpcion primary key (IdIntencionVotoOpcion),
  constraint CK_IntencionVotoOpcion_Dignidad check (
    CodigoDignidad in ('ALCALDE','CONCEJAL','VOCALES')
  )
);
go

create unique index UX_IntencionVotoOpcion_Codigo
on IntencionVotoOpcion (Tienda, CodigoIntencionVotoOpcion);
go

create index IX_IntencionVotoOpcion_Dignidad
on IntencionVotoOpcion (Tienda, CodigoDignidad, Activo, Orden);
go

create table VisitaIntencionVoto (
  IdVisitaIntencionVoto bigint identity(1,1) not null,
  IdVisita bigint not null,
  CodigoDignidad varchar(32) not null,
  CodigoIntencionVotoOpcion varchar(32) not null,
  Observacion varchar(500) null,
  FechaCreacion datetime not null constraint DF_VisitaIntencionVoto_FechaCreacion default getdate(),
  constraint PK_VisitaIntencionVoto primary key (IdVisitaIntencionVoto),
  constraint FK_VisitaIntencionVoto_Visita foreign key (IdVisita)
    references Visita (IdVisita),
  constraint CK_VisitaIntencionVoto_Dignidad check (
    CodigoDignidad in ('ALCALDE','CONCEJAL','VOCALES')
  )
);
go

create unique index UX_VisitaIntencionVoto_Visita_Dignidad
on VisitaIntencionVoto (IdVisita, CodigoDignidad);
go

create index IX_VisitaIntencionVoto_Opcion
on VisitaIntencionVoto (CodigoDignidad, CodigoIntencionVotoOpcion);
go

create table DashboardContador (
  IdDashboardContador bigint identity(1,1) not null,
  Tienda varchar(32) not null,
  Ciudad varchar(64) not null,
  TipoCorte varchar(32) not null,
  FechaInicio date not null,
  FechaFin date not null,
  CodigoCenturia varchar(32) not null constraint DF_DashboardContador_Centuria default 'TODAS',
  CodigoTerritorio varchar(32) not null constraint DF_DashboardContador_Territorio default 'TODOS',
  Parroquia varchar(128) not null constraint DF_DashboardContador_Parroquia default 'TODAS',
  Barrio varchar(128) not null constraint DF_DashboardContador_Barrio default 'TODOS',
  TipoContador varchar(32) not null,
  CodigoDignidad varchar(32) not null constraint DF_DashboardContador_Dignidad default 'TODAS',
  CodigoIntencionVotoOpcion varchar(32) not null constraint DF_DashboardContador_Intencion default 'TODAS',
  Total int not null constraint DF_DashboardContador_Total default 0,
  FechaProceso datetime not null constraint DF_DashboardContador_FechaProceso default getdate(),
  constraint PK_DashboardContador primary key (IdDashboardContador),
  constraint CK_DashboardContador_TipoCorte check (
    TipoCorte in ('DIARIO','SEMANAL','MENSUAL','ACUMULADO')
  ),
  constraint CK_DashboardContador_TipoContador check (
    TipoContador in (
      'CIUDADANO',
      'VISITA',
      'VISITA_CON_GPS',
      'GENERO',
      'MIEMBROS_FAMILIA',
      'MIEMBROS_VOTAN',
      'MIEMBROS_DISCAPACIDAD',
      'REFERIDO',
      'INTENCION_VOTO'
    )
  )
);
go

create unique index UX_DashboardContador_Corte
on DashboardContador (
  Tienda,
  Ciudad,
  TipoCorte,
  FechaInicio,
  FechaFin,
  CodigoCenturia,
  CodigoTerritorio,
  Parroquia,
  Barrio,
  TipoContador,
  CodigoDignidad,
  CodigoIntencionVotoOpcion
);
go

create table ReporteOrganizacional (
  IdReporteOrganizacional bigint identity(1,1) not null,
  Tienda varchar(32) not null,
  Ciudad varchar(64) not null,
  CodigoReporte varchar(32) not null,
  TipoReporte varchar(32) not null,
  CodigoUsuario varchar(32) not null,
  CodigoRol varchar(32) not null,
  CodigoCenturia varchar(32) not null,
  FechaReporte date not null,
  FechaEnvio datetime not null constraint DF_ReporteOrganizacional_FechaEnvio default getdate(),
  RelatoresActivos int not null constraint DF_ReporteOrganizacional_RelatoresActivos default 0,
  SoldadosActivos int not null constraint DF_ReporteOrganizacional_SoldadosActivos default 0,
  HorasCampo decimal(10,2) not null constraint DF_ReporteOrganizacional_HorasCampo default 0,
  PromovidosCompletos int not null constraint DF_ReporteOrganizacional_PromovidosCompletos default 0,
  PromovidosIncompletos int not null constraint DF_ReporteOrganizacional_PromovidosIncompletos default 0,
  ContactosSinDatos int not null constraint DF_ReporteOrganizacional_ContactosSinDatos default 0,
  VAH decimal(10,2) not null constraint DF_ReporteOrganizacional_VAH default 0,
  TendenciaVAH varchar(32) null,
  CoberturaPorcentaje decimal(5,2) not null constraint DF_ReporteOrganizacional_Cobertura default 0,
  SectoresCompletados varchar(500) null,
  SectoresPendientes varchar(500) null,
  ZonaPrioritariaManana varchar(128) null,
  TemperaturaSocial varchar(32) null,
  ObjecionFrecuente varchar(128) null,
  ActividadAdversario bit not null constraint DF_ReporteOrganizacional_ActividadAdversario default 0,
  Adversario varchar(128) null,
  TipoActividadAdversario varchar(32) null,
  SectorActividadAdversario varchar(128) null,
  NivelAlerta varchar(32) null,
  NecesitaMaterial bit not null constraint DF_ReporteOrganizacional_NecesitaMaterial default 0,
  MaterialSolicitado varchar(300) null,
  NecesitaPresupuesto bit not null constraint DF_ReporteOrganizacional_NecesitaPresupuesto default 0,
  MontoPresupuesto decimal(12,2) not null constraint DF_ReporteOrganizacional_MontoPresupuesto default 0,
  NecesitaLlamada bit not null constraint DF_ReporteOrganizacional_NecesitaLlamada default 0,
  TemaLlamada varchar(128) null,
  Observacion varchar(500) null,
  Estado varchar(32) not null constraint DF_ReporteOrganizacional_Estado default 'ENVIADO',
  constraint PK_ReporteOrganizacional primary key (IdReporteOrganizacional),
  constraint CK_ReporteOrganizacional_TipoReporte check (
    TipoReporte in ('F_EXP','F_CEN')
  ),
  constraint CK_ReporteOrganizacional_TendenciaVAH check (
    TendenciaVAH is null or TendenciaVAH in ('SUBIO','IGUAL','BAJO','SIN_DATO')
  ),
  constraint CK_ReporteOrganizacional_NivelAlerta check (
    NivelAlerta is null or NivelAlerta in ('VERDE','AMARILLO','ROJO')
  ),
  constraint CK_ReporteOrganizacional_Estado check (
    Estado in ('BORRADOR','ENVIADO','EDITADO','ANULADO')
  )
);
go

create unique index UX_ReporteOrganizacional_Codigo
on ReporteOrganizacional (Tienda, CodigoReporte);
go

create unique index UX_ReporteOrganizacional_Corte
on ReporteOrganizacional (Tienda, Ciudad, CodigoCenturia, TipoReporte, FechaReporte)
where Estado <> 'ANULADO';
go

create index IX_ReporteOrganizacional_Usuario_Fecha
on ReporteOrganizacional (Tienda, CodigoUsuario, FechaReporte);
go

create table AccionRecomendada (
  IdAccionRecomendada bigint identity(1,1) not null,
  Tienda varchar(32) not null,
  Ciudad varchar(64) not null,
  FechaGeneracion datetime not null constraint DF_AccionRecomendada_FechaGeneracion default getdate(),
  TipoAccion varchar(32) not null,
  CodigoCenturia varchar(32) null,
  CodigoTerritorio varchar(32) null,
  CodigoDignidad varchar(32) null,
  CodigoIntencionVotoOpcion varchar(32) null,
  Titulo varchar(128) not null,
  Motivo varchar(500) null,
  Score decimal(10,4) not null constraint DF_AccionRecomendada_Score default 0,
  Estado varchar(32) not null constraint DF_AccionRecomendada_Estado default 'PENDIENTE',
  constraint PK_AccionRecomendada primary key (IdAccionRecomendada),
  constraint CK_AccionRecomendada_Estado check (
    Estado in ('PENDIENTE','APLICADA','DESCARTADA','CERRADA')
  )
);
go

create index IX_AccionRecomendada_Estado
on AccionRecomendada (Tienda, Ciudad, Estado, FechaGeneracion);
go

create table ResultadoAccion (
  IdResultadoAccion bigint identity(1,1) not null,
  IdAccionRecomendada bigint not null,
  FechaResultado datetime not null constraint DF_ResultadoAccion_FechaResultado default getdate(),
  TipoMetrica varchar(32) not null,
  TotalAntes int not null constraint DF_ResultadoAccion_TotalAntes default 0,
  TotalDespues int not null constraint DF_ResultadoAccion_TotalDespues default 0,
  Delta int not null constraint DF_ResultadoAccion_Delta default 0,
  Recompensa decimal(10,4) not null constraint DF_ResultadoAccion_Recompensa default 0,
  Observacion varchar(500) null,
  constraint PK_ResultadoAccion primary key (IdResultadoAccion),
  constraint FK_ResultadoAccion_AccionRecomendada foreign key (IdAccionRecomendada)
    references AccionRecomendada (IdAccionRecomendada)
);
go

create index IX_ResultadoAccion_Accion
on ResultadoAccion (IdAccionRecomendada, FechaResultado);
go

create table PoliticaAprendida (
  IdPoliticaAprendida bigint identity(1,1) not null,
  Tienda varchar(32) not null,
  Ciudad varchar(64) not null,
  TipoEstado varchar(32) not null,
  ClaveEstado varchar(128) not null,
  TipoAccion varchar(32) not null,
  ValorAprendido decimal(18,6) not null constraint DF_PoliticaAprendida_Valor default 0,
  VecesProbado int not null constraint DF_PoliticaAprendida_VecesProbado default 0,
  RecompensaPromedio decimal(18,6) not null constraint DF_PoliticaAprendida_RecompensaPromedio default 0,
  UltimaActualizacion datetime not null constraint DF_PoliticaAprendida_UltimaActualizacion default getdate(),
  Activo bit not null constraint DF_PoliticaAprendida_Activo default 1,
  constraint PK_PoliticaAprendida primary key (IdPoliticaAprendida)
);
go

create unique index UX_PoliticaAprendida_Estado_Accion
on PoliticaAprendida (Tienda, Ciudad, TipoEstado, ClaveEstado, TipoAccion);
go
