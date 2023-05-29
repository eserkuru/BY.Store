using AutoMapper;
using BY.Store.Application.Base;
using BY.Store.Application.Dtos.Aggragates;
using BY.Store.Application.Dtos.Custom.Basket;
using BY.Store.Application.Dtos.Master;
using BY.Store.Application.Interfaces;
using BY.Store.Application.Validations.Fluent;
using BY.Store.Domain.Entities;
using BY.Store.Infrastructure.DataAccess.Interfaces;
using BY.Store.Shared.Constants;
using BY.Store.Shared.Params;
using BY.Toolkit.Responses.Service;
using Microsoft.EntityFrameworkCore;

namespace BY.Store.Application.Services
{
    public class BasketItemService : BaseService, IBasketItemService
    {
        #region properties
        private readonly IBasketItemRepository _basketItemRepository;
        private readonly IBasketRepository _basketRepository;
        private readonly IProductRepository _productRepository;
        private readonly IStockRepository _stockRepository;
        #endregion

        #region constructor
        public BasketItemService(IApplicationParams applicationParams,
          IMapper mapper,
          IBasketItemRepository basketItemRepository,
          IBasketRepository basketRepository,
          IProductRepository productRepository,
          IStockRepository stockRepository) : base(applicationParams, mapper)
        {
            _basketItemRepository = basketItemRepository;
            _basketRepository = basketRepository;
            _productRepository = productRepository;
            _stockRepository = stockRepository;
        }

        #endregion

        #region Principle Operations

        #region Queries

        public async Task<ServiceResponse<BasketItemDto>> GetById(int id)
        {
            try
            {
                var basketItem = await _basketItemRepository.Get(b => b.Id == id).Result.FirstOrDefaultAsync();

                var result = _mapper.Map<BasketItemDto>(basketItem);
                return new SuccessServiceResponse<BasketItemDto>(result, new string[] { ResponseMessages.OperationSuccessful });

            }
            catch (Exception)
            {
                return new ErrorServiceResponse<BasketItemDto>(new string[] { ResponseMessages.OperationFailed });
            }
        }

        public async Task<ServiceResponse<List<BasketItemDto>>> GetList()
        {
            try
            {
                var basketItems = await _basketItemRepository.GetList().Result.ToListAsync();

                var result = _mapper.Map<List<BasketItemDto>>(basketItems);
                return new SuccessServiceResponse<List<BasketItemDto>>(result, new string[] { ResponseMessages.OperationSuccessful });

            }
            catch (Exception)
            {
                return new ErrorServiceResponse<List<BasketItemDto>>(new string[] { ResponseMessages.OperationFailed });
            }
        }

        #endregion

        #region Commands
        public async Task<ServiceResponse<BasketItemDto>> Add(BasketItemDto dto)
        {
            try
            {
                var basketItem = _mapper.Map<BasketItem>(dto);

                var result = await _basketItemRepository.Add(basketItem);

                var response = _mapper.Map<BasketItemDto>(result);
                return new SuccessServiceResponse<BasketItemDto>(response, new string[] { ResponseMessages.OperationSuccessful });

            }
            catch (Exception)
            {
                return new ErrorServiceResponse<BasketItemDto>(new string[] { ResponseMessages.OperationFailed });
            }
        }

        public async Task<ServiceResponse<BasketItemDto>> Delete(BasketItemDto dto)
        {
            try
            {
                var basketItem = _mapper.Map<BasketItem>(dto);

                var result = await _basketItemRepository.Delete(basketItem);

                var response = _mapper.Map<BasketItemDto>(result);
                return new SuccessServiceResponse<BasketItemDto>(response, new string[] { ResponseMessages.OperationSuccessful });

            }
            catch (Exception)
            {
                return new ErrorServiceResponse<BasketItemDto>(new string[] { ResponseMessages.OperationFailed });
            }
        }

        public async Task<ServiceResponse<BasketItemDto>> Update(BasketItemDto dto)
        {
            try
            {
                var basketItem = _mapper.Map<BasketItem>(dto);

                var result = await _basketItemRepository.Update(basketItem);

                var response = _mapper.Map<BasketItemDto>(result);
                return new SuccessServiceResponse<BasketItemDto>(response, new string[] { ResponseMessages.OperationSuccessful });

            }
            catch (Exception)
            {
                return new ErrorServiceResponse<BasketItemDto>(new string[] { ResponseMessages.OperationFailed });
            }
        }

        #endregion

        #endregion

        #region Custom Operations

        #region Queries
        #endregion

        #region Commands
        public async Task<ServiceResponse<AggragateBasketDto>> Add(AddProductToBasketDto dto)
        {
            try
            {
                var basketItem = _mapper.Map<BasketItem>(dto);

                #region Validations

                var validator = new AddProductToBasketDtoValidator();
                var validationResult = validator.Validate(dto);
                if (!validationResult.IsValid) 
                    return new ErrorServiceResponse<AggragateBasketDto>(validationResult.Errors.Select(x => x.ErrorMessage).ToList());
                
                // Sistemde ürün var mı?
                var product = _productRepository.GetAll().FirstOrDefault(p => p.Id == dto.ProductId);
                if (product is null)
                    return new ErrorServiceResponse<AggragateBasketDto>(new string[] { BasketServiceMessages.ProductNotFound });

                // Ürünün birim fiyatı geçerli mi?
                if (product.Price <= 0)
                    return new ErrorServiceResponse<AggragateBasketDto>(new string[] { BasketServiceMessages.BadPriceForProduct });

                // Sistemde stok var mı?
                var stock = _stockRepository.GetAll().FirstOrDefault(s => s.ProductId == dto.ProductId);
                if (stock?.Quantity < dto.Quantity)
                    return new ErrorServiceResponse<AggragateBasketDto>(new string[] { BasketServiceMessages.StockNotFound });

                // Not: Sistem InMemoryDb ile ram'de depolama yapması ve stok servislerinin dummy olması nedeniyle
                // eklenen ürünler stok miktarlarından düşmeyecektir. Sadece yeteri kadar stok olup olmadığı kontrolü yapılmıştır.
                #endregion

                // Müşterinin sepeti var mı?
                var basket = _basketRepository.Get(b => b.CustomerId == _applicationParams.CurrentCustomerId)
                    .Result.FirstOrDefault();
                if (basket is null)
                {
                    basket = _basketRepository.Add(
                        new Basket
                        {
                            CustomerId = _applicationParams.CurrentCustomerId,
                            TotalAmount = 0,
                            TotalPrice = 0,
                        }).Result;
                }

                #region BasketItem
                // Müşterinin sepetinde üründen var mı?
                var currentBasketItem = _basketItemRepository.Get(bi => bi.BasketId == basket.Id && bi.ProductId == dto.ProductId)
                    .Result.FirstOrDefault();
                if (currentBasketItem is null)
                {
                    // Yoksa sepete ürün oluştur.
                    basketItem.BasketId = basket.Id;
                    basketItem.UnitPrice = product.Price;
                    basketItem.TotalPrice = Math.Round(product.Price * basketItem.Quantity, 2);

                    currentBasketItem = await _basketItemRepository.Add(basketItem);
                }
                else
                {
                    // Varsa sepetteki ürünü güncelle.
                    currentBasketItem.Quantity += basketItem.Quantity;
                    currentBasketItem.TotalPrice += Math.Round(product.Price * basketItem.Quantity, 2);

                    var result = await _basketItemRepository.Update(currentBasketItem);
                }
                #endregion

                #region Basket

                // Sepeti hazırla ve güncelle.
                var basketItems = _basketItemRepository.Get(bi => bi.BasketId == basket.Id).Result.ToList();
                basket.TotalPrice = Math.Round(basketItems.Sum(bi => bi.TotalPrice), 2);
                basket.TotalAmount = Math.Round(basketItems.Sum(bi => bi.TotalPrice), 2);

                var updatedBasket = _basketRepository.Update(basket).Result;
                #endregion

                var response = _mapper.Map<AggragateBasketDto>(updatedBasket);
                response.BasketItems = _mapper.Map<List<BasketItemDto>>(basketItems);

                return new SuccessServiceResponse<AggragateBasketDto>(response, new string[] { ResponseMessages.OperationSuccessful });
            }
            catch (Exception)
            {
                return new ErrorServiceResponse<AggragateBasketDto>(new string[] { ResponseMessages.OperationFailed });
            }
        }

        #endregion

        #endregion
    }
}
