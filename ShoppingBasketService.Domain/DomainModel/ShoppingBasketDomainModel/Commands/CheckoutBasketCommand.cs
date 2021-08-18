using AutoMapper;
using Microservice.Framework.Common;
using Microservice.Framework.Domain.Commands;
using Microservice.Framework.Domain.ExecutionResults;
using ShoppingBasketService.Domain.Application.Model;
using ShoppingBasketService.Domain.DomainModel.ShoppingBasketDomainModel.BusMessages;
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

        public CheckoutBasketCommandHandler(IMapper mapper)
        {
            _mapper = mapper;
        }
        
        #region Abstract Members

        public override Task<IExecutionResult> ExecuteAsync(
            Basket aggregate, 
            CheckoutBasketCommand command, 
            CancellationToken cancellationToken)
        {
            var basketCheckoutMessage = _mapper
                .Map<BasketCheckoutMessage>(command.BasketCheckoutApplicationModel);

            int total = 0;

            foreach (var b in aggregate.BasketLines)
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
                basketCheckoutMessage.BasketTotal = total - command.Coupon.Amount;
            }
            else
            {
                basketCheckoutMessage.BasketTotal = total;
            }

            aggregate.CheckoutBasket(basketCheckoutMessage);

            return Task.FromResult(ExecutionResult.Success(basketCheckoutMessage));
        }

        #endregion
    }
}


