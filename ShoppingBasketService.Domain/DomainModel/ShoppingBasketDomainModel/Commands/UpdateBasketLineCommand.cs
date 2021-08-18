using Microservice.Framework.Domain.Commands;
using Microservice.Framework.Domain.ExecutionResults;
using ShoppingBasketService.Domain.Application.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ShoppingBasketService.Domain.DomainModel.ShoppingBasketDomainModel.Commands
{
    public class UpdateBasketLineCommand 
        : Command<Basket, BasketId>
    {

        #region Constructors
        public UpdateBasketLineCommand(
            BasketId aggregateId, 
            UpdateBasketLineApplicationModel updateBasketLineApplicationModel) 
            : base(aggregateId)
        {
            UpdateBasketLineApplicationModel = updateBasketLineApplicationModel;
        }

        #endregion

        #region Properties

        public UpdateBasketLineApplicationModel UpdateBasketLineApplicationModel { get; }

        #endregion
    }

    public class UpdateBasketLineCommandHandler
        : CommandHandler<Basket, BasketId, UpdateBasketLineCommand>
    {
        #region Virtual Methods

        public override Task<IExecutionResult> ExecuteAsync(
            Basket aggregate,
            UpdateBasketLineCommand command, 
            CancellationToken cancellationToken)
        {
            var updatedBasketLine = aggregate.UpdateBasketLine(
                command.UpdateBasketLineApplicationModel.BasketLineId, 
                command.UpdateBasketLineApplicationModel.TicketAmount);

            return Task.FromResult(ExecutionResult.Success(updatedBasketLine));
        }

        #endregion
    }
}
