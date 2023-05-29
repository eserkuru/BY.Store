using BY.Store.Application.Dtos.Master;
using BY.Toolkit.Responses.Service;

namespace BY.Store.Application.Interfaces
{
    public interface IBasketService
    {
        Task<ServiceResponse<BasketDto>> GetById(int id);
        Task<ServiceResponse<List<BasketDto>>> GetList();
        Task<ServiceResponse<BasketDto>> Add(BasketDto dto);
        Task<ServiceResponse<BasketDto>> Update(BasketDto dto);
        Task<ServiceResponse<BasketDto>> Delete(BasketDto dto);
    }
}
