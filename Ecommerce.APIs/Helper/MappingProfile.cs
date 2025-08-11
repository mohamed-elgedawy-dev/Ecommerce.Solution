using AutoMapper;
using Ecommerce.APIs.Dtos;
using Ecommerce.Core.Entities;

namespace Ecommerce.APIs.Helper
{
    public class MappingProfile : Profile
    {
        

        public MappingProfile()
        {
            CreateMap<Product, ProductToReturnDto>().ForMember(b => b.Brand, o => o.MapFrom(s => s.Name))
                .ForMember(c => c.ProductCategory, o => o.MapFrom(s => s.Name)).
                ForMember(p=>p.PictureUrl,o=>o.MapFrom<ProductPictureUrlResolver>());
            
        }


    }
}
