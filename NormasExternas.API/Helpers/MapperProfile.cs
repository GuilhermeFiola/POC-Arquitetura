using AutoMapper;
using NormasExternas.WebAPI.DTO.Normas;
using NormasExternas.WebAPI.Entities;

namespace NormasExternas.WebAPI.Helpers
{
    public class MapperProfile : Profile
    {
        public MapperProfile()
        {
            CreateMap<Norma, BuscarNormaResponseDTO>();

            CreateMap<AdicionarNormaRequestDTO, Norma>();

            CreateMap<Norma, AdicionarNormaResponseDTO>();
        }
    }
}
