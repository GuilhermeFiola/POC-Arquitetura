using AutoMapper;
using Normas.WebAPI.DTO.Normas;
using Normas.WebAPI.Entities;

namespace Normas.WebAPI.Helpers
{
    public class MapperProfile : Profile
    {
        public MapperProfile()
        {
            CreateMap<Norma, BuscarNormaResponseDTO>();

            CreateMap<AdicionarNormaRequestDTO, Norma>()
                .ForMember(dest => dest.IdTipoDocumento, opt => opt.MapFrom(s => s.TipoDocumento))
                .ForMember(dest => dest.IdOrgaoExpedidor, opt => opt.MapFrom(s => s.OrgaoExpedicao))
                .ForMember(dest => dest.TipoDocumento, opt => opt.Ignore())
                .ForMember(dest => dest.OrgaoExpedicao, opt => opt.Ignore());

            CreateMap<Norma, AdicionarNormaResponseDTO>();

            CreateMap<AtualizarNormaRequestDTO, Norma>()
                .ForMember(dest => dest.IdTipoDocumento, opt => opt.MapFrom(s => s.TipoDocumento))
                .ForMember(dest => dest.IdOrgaoExpedidor, opt => opt.MapFrom(s => s.OrgaoExpedicao))
                .ForMember(dest => dest.TipoDocumento, opt => opt.Ignore())
                .ForMember(dest => dest.OrgaoExpedicao, opt => opt.Ignore());

            CreateMap<Norma, AtualizarNormaResponseDTO>();

            CreateMap<Norma, ExcluirNormaResponseDTO>();

            CreateMap<ImportarNormaRequestDTO, Norma>()
                .ForMember(dest => dest.TipoDocumento, opt => opt.Ignore())
                .ForMember(dest => dest.OrgaoExpedicao, opt => opt.Ignore());

            CreateMap<Norma, ImportarNormaResponseDTO>();
        }
    }
}
