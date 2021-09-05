using AutoMapper;
using Microservice.Framework.Common;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ShoppingBasketService.Api.Models;
using ShoppingBasketService.Domain.Application;
using ShoppingBasketService.Domain.Application.Model;
using ShoppingBasketService.Domain.DomainModel.ShoppingBasketDomainModel;
using ShoppingBasketService.Domain.DomainModel.ShoppingBasketDomainModel.BusMessages;
using ShoppingBasketService.Domain.Extensions;
using ShoppingBasketService.Domain.ExternalServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace ShoppingBasketService.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ShoppingBasketController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IShoppingBasketService _shoppingBasketService;

        public ShoppingBasketController(
            IMapper mapper,
            IShoppingBasketService shoppingBasketService)
        {
            _mapper = mapper;
            _shoppingBasketService = shoppingBasketService;
        }

        [HttpPost("checkout")]
        public async Task<IActionResult> Checkout([FromBody] BasketCheckoutRequestModel model)
        {
            var basketCheckoutMessage = _mapper.Map<BasketCheckoutApplicationModel>(model);

            var checkoutBasketResult = await _shoppingBasketService
                .CheckoutBasket(basketCheckoutMessage, CancellationToken.None);

            return Ok(checkoutBasketResult);
        }

        [HttpPost("createBasket")]
        public async Task<IActionResult> CreateBasket(CreateBasketRequestModel model)
        {
            var basket = await _shoppingBasketService
                .CreateBasket(model.UserId, CancellationToken.None);

            var result = _mapper.Map<BasketDtoModel>(basket);
            result.NumberOfItems = basket.BasketLines?.Sum(bl => bl.TicketAmount);
            return Ok(result);
        }

        [HttpGet("getBasket")]
        public async Task<ActionResult<Basket>> GetBasket([FromQuery] GetBasketRequestModel model)
        {
            var basket = model.BasketId.IsNullOrEmpty() ? null : await _shoppingBasketService
                .GetBasket(new BasketId(model.BasketId), null, CancellationToken.None);

            if (basket == null)
            {
                return Ok(null);
            }

            var result = _mapper.Map<BasketDtoModel>(basket);
            result.NumberOfItems = basket.BasketLines?.Sum(bl => bl.TicketAmount);
            return Ok(result);
        }
    }
}
