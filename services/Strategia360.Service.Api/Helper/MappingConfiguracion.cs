using AutoMapper;
using DFast.Seguridad.Api.Models;
using DFast.Seguridad.Api.DTOs;
using static DFast.Common.General.CommonAutoMapper;


namespace DFast.Seguridad.Api.Helper
{
    public class MappingConfiguracion :Profile
    {
        public MappingConfiguracion()
        {

            CreateMap<Usuario, UsuarioDto>().ReverseMap();
            CreateMap<UsuarioRol, UsuarioRolDto>().ReverseMap();
            CreateMap<UsuarioSistema, UsuarioSistemaDto>().ReverseMap();
            CreateMap<Menu, MenuDto>().ReverseMap();
            CreateMap<UsuarioSistema, UsuarioSistemaDto>().ReverseMap();
            

            CreateMap<MenuDto, MenuSistemaChildren>()
                .ForMember(dest => dest.subtitle, opts => opts.MapFrom(src => src.SubTitulo))
                .ForMember(dest => dest.label, opts => opts.MapFrom(src => src.Titulo))
                .ForMember(dest => dest.icon, opts => opts.MapFrom(src => src.Icono))
                //.ForMember(dest => dest.id, opts => opts.MapFrom(src => src.Descripcion))
                .ForMember(dest => dest.id, opts => opts.MapFrom(src => src.IdMenu))
                .ForMember(dest => dest.type, opts => opts.MapFrom(src => src.Tipo))
                .ForMember(dest => dest.uri, opts => opts.MapFrom(src => src.Url))

              .ForMember(dest => dest.visible, opts => opts.MapFrom(src => src.Visible))
              .ForMember(dest => dest.orden, opts => opts.MapFrom(src => src.Orden));


            CreateMap<UsuarioDto, UsuarioDtoIng>()
                .ForMember(dest => dest.UserId, opt => opt.MapFrom(src => src.IdUsuario))
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.Key, opt => opt.MapFrom(src => src.Key))
                .ForMember(dest => dest.Email, opt => opt.MapFrom(src => src.Email))
                .ForMember(dest => dest.System, opt => opt.MapFrom(src => src.Sistema))
                .ForMember(dest => dest.Institution, opt => opt.MapFrom(src => src.Institucion))
                .ForMember(dest => dest.Role, opt => opt.MapFrom(src => src.Rol))
                .ForMember(dest => dest.IdentificationType, opt => opt.MapFrom(src => src.TipoIdentificacion))
                .ForMember(dest => dest.Identification, opt => opt.MapFrom(src => src.Identificacion))
                .ForMember(dest => dest.FirstName, opt => opt.MapFrom(src => src.Nombres))
                .ForMember(dest => dest.LastName, opt => opt.MapFrom(src => src.Apellidos))
                .ForMember(dest => dest.Phone1, opt => opt.MapFrom(src => src.Telefono1))
                .ForMember(dest => dest.Phone2, opt => opt.MapFrom(src => src.Telefono2))
                .ForMember(dest => dest.Address, opt => opt.MapFrom(src => src.Direccion))
                .ForMember(dest => dest.IsActive, opt => opt.MapFrom(src => src.Activo))
                .ForMember(dest => dest.GeoLocation2, opt => opt.MapFrom(src => src.UbicacionGeografica2))
                .ForMember(dest => dest.Office, opt => opt.MapFrom(src => src.Oficina))
                .ForMember(dest => dest.CodeOffice, opt => opt.MapFrom(src => src.CcdigoOficina))
                .ForMember(dest => dest.Attempts, opt => opt.MapFrom(src => src.Intentos))
                .ForMember(dest => dest.Station, opt => opt.MapFrom(src => src.Estacion))
                .ForMember(dest => dest.Status, opt => opt.MapFrom(src => src.Estado))
                .ForMember(dest => dest.Token, opt => opt.MapFrom(src => src.Token))
                .ForMember(dest => dest.Imei, opt => opt.MapFrom(src => src.Imei))
                .ForMember(dest => dest.Os, opt => opt.MapFrom(src => src.So))
                .ForMember(dest => dest.Version, opt => opt.MapFrom(src => src.Version))
                .ForMember(dest => dest.DateSytem, opt => opt.MapFrom(_ => DateTime.Now.ToString("yyyy-MM-ddTHH:mm:ss")))

                .ForMember(dest => dest.LastAccessDate, opt => opt.MapFrom(src => src.FechaUltimoAcceso))
                .ForMember(dest => dest.PasswordExpirationDate, opt => opt.MapFrom(src => src.FechaCaducidadPass))
                .ForMember(dest => dest.UsuarioRol, opt => opt.MapFrom(src => src.UsuarioRol)) // lista
                .ForMember(dest => dest.UsuarioSistemas, opt => opt.MapFrom(src => src.UsuarioSistemas)); // lista;


            CreateMap<DateTime, long>().ConvertUsing(new DateTimeLongTypeConverter());
            CreateMap<long, DateTime>().ConvertUsing(new LongDateTimeTypeConverter());

        }
    }
}
