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
    public class AddBasketLineCommand 
        : Command<Basket, BasketId>
    {

        #region Constructors
        public AddBasketLineCommand(
            BasketId aggregateId, 
            AddBasketLineApplicationModel addBasketLineApplicationModel) 
            : base(aggregateId)
        {
            AddBasketLineApplicationModel = addBasketLineApplicationModel;
        }

        #endregion

        #region Properties

        public AddBasketLineApplicationModel AddBasketLineApplicationModel { get; }

        #endregion
    }

    public class AddBasketLineCommandHandler
        : CommandHandler<Basket, BasketId, AddBasketLineCommand>
    {
        #region Virtual Methods

        public override Task<IExecutionResult> ExecuteAsync(
            Basket aggregate, 
            AddBasketLineCommand command, 
            CancellationToken cancellationToken)
        {
            var addedBasketLine = aggregate.AddBasketLine(
                command.AddBasketLineApplicationModel.EventId, 
                command.AddBasketLineApplicationModel.Price, 
                command.AddBasketLineApplicationModel.TicketAmount);

            return Task.FromResult(ExecutionResult.Success(addedBasketLine));
        }

        #endregion
    }
}
