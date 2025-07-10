using AutoMapper;
using EquadisRJP.Application.Dtos;
using EquadisRJP.Domain.Entities;

namespace EquadisRJP.Application.Mappers
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Retailer, RetailerDto>();

        }
    }
}
