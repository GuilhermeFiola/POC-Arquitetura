using AutoMapper;
using Normas.WebAPI.DTO.Normas;
using Normas.WebAPI.Entities;

namespace Normas.WebAPI.Helpers
{
    public class MapperProfile : Profile
    {
        public MapperProfile()
        {
            CreateMap<AdicionarNormaRequestDTO, Norma>()
                .ForMember(dest => dest.TipoDocumento, opt => opt.Ignore())
                .ForMember(dest => dest.OrgaoExpedicao, opt => opt.Ignore());

            CreateMap<Norma, AdicionarNormaResponseDTO>()
                .ForMember(dest => dest.TipoDocumento, opt => opt.MapFrom(s => s.TipoDocumento.Descricao))
                .ForMember(dest => dest.OrgaoExpedicao, opt => opt.MapFrom(s => s.OrgaoExpedicao.Descricao));

            CreateMap<Norma, ExcluirNormaResponseDTO>()
                .ForMember(dest => dest.TipoDocumento, opt => opt.MapFrom(s => s.TipoDocumento.Descricao))
                .ForMember(dest => dest.OrgaoExpedicao, opt => opt.MapFrom(s => s.OrgaoExpedicao.Descricao));
        }
    }
}
