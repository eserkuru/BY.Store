using AutoMapper;
using BY.Store.Application.Dtos.Master;
using BY.Store.Domain.Base;
using BY.Store.Domain.Entities;

namespace BY.Store.Application.Mappings.AutoMapper
{
    public class MasterProfile : Profile
    {
        public MasterProfile()
        {
            CreateMap<BaseEntity, BaseDto>().ReverseMap();
            CreateMap<Basket, BasketDto>().ReverseMap();
            CreateMap<BasketItem, BasketItemDto>().ReverseMap();
            CreateMap<Product, ProductDto>().ReverseMap();
        }
    }
}
