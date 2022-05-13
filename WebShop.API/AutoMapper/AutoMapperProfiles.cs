using AutoMapper;
using WebShop.API.Models.Entities;
using WebShop.API.Models.ViewModels;

namespace WebShop.API.AutoMapper
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<CreateProduct, ProductEntity>();
            CreateMap<UpdateProduct, ProductEntity>().ReverseMap();

        }
    }
}
