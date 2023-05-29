using AutoMapper;
using BY.Store.Application.Dtos.Aggragates;
using BY.Store.Application.Dtos.Custom.Basket;
using BY.Store.Domain.Entities;

namespace BY.Store.Application.Mappings.AutoMapper
{
    public class CustomProfile : Profile
    {
        public CustomProfile()
        {
            CreateMap<BasketItem, AddProductToBasketDto>()
                .ForMember(e => e.ProductId, m => m.MapFrom(dto => dto.ProductId))
                .ForMember(e => e.Quantity, m => m.MapFrom(dto => dto.Quantity))
                .ReverseMap();

            CreateMap<Basket, AggragateBasketDto>().ReverseMap();
        }
    }
}
