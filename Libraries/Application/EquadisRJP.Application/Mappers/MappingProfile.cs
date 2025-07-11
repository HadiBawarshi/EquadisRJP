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
            CreateMap<Supplier, SupplierDto>();
            CreateMap<Partnership, PartnershipDto>();
            CreateMap<CommercialOffer, RetailerOfferDto>()
           .ForMember(d => d.SupplierName, o => o.MapFrom(src => src.Supplier.CompanyName));


        }
    }
}
