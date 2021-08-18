using AutoMapper;
using Microservice.Framework.Common;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ShoppingBasketService.Api.Models;
using ShoppingBasketService.Domain.Application;
using ShoppingBasketService.Domain.Application.Model;
using ShoppingBasketService.Domain.DomainModel.ShoppingBasketDomainModel;
using ShoppingBasketService.Domain.DomainModel.ShoppingBasketDomainModel.BusMessages;
using ShoppingBasketService.Domain.DomainModel.ShoppingBasketDomainModel.Entities;
using ShoppingBasketService.Domain.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace ShoppingBasketService.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ShoppingBasketLinesController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IShoppingBasketService _shoppingBasketService;

        public ShoppingBasketLinesController(
            IMapper mapper,
            IShoppingBasketService shoppingBasketService)
        {
            _mapper = mapper;
            _shoppingBasketService = shoppingBasketService;
        }

        [HttpGet("getBasketLines/{basketId}")]
        public async Task<IActionResult> GetBasketLines([FromQuery]string basketId)
        {
            var basket = await _shoppingBasketService
                .GetBasket(new BasketId(basketId), null, CancellationToken.None);

            if (basket.IsNull())
            {
                return NotFound();
            }

            return Ok(_mapper.Map<IEnumerable<BasketLineDtoModel>>(basket.BasketLines));
        }

        [HttpGet("getBasketLine/{basketId}/{basketLineId}")]
        public async Task<IActionResult> Get(
            [FromQuery]string basketId,
            [FromQuery]string basketLineId)
        {
            var basket = await _shoppingBasketService
                .GetBasket(new BasketId(basketId), null, CancellationToken.None);

            if (basket.IsNull())
            {
                return NotFound();
            }

            var basketLine = basket.BasketLines
                .First(bl => bl.Id == new BasketLineId(basketLineId));

            if (basketLine == null)
            {
                return NotFound();
            }

            return Ok(_mapper.Map<BasketLineDtoModel>(basketLine));
        }

        [HttpPost("addBasketLine")]
        public async Task<IActionResult> AddBasketLine(AddBasketLineRequestModel model)
        {
            if(ModelState.IsValid)
            {
                var basket = await _shoppingBasketService
                    .GetBasket(model.BasketId, null, CancellationToken.None);

                if (basket.IsNull())
                {
                    return NotFound();
                }

                var addBasketLineResult = await _shoppingBasketService
                    .AddBasketLine(model.BasketId, _mapper.Map<AddBasketLineApplicationModel>(model), CancellationToken.None);

                if (!addBasketLineResult.IsSuccess)
                    return BadRequest(addBasketLineResult);

                var basketLineDto = _mapper.Map<BasketLineDtoModel>(addBasketLineResult.As<BasketLine>());

                return CreatedAtRoute(
                    "getBasketLine",
                    new { basketId = basketLineDto.BasketId.Value, basketLineId = basketLineDto.BasketLineId.Value },
                    basketLineDto);
            }
            else
            {
                return BadRequest(ModelState.Values);
            }
        }

        [HttpPost("updateBasketLine")]
        public async Task<IActionResult> UpdateBasketLine(UpdateBasketLineRequestModel model)
        {
            if (ModelState.IsValid)
            {
                var basketLine = await _shoppingBasketService
                    .GetBasketLine(model.BasketId, model.BasketLineId, CancellationToken.None);

                if (basketLine.IsNull())
                {
                    return NotFound();
                }

                var updateBasketLineResult = await _shoppingBasketService
                    .UpdateBasketLine(model.BasketId, _mapper.Map<UpdateBasketLineApplicationModel>(model), CancellationToken.None);

                if (!updateBasketLineResult.IsSuccess)
                    return BadRequest(updateBasketLineResult);

                var basketLineDto = _mapper.Map<BasketLineDtoModel>(updateBasketLineResult.As<BasketLine>());

                return CreatedAtRoute(
                    "getBasketLine",
                    new { basketId = basketLineDto.BasketId.Value, basketLineId = basketLineDto.BasketLineId.Value },
                    basketLineDto);
            }
            else
            {
                return BadRequest(ModelState.Values);
            }
        }

        [HttpPost("deleteBasketLine")]
        public async Task<IActionResult> DeleteBasketLine(DeleteBasketLineRequestModel model)
        {
            if (ModelState.IsValid)
            {
                var deleteBasketLineResult = await _shoppingBasketService
                    .DeleteBasketLine(model.BasketId, _mapper.Map<DeleteBasketLineApplicationModel>(model), CancellationToken.None);

                if (!deleteBasketLineResult.IsSuccess)
                    return BadRequest(deleteBasketLineResult);

                return NoContent();
            }
            else
            {
                return BadRequest(ModelState.Values);
            }
        }
    }
}