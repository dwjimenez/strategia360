using AutoMapper;
using Strategia360.Service.Api.Models;
using Strategia360.Service.Api.DTOs;
using static DFast.Common.General.CommonAutoMapper;


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
            

           


            CreateMap<DateTime, long>().ConvertUsing(new DateTimeLongTypeConverter());
            CreateMap<long, DateTime>().ConvertUsing(new LongDateTimeTypeConverter());

        }
    }
}
