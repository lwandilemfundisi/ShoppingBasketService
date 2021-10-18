using AutoMapper;
using Microservice.Framework.Common;
using Microservice.Framework.Domain.Commands;
using Microservice.Framework.Domain.ExecutionResults;
using Microservice.Framework.Domain.Queries;
using ShoppingBasketService.Domain.Application.Model;
using ShoppingBasketService.Domain.DomainModel.ShoppingBasketDomainModel.BusMessages;
using ShoppingBasketService.Domain.DomainModel.ShoppingBasketDomainModel.Queries;
using ShoppingBasketService.Domain.ExternalServices.Models.ExternalDtoModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ShoppingBasketService.Domain.DomainModel.ShoppingBasketDomainModel.Commands
{
    public class CheckoutBasketCommand
        : Command<Basket, BasketId>
    {
        #region Constructors

        public CheckoutBasketCommand(
            BasketId id,
            BasketCheckoutApplicationModel basketCheckoutApplicationModel, 
            CouponExternalDtoModel coupon) 
            : base(id)
        {
            BasketCheckoutApplicationModel = basketCheckoutApplicationModel;
            Coupon = coupon;
        }

        #endregion

        #region Properties

        public BasketCheckoutApplicationModel BasketCheckoutApplicationModel { get; }
        public CouponExternalDtoModel Coupon { get; }

        #endregion
    }

    public class CheckoutBasketCommandHandler
        : CommandHandler<Basket, BasketId, CheckoutBasketCommand>
    {
        private readonly IMapper _mapper;
        private readonly IQueryProcessor _queryProcessor;

        public CheckoutBasketCommandHandler(
            IMapper mapper,
            IQueryProcessor queryProcessor)
        {
            _mapper = mapper;
            _queryProcessor = queryProcessor;
        }
        
        #region Abstract Members

        public override async Task<IExecutionResult> ExecuteAsync(
            Basket aggregate, 
            CheckoutBasketCommand command, 
            CancellationToken cancellationToken)
        {
            var basketCheckoutMessage = _mapper
                .Map<BasketCheckoutMessage>(command.BasketCheckoutApplicationModel);

            int total = 0;

            var basket = await _queryProcessor
                .ProcessAsync(new GetBasketQuery(
                    command.AggregateId, 
                    command.BasketCheckoutApplicationModel.UserId), cancellationToken);

            foreach (var b in basket.BasketLines)
            {
                var basketLineMessage = new BasketLineMessage
                {
                    BasketLineId = b.Id,
                    Price = b.Price,
                    TicketAmount = b.TicketAmount
                };

                total += b.Price * b.TicketAmount;

                basketCheckoutMessage.BasketLines.Add(basketLineMessage);
            }

            if(command.Coupon.IsNotNull())
            {
                basketCheckoutMessage.BasketTotal = total - command.Coupon.DiscountAmount;
            }
            else
            {
                basketCheckoutMessage.BasketTotal = total;
            }

            aggregate.CheckoutBasket(basketCheckoutMessage);

            return ExecutionResult.Success(basketCheckoutMessage);
        }

        #endregion
    }
}


