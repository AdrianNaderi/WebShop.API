using AutoMapper;
using WebShop.API.Models.Entities;
using WebShop.API.Models.ViewModels.Product;

namespace WebShop.API.AutoMapper
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<CreateProduct, ProductEntity>();
            CreateMap<UpdateProduct, ProductEntity>();
            CreateMap<ProductEntity, ProductViewModel>()
                .ForMember(d => d.Brand, option => option.MapFrom(s => s.BrandEntity.BrandName));
            CreateMap<ProductColor, ColorViewModel>()
                .ForMember(d => d.ColorName, option => option.MapFrom(s => s.ColorName))
                .ForMember(d => d.Hex, option => option.MapFrom(s => s.Color.Hex));
        }
    }
}
