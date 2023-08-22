using AutoMapper;
using Core.Entities;
using Core.Entities.Identity;
using skinet2.Dtos;

namespace skinet2.Helpers
{
	public class MappingProfiles : Profile
	{
        public MappingProfiles()
        {
            CreateMap<Products, ProductToReturnDto>()
                .ForMember(d=> d.ProductBrand, o=> o.MapFrom(s=> s.ProductBrand.Name))
                .ForMember(d => d.ProductType, o => o.MapFrom(s => s.ProductType.Name))
                .ForMember(d => d.PictureUrl, o => o.MapFrom<ProductUrlResolver>());
            
            CreateMap<Address, AddressDto>().ReverseMap();
        }
    }
}
