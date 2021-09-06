using Microservice.Framework.Common;
using Microservice.Framework.Domain.Commands;
using Microservice.Framework.Domain.ExecutionResults;
using Microservice.Framework.Domain.Queries;
using ShoppingBasketService.Domain.Application.Mappers;
using ShoppingBasketService.Domain.Application.Model;
using ShoppingBasketService.Domain.Application.Model.Dtos;
using ShoppingBasketService.Domain.DomainModel.ShoppingBasketDomainModel;
using ShoppingBasketService.Domain.DomainModel.ShoppingBasketDomainModel.Commands;
using ShoppingBasketService.Domain.DomainModel.ShoppingBasketDomainModel.Entities;
using ShoppingBasketService.Domain.DomainModel.ShoppingBasketDomainModel.Queries;
using ShoppingBasketService.Domain.Extensions;
using ShoppingBasketService.Domain.ExternalServices;
using ShoppingBasketService.Domain.ExternalServices.Models.ExternalRequestModels;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace ShoppingBasketService.Domain.Application
{
    public class ShoppingBasketService : IShoppingBasketService
    {
        private readonly ICommandBus _commandBus;
        private readonly IQueryProcessor _queryPropcessor;
        private readonly IDiscountService _discountService;
        private readonly IEventCatalogService _eventCatalogService;

        public ShoppingBasketService(
            ICommandBus commandBus,
            IQueryProcessor queryPropcessor,
            IDiscountService discountService,
            IEventCatalogService eventCatalogService)
        {
            _commandBus = commandBus;
            _queryPropcessor = queryPropcessor;
            _discountService = discountService;
            _eventCatalogService = eventCatalogService;
        }

        public async Task<IExecutionResult> AddBasketLine(
            BasketId basketId,
            AddBasketLineApplicationModel addBasketLineApplicationModel, 
            CancellationToken cancellationToken)
        {
            return await _commandBus
                .PublishAsync(
                new AddBasketLineCommand(
                    basketId,
                    addBasketLineApplicationModel), cancellationToken);
        }

        public async Task<IExecutionResult> CheckoutBasket(
            BasketCheckoutApplicationModel basketCheckoutApplicationModel, 
            CancellationToken cancellationToken)
        {
            var coupon = await _discountService.GetCoupon(
                new GetCouponExternalRequestModel { UserId = basketCheckoutApplicationModel.UserId }, 
                cancellationToken);

            return await _commandBus
                .PublishAsync(
                new CheckoutBasketCommand(
                    basketCheckoutApplicationModel.BasketId,
                    basketCheckoutApplicationModel,
                    coupon), cancellationToken);
        }

        public async Task<Basket> CreateBasket(
            string userId,
            CancellationToken cancellationToken)
        {
            var result = await _commandBus
                .PublishAsync(
                new CreateBasketCommand(
                    BasketId.New,
                    userId), cancellationToken);

            return result.As<Basket>();
        }

        public Task<Basket> GetBasket(
            BasketId basketId, 
            string userId, 
            CancellationToken cancellationToken)
        {
            return _queryPropcessor
                .ProcessAsync(new GetBasketQuery(basketId, userId), cancellationToken);
        }

        public Task<BasketLine> GetBasketLine(
            BasketId basketId, 
            BasketLineId basketLineId, 
            CancellationToken cancellationToken)
        {
            return _queryPropcessor
                .ProcessAsync(new GetBasketLineQuery(basketId, basketLineId), cancellationToken);
        }

        public async Task<IExecutionResult> UpdateBasketLine(
            BasketId basketId, 
            UpdateBasketLineApplicationModel updateBasketLineApplicationModel, 
            CancellationToken cancellationToken)
        {
            return await _commandBus
                .PublishAsync(
                new UpdateBasketLineCommand(
                    basketId,
                    updateBasketLineApplicationModel), cancellationToken);
        }

        public async Task<IExecutionResult> DeleteBasketLine(
            BasketId basketId,
            DeleteBasketLineApplicationModel deleteBasketLineApplicationModel,
            CancellationToken cancellationToken)
        {
            return await _commandBus
                .PublishAsync(
                new DeleteBasketLineCommand(
                    basketId,
                    deleteBasketLineApplicationModel), cancellationToken);
        }

        public async Task<BasketLinseDtoApplicationModel> GetBasketLines(
            BasketId basketId, 
            string userId, 
            CancellationToken cancellationToken)
        {
            var basket = await GetBasket(basketId, userId, cancellationToken);

            if(basket.IsNotNull() && basket.BasketLines.HasItems())
            {
                var linesEventIds = basket.BasketLines.Select(bl => bl.EventId);

                var events = await _eventCatalogService.GetEvents(linesEventIds, cancellationToken);

                return new BasketLinseDtoApplicationModelMapper(events, basket.BasketLines).Map();
            }

            return new BasketLinseDtoApplicationModel();
        }
    }
}
