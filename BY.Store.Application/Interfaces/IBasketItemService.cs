using BY.Store.Application.Dtos.Aggragates;
using BY.Store.Application.Dtos.Custom.Basket;
using BY.Store.Application.Dtos.Master;
using BY.Toolkit.Responses.Service;

namespace BY.Store.Application.Interfaces
{
    public interface IBasketItemService
    {
        Task<ServiceResponse<BasketItemDto>> GetById(int id);
        Task<ServiceResponse<List<BasketItemDto>>> GetList();
        Task<ServiceResponse<BasketItemDto>> Add(BasketItemDto dto);
        Task<ServiceResponse<BasketItemDto>> Update(BasketItemDto dto);
        Task<ServiceResponse<BasketItemDto>> Delete(BasketItemDto dto);
        Task<ServiceResponse<AggragateBasketDto>> Add(AddProductToBasketDto dto);
    }
}
