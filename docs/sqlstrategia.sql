/*==============================================================*/
/* DBMS name:      Microsoft SQL Server 2008                    */
/* Created on:     6/11/2026 10:09:31 PM                        */
/*==============================================================*/


if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('dbo.ResultadoAccion') and o.name = 'FK_ResultadoAccion_AccionRecomendada')
alter table dbo.ResultadoAccion
   drop constraint FK_ResultadoAccion_AccionRecomendada
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('dbo.Visita') and o.name = 'FK_Visita_Ciudadano')
alter table dbo.Visita
   drop constraint FK_Visita_Ciudadano
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('dbo.VisitaIntencionVoto') and o.name = 'FK_VisitaIntencionVoto_Visita')
alter table dbo.VisitaIntencionVoto
   drop constraint FK_VisitaIntencionVoto_Visita
go

if exists (select 1
            from  sysindexes
           where  id    = object_id('dbo.AccionRecomendada')
            and   name  = 'IX_AccionRecomendada_Estado'
            and   indid > 0
            and   indid < 255)
   drop index dbo.AccionRecomendada.IX_AccionRecomendada_Estado
go

if exists (select 1
            from  sysobjects
           where  id = object_id('dbo.AccionRecomendada')
            and   type = 'U')
   drop table dbo.AccionRecomendada
go

if exists (select 1
            from  sysindexes
           where  id    = object_id('dbo.Centuria')
            and   name  = 'UX_Centuria_Codigo'
            and   indid > 0
            and   indid < 255)
   drop index dbo.Centuria.UX_Centuria_Codigo
go

if exists (select 1
            from  sysobjects
           where  id = object_id('dbo.Centuria')
            and   type = 'U')
   drop table dbo.Centuria
go

if exists (select 1
            from  sysindexes
           where  id    = object_id('dbo.Ciudadano')
            and   name  = 'IX_Ciudadano_Ubicacion'
            and   indid > 0
            and   indid < 255)
   drop index dbo.Ciudadano.IX_Ciudadano_Ubicacion
go

if exists (select 1
            from  sysindexes
           where  id    = object_id('dbo.Ciudadano')
            and   name  = 'UX_Ciudadano_Ciudad_NumeroCelular'
            and   indid > 0
            and   indid < 255)
   drop index dbo.Ciudadano.UX_Ciudadano_Ciudad_NumeroCelular
go

if exists (select 1
            from  sysobjects
           where  id = object_id('dbo.Ciudadano')
            and   type = 'U')
   drop table dbo.Ciudadano
go

if exists (select 1
            from  sysindexes
           where  id    = object_id('dbo.DashboardContador')
            and   name  = 'UX_DashboardContador_Corte'
            and   indid > 0
            and   indid < 255)
   drop index dbo.DashboardContador.UX_DashboardContador_Corte
go

if exists (select 1
            from  sysobjects
           where  id = object_id('dbo.DashboardContador')
            and   type = 'U')
   drop table dbo.DashboardContador
go

if exists (select 1
            from  sysindexes
           where  id    = object_id('dbo.IntencionVotoOpcion')
            and   name  = 'IX_IntencionVotoOpcion_Dignidad'
            and   indid > 0
            and   indid < 255)
   drop index dbo.IntencionVotoOpcion.IX_IntencionVotoOpcion_Dignidad
go

if exists (select 1
            from  sysindexes
           where  id    = object_id('dbo.IntencionVotoOpcion')
            and   name  = 'UX_IntencionVotoOpcion_Codigo'
            and   indid > 0
            and   indid < 255)
   drop index dbo.IntencionVotoOpcion.UX_IntencionVotoOpcion_Codigo
go

if exists (select 1
            from  sysobjects
           where  id = object_id('dbo.IntencionVotoOpcion')
            and   type = 'U')
   drop table dbo.IntencionVotoOpcion
go

if exists (select 1
            from  sysindexes
           where  id    = object_id('dbo.PoliticaAprendida')
            and   name  = 'UX_PoliticaAprendida_Estado_Accion'
            and   indid > 0
            and   indid < 255)
   drop index dbo.PoliticaAprendida.UX_PoliticaAprendida_Estado_Accion
go

if exists (select 1
            from  sysobjects
           where  id = object_id('dbo.PoliticaAprendida')
            and   type = 'U')
   drop table dbo.PoliticaAprendida
go

if exists (select 1
            from  sysindexes
           where  id    = object_id('dbo.ReporteOrganizacional')
            and   name  = 'IX_ReporteOrganizacional_Usuario_Fecha'
            and   indid > 0
            and   indid < 255)
   drop index dbo.ReporteOrganizacional.IX_ReporteOrganizacional_Usuario_Fecha
go

if exists (select 1
            from  sysindexes
           where  id    = object_id('dbo.ReporteOrganizacional')
            and   name  = 'UX_ReporteOrganizacional_Corte'
            and   indid > 0
            and   indid < 255)
   drop index dbo.ReporteOrganizacional.UX_ReporteOrganizacional_Corte
go

if exists (select 1
            from  sysindexes
           where  id    = object_id('dbo.ReporteOrganizacional')
            and   name  = 'UX_ReporteOrganizacional_Codigo'
            and   indid > 0
            and   indid < 255)
   drop index dbo.ReporteOrganizacional.UX_ReporteOrganizacional_Codigo
go

if exists (select 1
            from  sysobjects
           where  id = object_id('dbo.ReporteOrganizacional')
            and   type = 'U')
   drop table dbo.ReporteOrganizacional
go

if exists (select 1
            from  sysindexes
           where  id    = object_id('dbo.ResultadoAccion')
            and   name  = 'IX_ResultadoAccion_Accion'
            and   indid > 0
            and   indid < 255)
   drop index dbo.ResultadoAccion.IX_ResultadoAccion_Accion
go

if exists (select 1
            from  sysobjects
           where  id = object_id('dbo.ResultadoAccion')
            and   type = 'U')
   drop table dbo.ResultadoAccion
go

if exists (select 1
            from  sysindexes
           where  id    = object_id('dbo.RolOrganizacional')
            and   name  = 'UX_RolOrganizacional'
            and   indid > 0
            and   indid < 255)
   drop index dbo.RolOrganizacional.UX_RolOrganizacional
go

if exists (select 1
            from  sysobjects
           where  id = object_id('dbo.RolOrganizacional')
            and   type = 'U')
   drop table dbo.RolOrganizacional
go

if exists (select 1
            from  sysindexes
           where  id    = object_id('dbo.Territorio')
            and   name  = 'IX_Territorio_Centuria'
            and   indid > 0
            and   indid < 255)
   drop index dbo.Territorio.IX_Territorio_Centuria
go

if exists (select 1
            from  sysindexes
           where  id    = object_id('dbo.Territorio')
            and   name  = 'UX_Territorio_Codigo'
            and   indid > 0
            and   indid < 255)
   drop index dbo.Territorio.UX_Territorio_Codigo
go

if exists (select 1
            from  sysobjects
           where  id = object_id('dbo.Territorio')
            and   type = 'U')
   drop table dbo.Territorio
go

if exists (select 1
            from  sysindexes
           where  id    = object_id('dbo.UsuarioOrganizacional')
            and   name  = 'IX_UsuarioOrganizacional_Rol_Centuria'
            and   indid > 0
            and   indid < 255)
   drop index dbo.UsuarioOrganizacional.IX_UsuarioOrganizacional_Rol_Centuria
go

if exists (select 1
            from  sysindexes
           where  id    = object_id('dbo.UsuarioOrganizacional')
            and   name  = 'UX_UsuarioOrganizacional_Codigo'
            and   indid > 0
            and   indid < 255)
   drop index dbo.UsuarioOrganizacional.UX_UsuarioOrganizacional_Codigo
go

if exists (select 1
            from  sysobjects
           where  id = object_id('dbo.UsuarioOrganizacional')
            and   type = 'U')
   drop table dbo.UsuarioOrganizacional
go

if exists (select 1
            from  sysindexes
           where  id    = object_id('dbo.Visita')
            and   name  = 'IX_Visita_Territorio_Fecha'
            and   indid > 0
            and   indid < 255)
   drop index dbo.Visita.IX_Visita_Territorio_Fecha
go

if exists (select 1
            from  sysindexes
           where  id    = object_id('dbo.Visita')
            and   name  = 'IX_Visita_Ciudadano_Fecha'
            and   indid > 0
            and   indid < 255)
   drop index dbo.Visita.IX_Visita_Ciudadano_Fecha
go

if exists (select 1
            from  sysobjects
           where  id = object_id('dbo.Visita')
            and   type = 'U')
   drop table dbo.Visita
go

if exists (select 1
            from  sysindexes
           where  id    = object_id('dbo.VisitaIntencionVoto')
            and   name  = 'IX_VisitaIntencionVoto_Opcion'
            and   indid > 0
            and   indid < 255)
   drop index dbo.VisitaIntencionVoto.IX_VisitaIntencionVoto_Opcion
go

if exists (select 1
            from  sysindexes
           where  id    = object_id('dbo.VisitaIntencionVoto')
            and   name  = 'UX_VisitaIntencionVoto_Visita_Dignidad'
            and   indid > 0
            and   indid < 255)
   drop index dbo.VisitaIntencionVoto.UX_VisitaIntencionVoto_Visita_Dignidad
go

if exists (select 1
            from  sysobjects
           where  id = object_id('dbo.VisitaIntencionVoto')
            and   type = 'U')
   drop table dbo.VisitaIntencionVoto
go

drop schema dbo
go

/*==============================================================*/
/* User: dbo                                                    */
/*==============================================================*/
create schema dbo
go

/*==============================================================*/
/* Table: AccionRecomendada                                     */
/*==============================================================*/
create table dbo.AccionRecomendada (
   IdAccionRecomendada  int                  identity(1,1),
   Tienda               varchar(32)          not null,
   Ciudad               varchar(64)          not null,
   FechaGeneracion      datetime             not null constraint DF_AccionRecomendada_FechaGeneracion default getdate(),
   TipoAccion           varchar(32)          not null,
   CodigoCenturia       varchar(32)          null,
   CodigoTerritorio     varchar(32)          null,
   CodigoDignidad       varchar(32)          null,
   CodigoIntencionVotoOpcion varchar(32)          null,
   Titulo               varchar(128)         not null,
   Motivo               varchar(500)         null,
   Score                decimal(10,4)        not null constraint DF_AccionRecomendada_Score default 0,
   Estado               varchar(32)          not null constraint DF_AccionRecomendada_Estado default 'PENDIENTE',
   FechaCreacion        datetime             null,
   UsuarioCreacion      varchar(32)          null,
   OficinaCreacion      int                  null,
   EstacionCreacion     varchar(32)          null,
   FechaModificacion    datetime             null,
   UsuarioModificacion  varchar(32)          null,
   OficinaModificacion  int                  null,
   EstacionModificacion varchar(32)          null,
   constraint PK_AccionRecomendada primary key (IdAccionRecomendada)
)
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('dbo.AccionRecomendada')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'FechaCreacion')
)
begin
   execute sp_dropextendedproperty 'MS_Description', 
   'user', 'dbo', 'table', 'AccionRecomendada', 'column', 'FechaCreacion'

end


execute sp_addextendedproperty 'MS_Description', 
   'Fecha de Creación',
   'user', 'dbo', 'table', 'AccionRecomendada', 'column', 'FechaCreacion'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('dbo.AccionRecomendada')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'UsuarioCreacion')
)
begin
   execute sp_dropextendedproperty 'MS_Description', 
   'user', 'dbo', 'table', 'AccionRecomendada', 'column', 'UsuarioCreacion'

end


execute sp_addextendedproperty 'MS_Description', 
   'Usuario de Creación',
   'user', 'dbo', 'table', 'AccionRecomendada', 'column', 'UsuarioCreacion'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('dbo.AccionRecomendada')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'OficinaCreacion')
)
begin
   execute sp_dropextendedproperty 'MS_Description', 
   'user', 'dbo', 'table', 'AccionRecomendada', 'column', 'OficinaCreacion'

end


execute sp_addextendedproperty 'MS_Description', 
   'Oficina de Creación',
   'user', 'dbo', 'table', 'AccionRecomendada', 'column', 'OficinaCreacion'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('dbo.AccionRecomendada')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'EstacionCreacion')
)
begin
   execute sp_dropextendedproperty 'MS_Description', 
   'user', 'dbo', 'table', 'AccionRecomendada', 'column', 'EstacionCreacion'

end


execute sp_addextendedproperty 'MS_Description', 
   'Estacion Creacion',
   'user', 'dbo', 'table', 'AccionRecomendada', 'column', 'EstacionCreacion'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('dbo.AccionRecomendada')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'FechaModificacion')
)
begin
   execute sp_dropextendedproperty 'MS_Description', 
   'user', 'dbo', 'table', 'AccionRecomendada', 'column', 'FechaModificacion'

end


execute sp_addextendedproperty 'MS_Description', 
   'Fecha de Actualización',
   'user', 'dbo', 'table', 'AccionRecomendada', 'column', 'FechaModificacion'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('dbo.AccionRecomendada')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'UsuarioModificacion')
)
begin
   execute sp_dropextendedproperty 'MS_Description', 
   'user', 'dbo', 'table', 'AccionRecomendada', 'column', 'UsuarioModificacion'

end


execute sp_addextendedproperty 'MS_Description', 
   'Usuario de Actualización',
   'user', 'dbo', 'table', 'AccionRecomendada', 'column', 'UsuarioModificacion'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('dbo.AccionRecomendada')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'OficinaModificacion')
)
begin
   execute sp_dropextendedproperty 'MS_Description', 
   'user', 'dbo', 'table', 'AccionRecomendada', 'column', 'OficinaModificacion'

end


execute sp_addextendedproperty 'MS_Description', 
   'Oficina de Actualización',
   'user', 'dbo', 'table', 'AccionRecomendada', 'column', 'OficinaModificacion'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('dbo.AccionRecomendada')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'EstacionModificacion')
)
begin
   execute sp_dropextendedproperty 'MS_Description', 
   'user', 'dbo', 'table', 'AccionRecomendada', 'column', 'EstacionModificacion'

end


execute sp_addextendedproperty 'MS_Description', 
   'Estacion Creacion',
   'user', 'dbo', 'table', 'AccionRecomendada', 'column', 'EstacionModificacion'
go

/*==============================================================*/
/* Index: IX_AccionRecomendada_Estado                           */
/*==============================================================*/
create index IX_AccionRecomendada_Estado on dbo.AccionRecomendada (
Tienda ASC,
Ciudad ASC,
Estado ASC,
FechaGeneracion ASC
)
go

/*==============================================================*/
/* Table: Centuria                                              */
/*==============================================================*/
create table dbo.Centuria (
   IdCenturia           int                  identity(1,1),
   Tienda               varchar(32)          not null,
   Ciudad               varchar(64)          not null,
   CodigoCenturia       varchar(32)          not null,
   NombreCenturia       varchar(128)         not null,
   ParroquiaPrincipal   varchar(128)         not null,
   Descripcion          varchar(300)         null,
   MetaContactosSemana  int                  not null constraint DF_Centuria_MetaContactosSemana default 0,
   Activo               bit                  not null constraint DF_Centuria_Activo default 1,
   FechaCreacion        datetime             null,
   UsuarioCreacion      varchar(32)          null,
   OficinaCreacion      int                  null,
   EstacionCreacion     varchar(32)          null,
   FechaModificacion    datetime             null,
   UsuarioModificacion  varchar(32)          null,
   OficinaModificacion  int                  null,
   EstacionModificacion varchar(32)          null,
   constraint PK_Centuria primary key (IdCenturia)
)
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('dbo.Centuria')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'FechaCreacion')
)
begin
   execute sp_dropextendedproperty 'MS_Description', 
   'user', 'dbo', 'table', 'Centuria', 'column', 'FechaCreacion'

end


execute sp_addextendedproperty 'MS_Description', 
   'Fecha de Creación',
   'user', 'dbo', 'table', 'Centuria', 'column', 'FechaCreacion'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('dbo.Centuria')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'UsuarioCreacion')
)
begin
   execute sp_dropextendedproperty 'MS_Description', 
   'user', 'dbo', 'table', 'Centuria', 'column', 'UsuarioCreacion'

end


execute sp_addextendedproperty 'MS_Description', 
   'Usuario de Creación',
   'user', 'dbo', 'table', 'Centuria', 'column', 'UsuarioCreacion'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('dbo.Centuria')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'OficinaCreacion')
)
begin
   execute sp_dropextendedproperty 'MS_Description', 
   'user', 'dbo', 'table', 'Centuria', 'column', 'OficinaCreacion'

end


execute sp_addextendedproperty 'MS_Description', 
   'Oficina de Creación',
   'user', 'dbo', 'table', 'Centuria', 'column', 'OficinaCreacion'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('dbo.Centuria')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'EstacionCreacion')
)
begin
   execute sp_dropextendedproperty 'MS_Description', 
   'user', 'dbo', 'table', 'Centuria', 'column', 'EstacionCreacion'

end


execute sp_addextendedproperty 'MS_Description', 
   'Estacion Creacion',
   'user', 'dbo', 'table', 'Centuria', 'column', 'EstacionCreacion'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('dbo.Centuria')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'FechaModificacion')
)
begin
   execute sp_dropextendedproperty 'MS_Description', 
   'user', 'dbo', 'table', 'Centuria', 'column', 'FechaModificacion'

end


execute sp_addextendedproperty 'MS_Description', 
   'Fecha de Actualización',
   'user', 'dbo', 'table', 'Centuria', 'column', 'FechaModificacion'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('dbo.Centuria')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'UsuarioModificacion')
)
begin
   execute sp_dropextendedproperty 'MS_Description', 
   'user', 'dbo', 'table', 'Centuria', 'column', 'UsuarioModificacion'

end


execute sp_addextendedproperty 'MS_Description', 
   'Usuario de Actualización',
   'user', 'dbo', 'table', 'Centuria', 'column', 'UsuarioModificacion'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('dbo.Centuria')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'OficinaModificacion')
)
begin
   execute sp_dropextendedproperty 'MS_Description', 
   'user', 'dbo', 'table', 'Centuria', 'column', 'OficinaModificacion'

end


execute sp_addextendedproperty 'MS_Description', 
   'Oficina de Actualización',
   'user', 'dbo', 'table', 'Centuria', 'column', 'OficinaModificacion'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('dbo.Centuria')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'EstacionModificacion')
)
begin
   execute sp_dropextendedproperty 'MS_Description', 
   'user', 'dbo', 'table', 'Centuria', 'column', 'EstacionModificacion'

end


execute sp_addextendedproperty 'MS_Description', 
   'Estacion Creacion',
   'user', 'dbo', 'table', 'Centuria', 'column', 'EstacionModificacion'
go

/*==============================================================*/
/* Index: UX_Centuria_Codigo                                    */
/*==============================================================*/
create unique index UX_Centuria_Codigo on dbo.Centuria (
Tienda ASC,
Ciudad ASC,
CodigoCenturia ASC
)
go

/*==============================================================*/
/* Table: Ciudadano                                             */
/*==============================================================*/
create table dbo.Ciudadano (
   IdCiudadano          int                  identity(1,1),
   Tienda               varchar(32)          not null,
   Ciudad               varchar(64)          not null constraint DF_Ciudadano_Ciudad default 'PEDERNALES',
   CodigoCenturia       varchar(32)          null,
   CodigoTerritorio     varchar(32)          null,
   Codigo               varchar(32)          not null,
   Nombres              varchar(128)         not null,
   Apellidos            varchar(128)         null,
   NumeroCelular        varchar(16)          not null,
   Genero               varchar(32)          not null,
   MiembrosFamilia      int                  not null constraint DF_Ciudadano_MiembrosFamilia default 0,
   MiembrosVotan        int                  not null constraint DF_Ciudadano_MiembrosVotan default 0,
   MiembrosDiscapacidad int                  not null constraint DF_Ciudadano_MiembrosDiscapacidad default 0,
   Parroquia            varchar(128)         not null,
   Barrio               varchar(128)         not null,
   Direccion            varchar(300)         not null,
   PosX                 decimal(18,10)       null,
   PosY                 decimal(18,10)       null,
   Activo               bit                  not null constraint DF_Ciudadano_Activo default 1,
   FechaCreacion        datetime             null,
   UsuarioCreacion      varchar(32)          null,
   OficinaCreacion      int                  null,
   EstacionCreacion     varchar(32)          null,
   FechaModificacion    datetime             null,
   UsuarioModificacion  varchar(32)          null,
   OficinaModificacion  int                  null,
   EstacionModificacion varchar(32)          null,
   constraint PK_Ciudadano primary key (IdCiudadano)
)
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('dbo.Ciudadano')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'FechaCreacion')
)
begin
   execute sp_dropextendedproperty 'MS_Description', 
   'user', 'dbo', 'table', 'Ciudadano', 'column', 'FechaCreacion'

end


execute sp_addextendedproperty 'MS_Description', 
   'Fecha de Creación',
   'user', 'dbo', 'table', 'Ciudadano', 'column', 'FechaCreacion'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('dbo.Ciudadano')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'UsuarioCreacion')
)
begin
   execute sp_dropextendedproperty 'MS_Description', 
   'user', 'dbo', 'table', 'Ciudadano', 'column', 'UsuarioCreacion'

end


execute sp_addextendedproperty 'MS_Description', 
   'Usuario de Creación',
   'user', 'dbo', 'table', 'Ciudadano', 'column', 'UsuarioCreacion'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('dbo.Ciudadano')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'OficinaCreacion')
)
begin
   execute sp_dropextendedproperty 'MS_Description', 
   'user', 'dbo', 'table', 'Ciudadano', 'column', 'OficinaCreacion'

end


execute sp_addextendedproperty 'MS_Description', 
   'Oficina de Creación',
   'user', 'dbo', 'table', 'Ciudadano', 'column', 'OficinaCreacion'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('dbo.Ciudadano')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'EstacionCreacion')
)
begin
   execute sp_dropextendedproperty 'MS_Description', 
   'user', 'dbo', 'table', 'Ciudadano', 'column', 'EstacionCreacion'

end


execute sp_addextendedproperty 'MS_Description', 
   'Estacion Creacion',
   'user', 'dbo', 'table', 'Ciudadano', 'column', 'EstacionCreacion'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('dbo.Ciudadano')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'FechaModificacion')
)
begin
   execute sp_dropextendedproperty 'MS_Description', 
   'user', 'dbo', 'table', 'Ciudadano', 'column', 'FechaModificacion'

end


execute sp_addextendedproperty 'MS_Description', 
   'Fecha de Actualización',
   'user', 'dbo', 'table', 'Ciudadano', 'column', 'FechaModificacion'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('dbo.Ciudadano')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'UsuarioModificacion')
)
begin
   execute sp_dropextendedproperty 'MS_Description', 
   'user', 'dbo', 'table', 'Ciudadano', 'column', 'UsuarioModificacion'

end


execute sp_addextendedproperty 'MS_Description', 
   'Usuario de Actualización',
   'user', 'dbo', 'table', 'Ciudadano', 'column', 'UsuarioModificacion'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('dbo.Ciudadano')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'OficinaModificacion')
)
begin
   execute sp_dropextendedproperty 'MS_Description', 
   'user', 'dbo', 'table', 'Ciudadano', 'column', 'OficinaModificacion'

end


execute sp_addextendedproperty 'MS_Description', 
   'Oficina de Actualización',
   'user', 'dbo', 'table', 'Ciudadano', 'column', 'OficinaModificacion'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('dbo.Ciudadano')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'EstacionModificacion')
)
begin
   execute sp_dropextendedproperty 'MS_Description', 
   'user', 'dbo', 'table', 'Ciudadano', 'column', 'EstacionModificacion'

end


execute sp_addextendedproperty 'MS_Description', 
   'Estacion Creacion',
   'user', 'dbo', 'table', 'Ciudadano', 'column', 'EstacionModificacion'
go

/*==============================================================*/
/* Index: UX_Ciudadano_Ciudad_NumeroCelular                     */
/*==============================================================*/
create unique index UX_Ciudadano_Ciudad_NumeroCelular on dbo.Ciudadano (
Tienda ASC,
Ciudad ASC,
Codigo ASC
)
where Activo = 1
go

/*==============================================================*/
/* Index: IX_Ciudadano_Ubicacion                                */
/*==============================================================*/
create index IX_Ciudadano_Ubicacion on dbo.Ciudadano (
Tienda ASC,
Ciudad ASC,
CodigoCenturia ASC,
CodigoTerritorio ASC,
Parroquia ASC,
Barrio ASC
)
go

/*==============================================================*/
/* Table: DashboardContador                                     */
/*==============================================================*/
create table dbo.DashboardContador (
   IdDashboardContador  int                  identity(1,1),
   Tienda               varchar(32)          not null,
   Ciudad               varchar(64)          not null,
   TipoCorte            varchar(32)          not null,
   FechaInicio          date                 not null,
   FechaFin             date                 not null,
   CodigoCenturia       varchar(32)          not null constraint DF_DashboardContador_Centuria default 'TODAS',
   CodigoTerritorio     varchar(32)          not null constraint DF_DashboardContador_Territorio default 'TODOS',
   Parroquia            varchar(128)         not null constraint DF_DashboardContador_Parroquia default 'TODAS',
   Barrio               varchar(128)         not null constraint DF_DashboardContador_Barrio default 'TODOS',
   TipoContador         varchar(32)          not null,
   CodigoDignidad       varchar(32)          not null constraint DF_DashboardContador_Dignidad default 'TODAS',
   CodigoIntencionVotoOpcion varchar(32)          not null constraint DF_DashboardContador_Intencion default 'TODAS',
   Total                int                  not null constraint DF_DashboardContador_Total default 0,
   FechaCreacion        datetime             null,
   UsuarioCreacion      varchar(32)          null,
   OficinaCreacion      int                  null,
   EstacionCreacion     varchar(32)          null,
   FechaModificacion    datetime             null,
   UsuarioModificacion  varchar(32)          null,
   OficinaModificacion  int                  null,
   EstacionModificacion varchar(32)          null,
   constraint PK_DashboardContador primary key (IdDashboardContador)
)
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('dbo.DashboardContador')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'FechaCreacion')
)
begin
   execute sp_dropextendedproperty 'MS_Description', 
   'user', 'dbo', 'table', 'DashboardContador', 'column', 'FechaCreacion'

end


execute sp_addextendedproperty 'MS_Description', 
   'Fecha de Creación',
   'user', 'dbo', 'table', 'DashboardContador', 'column', 'FechaCreacion'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('dbo.DashboardContador')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'UsuarioCreacion')
)
begin
   execute sp_dropextendedproperty 'MS_Description', 
   'user', 'dbo', 'table', 'DashboardContador', 'column', 'UsuarioCreacion'

end


execute sp_addextendedproperty 'MS_Description', 
   'Usuario de Creación',
   'user', 'dbo', 'table', 'DashboardContador', 'column', 'UsuarioCreacion'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('dbo.DashboardContador')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'OficinaCreacion')
)
begin
   execute sp_dropextendedproperty 'MS_Description', 
   'user', 'dbo', 'table', 'DashboardContador', 'column', 'OficinaCreacion'

end


execute sp_addextendedproperty 'MS_Description', 
   'Oficina de Creación',
   'user', 'dbo', 'table', 'DashboardContador', 'column', 'OficinaCreacion'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('dbo.DashboardContador')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'EstacionCreacion')
)
begin
   execute sp_dropextendedproperty 'MS_Description', 
   'user', 'dbo', 'table', 'DashboardContador', 'column', 'EstacionCreacion'

end


execute sp_addextendedproperty 'MS_Description', 
   'Estacion Creacion',
   'user', 'dbo', 'table', 'DashboardContador', 'column', 'EstacionCreacion'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('dbo.DashboardContador')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'FechaModificacion')
)
begin
   execute sp_dropextendedproperty 'MS_Description', 
   'user', 'dbo', 'table', 'DashboardContador', 'column', 'FechaModificacion'

end


execute sp_addextendedproperty 'MS_Description', 
   'Fecha de Actualización',
   'user', 'dbo', 'table', 'DashboardContador', 'column', 'FechaModificacion'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('dbo.DashboardContador')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'UsuarioModificacion')
)
begin
   execute sp_dropextendedproperty 'MS_Description', 
   'user', 'dbo', 'table', 'DashboardContador', 'column', 'UsuarioModificacion'

end


execute sp_addextendedproperty 'MS_Description', 
   'Usuario de Actualización',
   'user', 'dbo', 'table', 'DashboardContador', 'column', 'UsuarioModificacion'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('dbo.DashboardContador')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'OficinaModificacion')
)
begin
   execute sp_dropextendedproperty 'MS_Description', 
   'user', 'dbo', 'table', 'DashboardContador', 'column', 'OficinaModificacion'

end


execute sp_addextendedproperty 'MS_Description', 
   'Oficina de Actualización',
   'user', 'dbo', 'table', 'DashboardContador', 'column', 'OficinaModificacion'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('dbo.DashboardContador')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'EstacionModificacion')
)
begin
   execute sp_dropextendedproperty 'MS_Description', 
   'user', 'dbo', 'table', 'DashboardContador', 'column', 'EstacionModificacion'

end


execute sp_addextendedproperty 'MS_Description', 
   'Estacion Creacion',
   'user', 'dbo', 'table', 'DashboardContador', 'column', 'EstacionModificacion'
go

/*==============================================================*/
/* Index: UX_DashboardContador_Corte                            */
/*==============================================================*/
create unique index UX_DashboardContador_Corte on dbo.DashboardContador (
Tienda ASC,
Ciudad ASC,
TipoCorte ASC,
FechaInicio ASC,
FechaFin ASC,
CodigoCenturia ASC,
CodigoTerritorio ASC,
Parroquia ASC,
Barrio ASC,
TipoContador ASC,
CodigoDignidad ASC,
CodigoIntencionVotoOpcion ASC
)
go

/*==============================================================*/
/* Table: IntencionVotoOpcion                                   */
/*==============================================================*/
create table dbo.IntencionVotoOpcion (
   IdIntencionVotoOpcion int                  identity(1,1),
   Tienda               varchar(32)          not null,
   CodigoIntencionVotoOpcion varchar(32)          not null,
   CodigoDignidad       varchar(32)          not null,
   NombreOpcion         varchar(128)         not null,
   Orden                int                  not null constraint DF_IntencionVotoOpcion_Orden default 0,
   Activo               bit                  not null constraint DF_IntencionVotoOpcion_Activo default 1,
   FechaCreacion        datetime             null,
   UsuarioCreacion      varchar(32)          null,
   OficinaCreacion      int                  null,
   EstacionCreacion     varchar(32)          null,
   FechaModificacion    datetime             null,
   UsuarioModificacion  varchar(32)          null,
   OficinaModificacion  int                  null,
   EstacionModificacion varchar(32)          null,
   constraint PK_IntencionVotoOpcion primary key (IdIntencionVotoOpcion)
)
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('dbo.IntencionVotoOpcion')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'FechaCreacion')
)
begin
   execute sp_dropextendedproperty 'MS_Description', 
   'user', 'dbo', 'table', 'IntencionVotoOpcion', 'column', 'FechaCreacion'

end


execute sp_addextendedproperty 'MS_Description', 
   'Fecha de Creación',
   'user', 'dbo', 'table', 'IntencionVotoOpcion', 'column', 'FechaCreacion'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('dbo.IntencionVotoOpcion')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'UsuarioCreacion')
)
begin
   execute sp_dropextendedproperty 'MS_Description', 
   'user', 'dbo', 'table', 'IntencionVotoOpcion', 'column', 'UsuarioCreacion'

end


execute sp_addextendedproperty 'MS_Description', 
   'Usuario de Creación',
   'user', 'dbo', 'table', 'IntencionVotoOpcion', 'column', 'UsuarioCreacion'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('dbo.IntencionVotoOpcion')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'OficinaCreacion')
)
begin
   execute sp_dropextendedproperty 'MS_Description', 
   'user', 'dbo', 'table', 'IntencionVotoOpcion', 'column', 'OficinaCreacion'

end


execute sp_addextendedproperty 'MS_Description', 
   'Oficina de Creación',
   'user', 'dbo', 'table', 'IntencionVotoOpcion', 'column', 'OficinaCreacion'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('dbo.IntencionVotoOpcion')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'EstacionCreacion')
)
begin
   execute sp_dropextendedproperty 'MS_Description', 
   'user', 'dbo', 'table', 'IntencionVotoOpcion', 'column', 'EstacionCreacion'

end


execute sp_addextendedproperty 'MS_Description', 
   'Estacion Creacion',
   'user', 'dbo', 'table', 'IntencionVotoOpcion', 'column', 'EstacionCreacion'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('dbo.IntencionVotoOpcion')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'FechaModificacion')
)
begin
   execute sp_dropextendedproperty 'MS_Description', 
   'user', 'dbo', 'table', 'IntencionVotoOpcion', 'column', 'FechaModificacion'

end


execute sp_addextendedproperty 'MS_Description', 
   'Fecha de Actualización',
   'user', 'dbo', 'table', 'IntencionVotoOpcion', 'column', 'FechaModificacion'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('dbo.IntencionVotoOpcion')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'UsuarioModificacion')
)
begin
   execute sp_dropextendedproperty 'MS_Description', 
   'user', 'dbo', 'table', 'IntencionVotoOpcion', 'column', 'UsuarioModificacion'

end


execute sp_addextendedproperty 'MS_Description', 
   'Usuario de Actualización',
   'user', 'dbo', 'table', 'IntencionVotoOpcion', 'column', 'UsuarioModificacion'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('dbo.IntencionVotoOpcion')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'OficinaModificacion')
)
begin
   execute sp_dropextendedproperty 'MS_Description', 
   'user', 'dbo', 'table', 'IntencionVotoOpcion', 'column', 'OficinaModificacion'

end


execute sp_addextendedproperty 'MS_Description', 
   'Oficina de Actualización',
   'user', 'dbo', 'table', 'IntencionVotoOpcion', 'column', 'OficinaModificacion'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('dbo.IntencionVotoOpcion')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'EstacionModificacion')
)
begin
   execute sp_dropextendedproperty 'MS_Description', 
   'user', 'dbo', 'table', 'IntencionVotoOpcion', 'column', 'EstacionModificacion'

end


execute sp_addextendedproperty 'MS_Description', 
   'Estacion Creacion',
   'user', 'dbo', 'table', 'IntencionVotoOpcion', 'column', 'EstacionModificacion'
go

/*==============================================================*/
/* Index: UX_IntencionVotoOpcion_Codigo                         */
/*==============================================================*/
create unique index UX_IntencionVotoOpcion_Codigo on dbo.IntencionVotoOpcion (
Tienda ASC,
CodigoIntencionVotoOpcion ASC
)
go

/*==============================================================*/
/* Index: IX_IntencionVotoOpcion_Dignidad                       */
/*==============================================================*/
create index IX_IntencionVotoOpcion_Dignidad on dbo.IntencionVotoOpcion (
Tienda ASC,
CodigoDignidad ASC,
Activo ASC,
Orden ASC
)
go

/*==============================================================*/
/* Table: PoliticaAprendida                                     */
/*==============================================================*/
create table dbo.PoliticaAprendida (
   IdPoliticaAprendida  int                  identity(1,1),
   Tienda               varchar(32)          not null,
   Ciudad               varchar(64)          not null,
   TipoEstado           varchar(32)          not null,
   ClaveEstado          varchar(128)         not null,
   TipoAccion           varchar(32)          not null,
   ValorAprendido       decimal(18,6)        not null constraint DF_PoliticaAprendida_Valor default 0,
   VecesProbado         int                  not null constraint DF_PoliticaAprendida_VecesProbado default 0,
   RecompensaPromedio   decimal(18,6)        not null constraint DF_PoliticaAprendida_RecompensaPromedio default 0,
   UltimaActualizacion  datetime             not null constraint DF_PoliticaAprendida_UltimaActualizacion default getdate(),
   Activo               bit                  not null constraint DF_PoliticaAprendida_Activo default 1,
   FechaCreacion        datetime             null,
   UsuarioCreacion      varchar(32)          null,
   OficinaCreacion      int                  null,
   EstacionCreacion     varchar(32)          null,
   FechaModificacion    datetime             null,
   UsuarioModificacion  varchar(32)          null,
   OficinaModificacion  int                  null,
   EstacionModificacion varchar(32)          null,
   constraint PK_PoliticaAprendida primary key (IdPoliticaAprendida)
)
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('dbo.PoliticaAprendida')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'FechaCreacion')
)
begin
   execute sp_dropextendedproperty 'MS_Description', 
   'user', 'dbo', 'table', 'PoliticaAprendida', 'column', 'FechaCreacion'

end


execute sp_addextendedproperty 'MS_Description', 
   'Fecha de Creación',
   'user', 'dbo', 'table', 'PoliticaAprendida', 'column', 'FechaCreacion'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('dbo.PoliticaAprendida')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'UsuarioCreacion')
)
begin
   execute sp_dropextendedproperty 'MS_Description', 
   'user', 'dbo', 'table', 'PoliticaAprendida', 'column', 'UsuarioCreacion'

end


execute sp_addextendedproperty 'MS_Description', 
   'Usuario de Creación',
   'user', 'dbo', 'table', 'PoliticaAprendida', 'column', 'UsuarioCreacion'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('dbo.PoliticaAprendida')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'OficinaCreacion')
)
begin
   execute sp_dropextendedproperty 'MS_Description', 
   'user', 'dbo', 'table', 'PoliticaAprendida', 'column', 'OficinaCreacion'

end


execute sp_addextendedproperty 'MS_Description', 
   'Oficina de Creación',
   'user', 'dbo', 'table', 'PoliticaAprendida', 'column', 'OficinaCreacion'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('dbo.PoliticaAprendida')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'EstacionCreacion')
)
begin
   execute sp_dropextendedproperty 'MS_Description', 
   'user', 'dbo', 'table', 'PoliticaAprendida', 'column', 'EstacionCreacion'

end


execute sp_addextendedproperty 'MS_Description', 
   'Estacion Creacion',
   'user', 'dbo', 'table', 'PoliticaAprendida', 'column', 'EstacionCreacion'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('dbo.PoliticaAprendida')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'FechaModificacion')
)
begin
   execute sp_dropextendedproperty 'MS_Description', 
   'user', 'dbo', 'table', 'PoliticaAprendida', 'column', 'FechaModificacion'

end


execute sp_addextendedproperty 'MS_Description', 
   'Fecha de Actualización',
   'user', 'dbo', 'table', 'PoliticaAprendida', 'column', 'FechaModificacion'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('dbo.PoliticaAprendida')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'UsuarioModificacion')
)
begin
   execute sp_dropextendedproperty 'MS_Description', 
   'user', 'dbo', 'table', 'PoliticaAprendida', 'column', 'UsuarioModificacion'

end


execute sp_addextendedproperty 'MS_Description', 
   'Usuario de Actualización',
   'user', 'dbo', 'table', 'PoliticaAprendida', 'column', 'UsuarioModificacion'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('dbo.PoliticaAprendida')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'OficinaModificacion')
)
begin
   execute sp_dropextendedproperty 'MS_Description', 
   'user', 'dbo', 'table', 'PoliticaAprendida', 'column', 'OficinaModificacion'

end


execute sp_addextendedproperty 'MS_Description', 
   'Oficina de Actualización',
   'user', 'dbo', 'table', 'PoliticaAprendida', 'column', 'OficinaModificacion'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('dbo.PoliticaAprendida')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'EstacionModificacion')
)
begin
   execute sp_dropextendedproperty 'MS_Description', 
   'user', 'dbo', 'table', 'PoliticaAprendida', 'column', 'EstacionModificacion'

end


execute sp_addextendedproperty 'MS_Description', 
   'Estacion Creacion',
   'user', 'dbo', 'table', 'PoliticaAprendida', 'column', 'EstacionModificacion'
go

/*==============================================================*/
/* Index: UX_PoliticaAprendida_Estado_Accion                    */
/*==============================================================*/
create unique index UX_PoliticaAprendida_Estado_Accion on dbo.PoliticaAprendida (
Tienda ASC,
Ciudad ASC,
TipoEstado ASC,
ClaveEstado ASC,
TipoAccion ASC
)
go

/*==============================================================*/
/* Table: ReporteOrganizacional                                 */
/*==============================================================*/
create table dbo.ReporteOrganizacional (
   IdReporteOrganizacional int                  identity(1,1),
   Tienda               varchar(32)          not null,
   Ciudad               varchar(64)          not null,
   CodigoReporte        varchar(32)          not null,
   TipoReporte          varchar(32)          not null,
   CodigoUsuario        varchar(32)          not null,
   CodigoRol            varchar(32)          not null,
   CodigoCenturia       varchar(32)          not null,
   FechaReporte         date                 not null,
   FechaEnvio           datetime             not null constraint DF_ReporteOrganizacional_FechaEnvio default getdate(),
   RelatoresActivos     int                  not null constraint DF_ReporteOrganizacional_RelatoresActivos default 0,
   SoldadosActivos      int                  not null constraint DF_ReporteOrganizacional_SoldadosActivos default 0,
   HorasCampo           decimal(10,2)        not null constraint DF_ReporteOrganizacional_HorasCampo default 0,
   PromovidosCompletos  int                  not null constraint DF_ReporteOrganizacional_PromovidosCompletos default 0,
   PromovidosIncompletos int                  not null constraint DF_ReporteOrganizacional_PromovidosIncompletos default 0,
   ContactosSinDatos    int                  not null constraint DF_ReporteOrganizacional_ContactosSinDatos default 0,
   VAH                  decimal(10,2)        not null constraint DF_ReporteOrganizacional_VAH default 0,
   TendenciaVAH         varchar(32)          null,
   CoberturaPorcentaje  decimal(5,2)         not null constraint DF_ReporteOrganizacional_Cobertura default 0,
   SectoresCompletados  varchar(500)         null,
   SectoresPendientes   varchar(500)         null,
   ZonaPrioritariaManana varchar(128)         null,
   TemperaturaSocial    varchar(32)          null,
   ObjecionFrecuente    varchar(128)         null,
   ActividadAdversario  bit                  not null constraint DF_ReporteOrganizacional_ActividadAdversario default 0,
   Adversario           varchar(128)         null,
   TipoActividadAdversario varchar(32)          null,
   SectorActividadAdversario varchar(128)         null,
   NivelAlerta          varchar(32)          null,
   NecesitaMaterial     bit                  not null constraint DF_ReporteOrganizacional_NecesitaMaterial default 0,
   MaterialSolicitado   varchar(300)         null,
   NecesitaPresupuesto  bit                  not null constraint DF_ReporteOrganizacional_NecesitaPresupuesto default 0,
   MontoPresupuesto     decimal(12,2)        not null constraint DF_ReporteOrganizacional_MontoPresupuesto default 0,
   NecesitaLlamada      bit                  not null constraint DF_ReporteOrganizacional_NecesitaLlamada default 0,
   TemaLlamada          varchar(128)         null,
   Observacion          varchar(500)         null,
   Estado               varchar(32)          not null constraint DF_ReporteOrganizacional_Estado default 'ENVIADO',
   FechaCreacion        datetime             null,
   UsuarioCreacion      varchar(32)          null,
   OficinaCreacion      int                  null,
   EstacionCreacion     varchar(32)          null,
   FechaModificacion    datetime             null,
   UsuarioModificacion  varchar(32)          null,
   OficinaModificacion  int                  null,
   EstacionModificacion varchar(32)          null,
   constraint PK_ReporteOrganizacional primary key (IdReporteOrganizacional)
)
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('dbo.ReporteOrganizacional')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'FechaCreacion')
)
begin
   execute sp_dropextendedproperty 'MS_Description', 
   'user', 'dbo', 'table', 'ReporteOrganizacional', 'column', 'FechaCreacion'

end


execute sp_addextendedproperty 'MS_Description', 
   'Fecha de Creación',
   'user', 'dbo', 'table', 'ReporteOrganizacional', 'column', 'FechaCreacion'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('dbo.ReporteOrganizacional')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'UsuarioCreacion')
)
begin
   execute sp_dropextendedproperty 'MS_Description', 
   'user', 'dbo', 'table', 'ReporteOrganizacional', 'column', 'UsuarioCreacion'

end


execute sp_addextendedproperty 'MS_Description', 
   'Usuario de Creación',
   'user', 'dbo', 'table', 'ReporteOrganizacional', 'column', 'UsuarioCreacion'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('dbo.ReporteOrganizacional')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'OficinaCreacion')
)
begin
   execute sp_dropextendedproperty 'MS_Description', 
   'user', 'dbo', 'table', 'ReporteOrganizacional', 'column', 'OficinaCreacion'

end


execute sp_addextendedproperty 'MS_Description', 
   'Oficina de Creación',
   'user', 'dbo', 'table', 'ReporteOrganizacional', 'column', 'OficinaCreacion'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('dbo.ReporteOrganizacional')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'EstacionCreacion')
)
begin
   execute sp_dropextendedproperty 'MS_Description', 
   'user', 'dbo', 'table', 'ReporteOrganizacional', 'column', 'EstacionCreacion'

end


execute sp_addextendedproperty 'MS_Description', 
   'Estacion Creacion',
   'user', 'dbo', 'table', 'ReporteOrganizacional', 'column', 'EstacionCreacion'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('dbo.ReporteOrganizacional')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'FechaModificacion')
)
begin
   execute sp_dropextendedproperty 'MS_Description', 
   'user', 'dbo', 'table', 'ReporteOrganizacional', 'column', 'FechaModificacion'

end


execute sp_addextendedproperty 'MS_Description', 
   'Fecha de Actualización',
   'user', 'dbo', 'table', 'ReporteOrganizacional', 'column', 'FechaModificacion'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('dbo.ReporteOrganizacional')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'UsuarioModificacion')
)
begin
   execute sp_dropextendedproperty 'MS_Description', 
   'user', 'dbo', 'table', 'ReporteOrganizacional', 'column', 'UsuarioModificacion'

end


execute sp_addextendedproperty 'MS_Description', 
   'Usuario de Actualización',
   'user', 'dbo', 'table', 'ReporteOrganizacional', 'column', 'UsuarioModificacion'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('dbo.ReporteOrganizacional')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'OficinaModificacion')
)
begin
   execute sp_dropextendedproperty 'MS_Description', 
   'user', 'dbo', 'table', 'ReporteOrganizacional', 'column', 'OficinaModificacion'

end


execute sp_addextendedproperty 'MS_Description', 
   'Oficina de Actualización',
   'user', 'dbo', 'table', 'ReporteOrganizacional', 'column', 'OficinaModificacion'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('dbo.ReporteOrganizacional')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'EstacionModificacion')
)
begin
   execute sp_dropextendedproperty 'MS_Description', 
   'user', 'dbo', 'table', 'ReporteOrganizacional', 'column', 'EstacionModificacion'

end


execute sp_addextendedproperty 'MS_Description', 
   'Estacion Creacion',
   'user', 'dbo', 'table', 'ReporteOrganizacional', 'column', 'EstacionModificacion'
go

/*==============================================================*/
/* Index: UX_ReporteOrganizacional_Codigo                       */
/*==============================================================*/
create unique index UX_ReporteOrganizacional_Codigo on dbo.ReporteOrganizacional (
Tienda ASC,
CodigoReporte ASC
)
go

/*==============================================================*/
/* Index: UX_ReporteOrganizacional_Corte                        */
/*==============================================================*/
create unique index UX_ReporteOrganizacional_Corte on dbo.ReporteOrganizacional (
Tienda ASC,
Ciudad ASC,
CodigoCenturia ASC,
TipoReporte ASC,
FechaReporte ASC
)
where Estado <> 'ANULADO'
go

/*==============================================================*/
/* Index: IX_ReporteOrganizacional_Usuario_Fecha                */
/*==============================================================*/
create index IX_ReporteOrganizacional_Usuario_Fecha on dbo.ReporteOrganizacional (
Tienda ASC,
CodigoUsuario ASC,
FechaReporte ASC
)
go

/*==============================================================*/
/* Table: ResultadoAccion                                       */
/*==============================================================*/
create table dbo.ResultadoAccion (
   IdResultadoAccion    int                  identity(1,1),
   IdAccionRecomendada  int                  not null,
   FechaResultado       datetime             not null constraint DF_ResultadoAccion_FechaResultado default getdate(),
   TipoMetrica          varchar(32)          not null,
   TotalAntes           int                  not null constraint DF_ResultadoAccion_TotalAntes default 0,
   TotalDespues         int                  not null constraint DF_ResultadoAccion_TotalDespues default 0,
   Delta                int                  not null constraint DF_ResultadoAccion_Delta default 0,
   Recompensa           decimal(10,4)        not null constraint DF_ResultadoAccion_Recompensa default 0,
   Observacion          varchar(500)         null,
   FechaCreacion        datetime             null,
   UsuarioCreacion      varchar(32)          null,
   OficinaCreacion      int                  null,
   EstacionCreacion     varchar(32)          null,
   FechaModificacion    datetime             null,
   UsuarioModificacion  varchar(32)          null,
   OficinaModificacion  int                  null,
   EstacionModificacion varchar(32)          null,
   constraint PK_ResultadoAccion primary key (IdResultadoAccion)
)
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('dbo.ResultadoAccion')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'FechaCreacion')
)
begin
   execute sp_dropextendedproperty 'MS_Description', 
   'user', 'dbo', 'table', 'ResultadoAccion', 'column', 'FechaCreacion'

end


execute sp_addextendedproperty 'MS_Description', 
   'Fecha de Creación',
   'user', 'dbo', 'table', 'ResultadoAccion', 'column', 'FechaCreacion'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('dbo.ResultadoAccion')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'UsuarioCreacion')
)
begin
   execute sp_dropextendedproperty 'MS_Description', 
   'user', 'dbo', 'table', 'ResultadoAccion', 'column', 'UsuarioCreacion'

end


execute sp_addextendedproperty 'MS_Description', 
   'Usuario de Creación',
   'user', 'dbo', 'table', 'ResultadoAccion', 'column', 'UsuarioCreacion'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('dbo.ResultadoAccion')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'OficinaCreacion')
)
begin
   execute sp_dropextendedproperty 'MS_Description', 
   'user', 'dbo', 'table', 'ResultadoAccion', 'column', 'OficinaCreacion'

end


execute sp_addextendedproperty 'MS_Description', 
   'Oficina de Creación',
   'user', 'dbo', 'table', 'ResultadoAccion', 'column', 'OficinaCreacion'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('dbo.ResultadoAccion')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'EstacionCreacion')
)
begin
   execute sp_dropextendedproperty 'MS_Description', 
   'user', 'dbo', 'table', 'ResultadoAccion', 'column', 'EstacionCreacion'

end


execute sp_addextendedproperty 'MS_Description', 
   'Estacion Creacion',
   'user', 'dbo', 'table', 'ResultadoAccion', 'column', 'EstacionCreacion'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('dbo.ResultadoAccion')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'FechaModificacion')
)
begin
   execute sp_dropextendedproperty 'MS_Description', 
   'user', 'dbo', 'table', 'ResultadoAccion', 'column', 'FechaModificacion'

end


execute sp_addextendedproperty 'MS_Description', 
   'Fecha de Actualización',
   'user', 'dbo', 'table', 'ResultadoAccion', 'column', 'FechaModificacion'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('dbo.ResultadoAccion')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'UsuarioModificacion')
)
begin
   execute sp_dropextendedproperty 'MS_Description', 
   'user', 'dbo', 'table', 'ResultadoAccion', 'column', 'UsuarioModificacion'

end


execute sp_addextendedproperty 'MS_Description', 
   'Usuario de Actualización',
   'user', 'dbo', 'table', 'ResultadoAccion', 'column', 'UsuarioModificacion'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('dbo.ResultadoAccion')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'OficinaModificacion')
)
begin
   execute sp_dropextendedproperty 'MS_Description', 
   'user', 'dbo', 'table', 'ResultadoAccion', 'column', 'OficinaModificacion'

end


execute sp_addextendedproperty 'MS_Description', 
   'Oficina de Actualización',
   'user', 'dbo', 'table', 'ResultadoAccion', 'column', 'OficinaModificacion'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('dbo.ResultadoAccion')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'EstacionModificacion')
)
begin
   execute sp_dropextendedproperty 'MS_Description', 
   'user', 'dbo', 'table', 'ResultadoAccion', 'column', 'EstacionModificacion'

end


execute sp_addextendedproperty 'MS_Description', 
   'Estacion Creacion',
   'user', 'dbo', 'table', 'ResultadoAccion', 'column', 'EstacionModificacion'
go

/*==============================================================*/
/* Index: IX_ResultadoAccion_Accion                             */
/*==============================================================*/
create index IX_ResultadoAccion_Accion on dbo.ResultadoAccion (
IdAccionRecomendada ASC,
FechaResultado ASC
)
go

/*==============================================================*/
/* Table: RolOrganizacional                                     */
/*==============================================================*/
create table dbo.RolOrganizacional (
   IdRolOrganizacional  int                  identity(1,1),
   Tienda               varchar(32)          not null,
   CodigoRol            varchar(32)          not null,
   NombreRol            varchar(128)         not null,
   NivelJerarquico      int                  not null constraint DF_RolOrganizacional_NivelJerarquico default 0,
   EsComando            bit                  not null constraint DF_RolOrganizacional_EsComando default 0,
   Activo               bit                  not null constraint DF_RolOrganizacional_Activo default 1,
   FechaCreacion        datetime             null,
   UsuarioCreacion      varchar(32)          null,
   OficinaCreacion      int                  null,
   EstacionCreacion     varchar(32)          null,
   FechaModificacion    datetime             null,
   UsuarioModificacion  varchar(32)          null,
   OficinaModificacion  int                  null,
   EstacionModificacion varchar(32)          null,
   constraint PK_RolOrganizacional primary key (IdRolOrganizacional)
)
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('dbo.RolOrganizacional')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'FechaCreacion')
)
begin
   execute sp_dropextendedproperty 'MS_Description', 
   'user', 'dbo', 'table', 'RolOrganizacional', 'column', 'FechaCreacion'

end


execute sp_addextendedproperty 'MS_Description', 
   'Fecha de Creación',
   'user', 'dbo', 'table', 'RolOrganizacional', 'column', 'FechaCreacion'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('dbo.RolOrganizacional')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'UsuarioCreacion')
)
begin
   execute sp_dropextendedproperty 'MS_Description', 
   'user', 'dbo', 'table', 'RolOrganizacional', 'column', 'UsuarioCreacion'

end


execute sp_addextendedproperty 'MS_Description', 
   'Usuario de Creación',
   'user', 'dbo', 'table', 'RolOrganizacional', 'column', 'UsuarioCreacion'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('dbo.RolOrganizacional')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'OficinaCreacion')
)
begin
   execute sp_dropextendedproperty 'MS_Description', 
   'user', 'dbo', 'table', 'RolOrganizacional', 'column', 'OficinaCreacion'

end


execute sp_addextendedproperty 'MS_Description', 
   'Oficina de Creación',
   'user', 'dbo', 'table', 'RolOrganizacional', 'column', 'OficinaCreacion'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('dbo.RolOrganizacional')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'EstacionCreacion')
)
begin
   execute sp_dropextendedproperty 'MS_Description', 
   'user', 'dbo', 'table', 'RolOrganizacional', 'column', 'EstacionCreacion'

end


execute sp_addextendedproperty 'MS_Description', 
   'Estacion Creacion',
   'user', 'dbo', 'table', 'RolOrganizacional', 'column', 'EstacionCreacion'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('dbo.RolOrganizacional')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'FechaModificacion')
)
begin
   execute sp_dropextendedproperty 'MS_Description', 
   'user', 'dbo', 'table', 'RolOrganizacional', 'column', 'FechaModificacion'

end


execute sp_addextendedproperty 'MS_Description', 
   'Fecha de Actualización',
   'user', 'dbo', 'table', 'RolOrganizacional', 'column', 'FechaModificacion'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('dbo.RolOrganizacional')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'UsuarioModificacion')
)
begin
   execute sp_dropextendedproperty 'MS_Description', 
   'user', 'dbo', 'table', 'RolOrganizacional', 'column', 'UsuarioModificacion'

end


execute sp_addextendedproperty 'MS_Description', 
   'Usuario de Actualización',
   'user', 'dbo', 'table', 'RolOrganizacional', 'column', 'UsuarioModificacion'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('dbo.RolOrganizacional')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'OficinaModificacion')
)
begin
   execute sp_dropextendedproperty 'MS_Description', 
   'user', 'dbo', 'table', 'RolOrganizacional', 'column', 'OficinaModificacion'

end


execute sp_addextendedproperty 'MS_Description', 
   'Oficina de Actualización',
   'user', 'dbo', 'table', 'RolOrganizacional', 'column', 'OficinaModificacion'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('dbo.RolOrganizacional')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'EstacionModificacion')
)
begin
   execute sp_dropextendedproperty 'MS_Description', 
   'user', 'dbo', 'table', 'RolOrganizacional', 'column', 'EstacionModificacion'

end


execute sp_addextendedproperty 'MS_Description', 
   'Estacion Creacion',
   'user', 'dbo', 'table', 'RolOrganizacional', 'column', 'EstacionModificacion'
go

/*==============================================================*/
/* Index: UX_RolOrganizacional                                  */
/*==============================================================*/
create unique index UX_RolOrganizacional on dbo.RolOrganizacional (
Tienda ASC,
CodigoRol ASC
)
go

/*==============================================================*/
/* Table: Territorio                                            */
/*==============================================================*/
create table dbo.Territorio (
   IdTerritorio         int                  identity(1,1),
   Tienda               varchar(32)          not null,
   Ciudad               varchar(64)          not null,
   CodigoTerritorio     varchar(32)          not null,
   CodigoCenturia       varchar(32)          not null,
   TipoTerritorio       varchar(32)          not null,
   NombreTerritorio     varchar(128)         not null,
   Parroquia            varchar(128)         null,
   Barrio               varchar(128)         null,
   EstadoCobertura      varchar(32)          not null constraint DF_Territorio_EstadoCobertura default 'SIN_CONTACTO',
   Activo               bit                  not null constraint DF_Territorio_Activo default 1,
   FechaCreacion        datetime             null,
   UsuarioCreacion      varchar(32)          null,
   OficinaCreacion      int                  null,
   EstacionCreacion     varchar(32)          null,
   FechaModificacion    datetime             null,
   UsuarioModificacion  varchar(32)          null,
   OficinaModificacion  int                  null,
   EstacionModificacion varchar(32)          null,
   constraint PK_Territorio primary key (IdTerritorio)
)
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('dbo.Territorio')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'FechaCreacion')
)
begin
   execute sp_dropextendedproperty 'MS_Description', 
   'user', 'dbo', 'table', 'Territorio', 'column', 'FechaCreacion'

end


execute sp_addextendedproperty 'MS_Description', 
   'Fecha de Creación',
   'user', 'dbo', 'table', 'Territorio', 'column', 'FechaCreacion'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('dbo.Territorio')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'UsuarioCreacion')
)
begin
   execute sp_dropextendedproperty 'MS_Description', 
   'user', 'dbo', 'table', 'Territorio', 'column', 'UsuarioCreacion'

end


execute sp_addextendedproperty 'MS_Description', 
   'Usuario de Creación',
   'user', 'dbo', 'table', 'Territorio', 'column', 'UsuarioCreacion'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('dbo.Territorio')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'OficinaCreacion')
)
begin
   execute sp_dropextendedproperty 'MS_Description', 
   'user', 'dbo', 'table', 'Territorio', 'column', 'OficinaCreacion'

end


execute sp_addextendedproperty 'MS_Description', 
   'Oficina de Creación',
   'user', 'dbo', 'table', 'Territorio', 'column', 'OficinaCreacion'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('dbo.Territorio')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'EstacionCreacion')
)
begin
   execute sp_dropextendedproperty 'MS_Description', 
   'user', 'dbo', 'table', 'Territorio', 'column', 'EstacionCreacion'

end


execute sp_addextendedproperty 'MS_Description', 
   'Estacion Creacion',
   'user', 'dbo', 'table', 'Territorio', 'column', 'EstacionCreacion'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('dbo.Territorio')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'FechaModificacion')
)
begin
   execute sp_dropextendedproperty 'MS_Description', 
   'user', 'dbo', 'table', 'Territorio', 'column', 'FechaModificacion'

end


execute sp_addextendedproperty 'MS_Description', 
   'Fecha de Actualización',
   'user', 'dbo', 'table', 'Territorio', 'column', 'FechaModificacion'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('dbo.Territorio')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'UsuarioModificacion')
)
begin
   execute sp_dropextendedproperty 'MS_Description', 
   'user', 'dbo', 'table', 'Territorio', 'column', 'UsuarioModificacion'

end


execute sp_addextendedproperty 'MS_Description', 
   'Usuario de Actualización',
   'user', 'dbo', 'table', 'Territorio', 'column', 'UsuarioModificacion'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('dbo.Territorio')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'OficinaModificacion')
)
begin
   execute sp_dropextendedproperty 'MS_Description', 
   'user', 'dbo', 'table', 'Territorio', 'column', 'OficinaModificacion'

end


execute sp_addextendedproperty 'MS_Description', 
   'Oficina de Actualización',
   'user', 'dbo', 'table', 'Territorio', 'column', 'OficinaModificacion'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('dbo.Territorio')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'EstacionModificacion')
)
begin
   execute sp_dropextendedproperty 'MS_Description', 
   'user', 'dbo', 'table', 'Territorio', 'column', 'EstacionModificacion'

end


execute sp_addextendedproperty 'MS_Description', 
   'Estacion Creacion',
   'user', 'dbo', 'table', 'Territorio', 'column', 'EstacionModificacion'
go

/*==============================================================*/
/* Index: UX_Territorio_Codigo                                  */
/*==============================================================*/
create unique index UX_Territorio_Codigo on dbo.Territorio (
Tienda ASC,
Ciudad ASC,
CodigoTerritorio ASC
)
go

/*==============================================================*/
/* Index: IX_Territorio_Centuria                                */
/*==============================================================*/
create index IX_Territorio_Centuria on dbo.Territorio (
Tienda ASC,
Ciudad ASC,
CodigoCenturia ASC,
TipoTerritorio ASC,
Parroquia ASC,
Barrio ASC
)
go

/*==============================================================*/
/* Table: UsuarioOrganizacional                                 */
/*==============================================================*/
create table dbo.UsuarioOrganizacional (
   IdUsuarioOrganizacional int                  identity(1,1),
   Tienda               varchar(32)          not null,
   CodigoUsuario        varchar(32)          not null,
   CodigoRol            varchar(32)          not null,
   CodigoCenturia       varchar(32)          null,
   Nombres              varchar(128)         not null,
   Apellidos            varchar(128)         null,
   Telefono             varchar(16)          null,
   UsuarioLogin         varchar(120)         null,
   Activo               bit                  not null constraint DF_UsuarioOrganizacional_Activo default 1,
   FechaCreacion        datetime             null,
   UsuarioCreacion      varchar(32)          null,
   OficinaCreacion      int                  null,
   EstacionCreacion     varchar(32)          null,
   FechaModificacion    datetime             null,
   UsuarioModificacion  varchar(32)          null,
   OficinaModificacion  int                  null,
   EstacionModificacion varchar(32)          null,
   constraint PK_UsuarioOrganizacional primary key (IdUsuarioOrganizacional)
)
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('dbo.UsuarioOrganizacional')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'FechaCreacion')
)
begin
   execute sp_dropextendedproperty 'MS_Description', 
   'user', 'dbo', 'table', 'UsuarioOrganizacional', 'column', 'FechaCreacion'

end


execute sp_addextendedproperty 'MS_Description', 
   'Fecha de Creación',
   'user', 'dbo', 'table', 'UsuarioOrganizacional', 'column', 'FechaCreacion'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('dbo.UsuarioOrganizacional')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'UsuarioCreacion')
)
begin
   execute sp_dropextendedproperty 'MS_Description', 
   'user', 'dbo', 'table', 'UsuarioOrganizacional', 'column', 'UsuarioCreacion'

end


execute sp_addextendedproperty 'MS_Description', 
   'Usuario de Creación',
   'user', 'dbo', 'table', 'UsuarioOrganizacional', 'column', 'UsuarioCreacion'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('dbo.UsuarioOrganizacional')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'OficinaCreacion')
)
begin
   execute sp_dropextendedproperty 'MS_Description', 
   'user', 'dbo', 'table', 'UsuarioOrganizacional', 'column', 'OficinaCreacion'

end


execute sp_addextendedproperty 'MS_Description', 
   'Oficina de Creación',
   'user', 'dbo', 'table', 'UsuarioOrganizacional', 'column', 'OficinaCreacion'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('dbo.UsuarioOrganizacional')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'EstacionCreacion')
)
begin
   execute sp_dropextendedproperty 'MS_Description', 
   'user', 'dbo', 'table', 'UsuarioOrganizacional', 'column', 'EstacionCreacion'

end


execute sp_addextendedproperty 'MS_Description', 
   'Estacion Creacion',
   'user', 'dbo', 'table', 'UsuarioOrganizacional', 'column', 'EstacionCreacion'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('dbo.UsuarioOrganizacional')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'FechaModificacion')
)
begin
   execute sp_dropextendedproperty 'MS_Description', 
   'user', 'dbo', 'table', 'UsuarioOrganizacional', 'column', 'FechaModificacion'

end


execute sp_addextendedproperty 'MS_Description', 
   'Fecha de Actualización',
   'user', 'dbo', 'table', 'UsuarioOrganizacional', 'column', 'FechaModificacion'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('dbo.UsuarioOrganizacional')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'UsuarioModificacion')
)
begin
   execute sp_dropextendedproperty 'MS_Description', 
   'user', 'dbo', 'table', 'UsuarioOrganizacional', 'column', 'UsuarioModificacion'

end


execute sp_addextendedproperty 'MS_Description', 
   'Usuario de Actualización',
   'user', 'dbo', 'table', 'UsuarioOrganizacional', 'column', 'UsuarioModificacion'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('dbo.UsuarioOrganizacional')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'OficinaModificacion')
)
begin
   execute sp_dropextendedproperty 'MS_Description', 
   'user', 'dbo', 'table', 'UsuarioOrganizacional', 'column', 'OficinaModificacion'

end


execute sp_addextendedproperty 'MS_Description', 
   'Oficina de Actualización',
   'user', 'dbo', 'table', 'UsuarioOrganizacional', 'column', 'OficinaModificacion'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('dbo.UsuarioOrganizacional')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'EstacionModificacion')
)
begin
   execute sp_dropextendedproperty 'MS_Description', 
   'user', 'dbo', 'table', 'UsuarioOrganizacional', 'column', 'EstacionModificacion'

end


execute sp_addextendedproperty 'MS_Description', 
   'Estacion Creacion',
   'user', 'dbo', 'table', 'UsuarioOrganizacional', 'column', 'EstacionModificacion'
go

/*==============================================================*/
/* Index: UX_UsuarioOrganizacional_Codigo                       */
/*==============================================================*/
create unique index UX_UsuarioOrganizacional_Codigo on dbo.UsuarioOrganizacional (
Tienda ASC,
CodigoUsuario ASC
)
go

/*==============================================================*/
/* Index: IX_UsuarioOrganizacional_Rol_Centuria                 */
/*==============================================================*/
create index IX_UsuarioOrganizacional_Rol_Centuria on dbo.UsuarioOrganizacional (
Tienda ASC,
CodigoRol ASC,
CodigoCenturia ASC,
Activo ASC
)
go

/*==============================================================*/
/* Table: Visita                                                */
/*==============================================================*/
create table dbo.Visita (
   IdVisita             int                  identity(1,1),
   IdCiudadano          int                  not null,
   Tienda               varchar(32)          not null,
   Ciudad               varchar(64)          not null,
   CodigoUsuario        varchar(32)          null,
   CodigoCenturia       varchar(32)          null,
   CodigoTerritorio     varchar(32)          null,
   FechaVisita          datetime             not null constraint DF_Visita_FechaVisita default getdate(),
   ProblemaTexto        varchar(300)         null,
   TemaInteresReal      varchar(500)         null,
   ReferidoNombres      varchar(128)         null,
   ReferidoTelefono     varchar(16)          null,
   NotaEncuestador      varchar(500)         null,
   PosX                 decimal(18,10)       null,
   PosY                 decimal(18,10)       null,
   EstadoSync           varchar(32)          not null constraint DF_Visita_EstadoSync default 'SINCRONIZADO',
   Activo               bit                  not null constraint DF_Visita_Activo default 1,
   FechaCreacion        datetime             null,
   UsuarioCreacion      varchar(32)          null,
   OficinaCreacion      int                  null,
   EstacionCreacion     varchar(32)          null,
   FechaModificacion    datetime             null,
   UsuarioModificacion  varchar(32)          null,
   OficinaModificacion  int                  null,
   EstacionModificacion varchar(32)          null,
   constraint PK_Visita primary key (IdVisita)
)
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('dbo.Visita')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'FechaCreacion')
)
begin
   execute sp_dropextendedproperty 'MS_Description', 
   'user', 'dbo', 'table', 'Visita', 'column', 'FechaCreacion'

end


execute sp_addextendedproperty 'MS_Description', 
   'Fecha de Creación',
   'user', 'dbo', 'table', 'Visita', 'column', 'FechaCreacion'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('dbo.Visita')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'UsuarioCreacion')
)
begin
   execute sp_dropextendedproperty 'MS_Description', 
   'user', 'dbo', 'table', 'Visita', 'column', 'UsuarioCreacion'

end


execute sp_addextendedproperty 'MS_Description', 
   'Usuario de Creación',
   'user', 'dbo', 'table', 'Visita', 'column', 'UsuarioCreacion'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('dbo.Visita')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'OficinaCreacion')
)
begin
   execute sp_dropextendedproperty 'MS_Description', 
   'user', 'dbo', 'table', 'Visita', 'column', 'OficinaCreacion'

end


execute sp_addextendedproperty 'MS_Description', 
   'Oficina de Creación',
   'user', 'dbo', 'table', 'Visita', 'column', 'OficinaCreacion'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('dbo.Visita')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'EstacionCreacion')
)
begin
   execute sp_dropextendedproperty 'MS_Description', 
   'user', 'dbo', 'table', 'Visita', 'column', 'EstacionCreacion'

end


execute sp_addextendedproperty 'MS_Description', 
   'Estacion Creacion',
   'user', 'dbo', 'table', 'Visita', 'column', 'EstacionCreacion'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('dbo.Visita')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'FechaModificacion')
)
begin
   execute sp_dropextendedproperty 'MS_Description', 
   'user', 'dbo', 'table', 'Visita', 'column', 'FechaModificacion'

end


execute sp_addextendedproperty 'MS_Description', 
   'Fecha de Actualización',
   'user', 'dbo', 'table', 'Visita', 'column', 'FechaModificacion'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('dbo.Visita')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'UsuarioModificacion')
)
begin
   execute sp_dropextendedproperty 'MS_Description', 
   'user', 'dbo', 'table', 'Visita', 'column', 'UsuarioModificacion'

end


execute sp_addextendedproperty 'MS_Description', 
   'Usuario de Actualización',
   'user', 'dbo', 'table', 'Visita', 'column', 'UsuarioModificacion'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('dbo.Visita')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'OficinaModificacion')
)
begin
   execute sp_dropextendedproperty 'MS_Description', 
   'user', 'dbo', 'table', 'Visita', 'column', 'OficinaModificacion'

end


execute sp_addextendedproperty 'MS_Description', 
   'Oficina de Actualización',
   'user', 'dbo', 'table', 'Visita', 'column', 'OficinaModificacion'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('dbo.Visita')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'EstacionModificacion')
)
begin
   execute sp_dropextendedproperty 'MS_Description', 
   'user', 'dbo', 'table', 'Visita', 'column', 'EstacionModificacion'

end


execute sp_addextendedproperty 'MS_Description', 
   'Estacion Creacion',
   'user', 'dbo', 'table', 'Visita', 'column', 'EstacionModificacion'
go

/*==============================================================*/
/* Index: IX_Visita_Ciudadano_Fecha                             */
/*==============================================================*/
create index IX_Visita_Ciudadano_Fecha on dbo.Visita (
IdCiudadano ASC,
FechaVisita ASC
)
go

/*==============================================================*/
/* Index: IX_Visita_Territorio_Fecha                            */
/*==============================================================*/
create index IX_Visita_Territorio_Fecha on dbo.Visita (
Tienda ASC,
Ciudad ASC,
CodigoCenturia ASC,
CodigoTerritorio ASC,
FechaVisita ASC
)
go

/*==============================================================*/
/* Table: VisitaIntencionVoto                                   */
/*==============================================================*/
create table dbo.VisitaIntencionVoto (
   IdVisitaIntencionVoto int                  identity(1,1),
   IdVisita             int                  not null,
   CodigoDignidad       varchar(32)          not null,
   CodigoIntencionVotoOpcion varchar(32)          not null,
   Observacion          varchar(500)         null,
   FechaCreacion        datetime             null,
   UsuarioCreacion      varchar(32)          null,
   OficinaCreacion      int                  null,
   EstacionCreacion     varchar(32)          null,
   FechaModificacion    datetime             null,
   UsuarioModificacion  varchar(32)          null,
   OficinaModificacion  int                  null,
   EstacionModificacion varchar(32)          null,
   constraint PK_VisitaIntencionVoto primary key (IdVisitaIntencionVoto)
)
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('dbo.VisitaIntencionVoto')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'FechaCreacion')
)
begin
   execute sp_dropextendedproperty 'MS_Description', 
   'user', 'dbo', 'table', 'VisitaIntencionVoto', 'column', 'FechaCreacion'

end


execute sp_addextendedproperty 'MS_Description', 
   'Fecha de Creación',
   'user', 'dbo', 'table', 'VisitaIntencionVoto', 'column', 'FechaCreacion'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('dbo.VisitaIntencionVoto')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'UsuarioCreacion')
)
begin
   execute sp_dropextendedproperty 'MS_Description', 
   'user', 'dbo', 'table', 'VisitaIntencionVoto', 'column', 'UsuarioCreacion'

end


execute sp_addextendedproperty 'MS_Description', 
   'Usuario de Creación',
   'user', 'dbo', 'table', 'VisitaIntencionVoto', 'column', 'UsuarioCreacion'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('dbo.VisitaIntencionVoto')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'OficinaCreacion')
)
begin
   execute sp_dropextendedproperty 'MS_Description', 
   'user', 'dbo', 'table', 'VisitaIntencionVoto', 'column', 'OficinaCreacion'

end


execute sp_addextendedproperty 'MS_Description', 
   'Oficina de Creación',
   'user', 'dbo', 'table', 'VisitaIntencionVoto', 'column', 'OficinaCreacion'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('dbo.VisitaIntencionVoto')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'EstacionCreacion')
)
begin
   execute sp_dropextendedproperty 'MS_Description', 
   'user', 'dbo', 'table', 'VisitaIntencionVoto', 'column', 'EstacionCreacion'

end


execute sp_addextendedproperty 'MS_Description', 
   'Estacion Creacion',
   'user', 'dbo', 'table', 'VisitaIntencionVoto', 'column', 'EstacionCreacion'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('dbo.VisitaIntencionVoto')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'FechaModificacion')
)
begin
   execute sp_dropextendedproperty 'MS_Description', 
   'user', 'dbo', 'table', 'VisitaIntencionVoto', 'column', 'FechaModificacion'

end


execute sp_addextendedproperty 'MS_Description', 
   'Fecha de Actualización',
   'user', 'dbo', 'table', 'VisitaIntencionVoto', 'column', 'FechaModificacion'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('dbo.VisitaIntencionVoto')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'UsuarioModificacion')
)
begin
   execute sp_dropextendedproperty 'MS_Description', 
   'user', 'dbo', 'table', 'VisitaIntencionVoto', 'column', 'UsuarioModificacion'

end


execute sp_addextendedproperty 'MS_Description', 
   'Usuario de Actualización',
   'user', 'dbo', 'table', 'VisitaIntencionVoto', 'column', 'UsuarioModificacion'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('dbo.VisitaIntencionVoto')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'OficinaModificacion')
)
begin
   execute sp_dropextendedproperty 'MS_Description', 
   'user', 'dbo', 'table', 'VisitaIntencionVoto', 'column', 'OficinaModificacion'

end


execute sp_addextendedproperty 'MS_Description', 
   'Oficina de Actualización',
   'user', 'dbo', 'table', 'VisitaIntencionVoto', 'column', 'OficinaModificacion'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('dbo.VisitaIntencionVoto')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'EstacionModificacion')
)
begin
   execute sp_dropextendedproperty 'MS_Description', 
   'user', 'dbo', 'table', 'VisitaIntencionVoto', 'column', 'EstacionModificacion'

end


execute sp_addextendedproperty 'MS_Description', 
   'Estacion Creacion',
   'user', 'dbo', 'table', 'VisitaIntencionVoto', 'column', 'EstacionModificacion'
go

/*==============================================================*/
/* Index: UX_VisitaIntencionVoto_Visita_Dignidad                */
/*==============================================================*/
create unique index UX_VisitaIntencionVoto_Visita_Dignidad on dbo.VisitaIntencionVoto (
IdVisita ASC,
CodigoDignidad ASC
)
go

/*==============================================================*/
/* Index: IX_VisitaIntencionVoto_Opcion                         */
/*==============================================================*/
create index IX_VisitaIntencionVoto_Opcion on dbo.VisitaIntencionVoto (
CodigoDignidad ASC,
CodigoIntencionVotoOpcion ASC
)
go

alter table dbo.ResultadoAccion
   add constraint FK_ResultadoAccion_AccionRecomendada foreign key (IdAccionRecomendada)
      references dbo.AccionRecomendada (IdAccionRecomendada)
go

alter table dbo.Visita
   add constraint FK_Visita_Ciudadano foreign key (IdCiudadano)
      references dbo.Ciudadano (IdCiudadano)
go

alter table dbo.VisitaIntencionVoto
   add constraint FK_VisitaIntencionVoto_Visita foreign key (IdVisita)
      references dbo.Visita (IdVisita)
go

