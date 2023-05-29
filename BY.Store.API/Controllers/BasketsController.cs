using BY.Store.Application.Dtos.Custom.Basket;
using BY.Store.Application.Interfaces;
using BY.Store.Shared.Params;
using Microsoft.AspNetCore.Mvc;

namespace BY.Store.API.Controllers
{
    public class BasketsController : BaseController
    {
        private readonly IBasketService _basketService;
        private readonly IBasketItemService _basketItemService;
        public BasketsController(IApplicationParams applicationParams, IBasketService basketService, IBasketItemService basketItemService) : base(applicationParams)
        {
            _basketService = basketService;
            _basketItemService = basketItemService;
        }

        [HttpPost("AddToBasket")]
        public IActionResult AddToBasket(AddProductToBasketDto addProductToBasketDto)
        {
            var serviceResponse = _basketItemService.Add(addProductToBasketDto);
            if (!serviceResponse.Result.IsSuccess)
                return BadRequest(serviceResponse.Result);
            return Ok(serviceResponse.Result);
        }

        [HttpGet("Get")]
        public IActionResult Get()
        {
            var result = _basketService.GetList();
            if (!result.Result.IsSuccess)
                return BadRequest(result.Result);
            return Ok(result.Result);
        }
    }
}
