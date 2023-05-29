using AutoMapper;
using BY.Store.Application.Base;
using BY.Store.Application.Dtos.Master;
using BY.Store.Application.Interfaces;
using BY.Store.Domain.Entities;
using BY.Store.Infrastructure.DataAccess.Interfaces;
using BY.Store.Shared.Constants;
using BY.Store.Shared.Params;
using BY.Toolkit.Responses.Service;
using Microsoft.EntityFrameworkCore;

namespace BY.Store.Application.Services
{
    public class BasketService : BaseService, IBasketService
    {
        private readonly IBasketRepository _basketRepository;

        public BasketService(IApplicationParams applicationParams,
            IMapper mapper,
            IBasketRepository basketRepository) : base(applicationParams, mapper)
        {
            _basketRepository = basketRepository;
        }

        #region Queries

        public async Task<ServiceResponse<BasketDto>> GetById(int id)
        {
            try
            {
                var basket = await _basketRepository.Get(b => b.Id == id).Result.FirstOrDefaultAsync();

                var result = _mapper.Map<BasketDto>(basket);
                return new SuccessServiceResponse<BasketDto>(result, new string[] { ResponseMessages.OperationSuccessful });

            }
            catch (Exception)
            {
                return new ErrorServiceResponse<BasketDto>(new string[] { ResponseMessages.OperationFailed });
            }
        }


        public async Task<ServiceResponse<List<BasketDto>>> GetList()
        {
            try
            {
                var baskets = await _basketRepository.GetList().Result.ToListAsync();

                var result = _mapper.Map<List<BasketDto>>(baskets);
                return new SuccessServiceResponse<List<BasketDto>>(result, new string[] { ResponseMessages.OperationSuccessful });

            }
            catch (Exception)
            {
                return new ErrorServiceResponse<List<BasketDto>>(new string[] { ResponseMessages.OperationFailed });
            }
        }

        #endregion

        #region Commands
        public async Task<ServiceResponse<BasketDto>> Add(BasketDto dto)
        {
            try
            {
                var basket = _mapper.Map<BasketDto,Basket>(dto);

                var result = await _basketRepository.Add(basket);

                var response = _mapper.Map<BasketDto>(result);
                return new SuccessServiceResponse<BasketDto>(response, new string[] { ResponseMessages.OperationSuccessful });

            }
            catch (Exception)
            {
                return new ErrorServiceResponse<BasketDto>(new string[] { ResponseMessages.OperationFailed });
            }
        }

        public async Task<ServiceResponse<BasketDto>> Delete(BasketDto dto)
        {
            try
            {
                var basket = _mapper.Map<Basket>(dto);

                var result = await _basketRepository.Delete(basket);

                var response = _mapper.Map<BasketDto>(result);
                return new SuccessServiceResponse<BasketDto>(response, new string[] { ResponseMessages.OperationSuccessful });

            }
            catch (Exception)
            {
                return new ErrorServiceResponse<BasketDto>(new string[] { ResponseMessages.OperationFailed });
            }
        }

        public async Task<ServiceResponse<BasketDto>> Update(BasketDto dto)
        {
            try
            {
                var basket = _mapper.Map<Basket>(dto);

                var result = await _basketRepository.Update(basket);

                var response = _mapper.Map<BasketDto>(result);
                return new SuccessServiceResponse<BasketDto>(response, new string[] { ResponseMessages.OperationSuccessful });

            }
            catch (Exception)
            {
                return new ErrorServiceResponse<BasketDto>(new string[] { ResponseMessages.OperationFailed });
            }
        }
        #endregion
    }
}
