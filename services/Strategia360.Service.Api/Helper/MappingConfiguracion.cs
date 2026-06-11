using AutoMapper;
using Strategia360.Service.Api.Models;

using static DFast.Common.General.CommonAutoMapper;
using Strategia360.Service.Api.Dtos;


namespace Strategia360.Service.Api.Helper
{
    public class MappingConfiguracion :Profile
    {
        public MappingConfiguracion()
        {

            //CreateMap<Usuario, UsuarioDto>().ReverseMap();
            //CreateMap<UsuarioRol, UsuarioRolDto>().ReverseMap();
            //CreateMap<UsuarioSistema, UsuarioSistemaDto>().ReverseMap();
            //CreateMap<Menu, MenuDto>().ReverseMap();
            //CreateMap<UsuarioSistema, UsuarioSistemaDto>().ReverseMap();

            CreateMap<Visita, VisitaDto>().ReverseMap();
            CreateMap<Ciudadano, CiudadanoDto>().ReverseMap();
            CreateMap<VisitaIntencionVoto, VisitaIntencionVotoDto>().ReverseMap();




            CreateMap<DateTime, long>().ConvertUsing(new DateTimeLongTypeConverter());
            CreateMap<long, DateTime>().ConvertUsing(new LongDateTimeTypeConverter());

        }
    }
}
