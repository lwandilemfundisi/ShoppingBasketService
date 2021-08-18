using Microservice.Framework.Domain.Commands;
using Microservice.Framework.Domain.ExecutionResults;
using ShoppingBasketService.Domain.DomainModel.ShoppingBasketDomainModel.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ShoppingBasketService.Domain.DomainModel.ShoppingBasketDomainModel.Commands
{
    public class CreateBasketCommand 
        : Command<Basket, BasketId>
    {
        #region Constructors

        public CreateBasketCommand(
            BasketId id,
            string userId)
            : base(id)
        {
            UserId = userId;
        }

        #endregion

        #region Properties

        public string UserId { get; }

        #endregion
    }

    public class AddBasketCommandHandler
        : CommandHandler<Basket, BasketId, CreateBasketCommand>
    {
        #region Abstract Members

        public override Task<IExecutionResult> ExecuteAsync(
            Basket aggregate, 
            CreateBasketCommand command, 
            CancellationToken cancellationToken)
        {
            aggregate.CreateBasket(command.UserId);
            return Task.FromResult(ExecutionResult.Success(aggregate));
        }

        #endregion
    }
}
