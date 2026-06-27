using AutoMapper;
using Strategia.Service.Api.Models;

using static DFast.Common.General.CommonAutoMapper;
using Strategia.Service.Api.DTOs;


namespace  Strategia.Service.Helper
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

            CreateMap<Visita, VisitaDto>()
                .ForMember(
                    dest => dest.VisitaIntencionVotos,
                    opt => opt.MapFrom(src => src.VisitaIntencionVoto))
                .ReverseMap()
                .ForMember(
                    dest => dest.VisitaIntencionVoto,
                    opt => opt.MapFrom(src => src.VisitaIntencionVotos));
            CreateMap<Ciudadano, CiudadanoDto>().ReverseMap();
            CreateMap<VisitaIntencionVoto, VisitaIntencionVotoDto>().ReverseMap();
            CreateMap<Centuria, CenturiaDto>().ReverseMap();
            CreateMap<Territorio, TerritoryDto>().ReverseMap();
            CreateMap<IntencionVotoOpcion, VoteIntentOptionDto>().ReverseMap();




            CreateMap<DateTime, long>().ConvertUsing(new DateTimeLongTypeConverter());
            CreateMap<long, DateTime>().ConvertUsing(new LongDateTimeTypeConverter());

        }
    }
}
