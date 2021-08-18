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
    public class DeleteBasketLineCommand
        : Command<Basket, BasketId>
    {

        #region Constructors
        public DeleteBasketLineCommand(
            BasketId aggregateId,
            DeleteBasketLineApplicationModel deleteBasketLineApplicationModel)
            : base(aggregateId)
        {
            DeleteBasketLineApplicationModel = deleteBasketLineApplicationModel;
        }

        #endregion

        #region Properties

        public DeleteBasketLineApplicationModel DeleteBasketLineApplicationModel { get; }

        #endregion
    }

    public class DeleteBasketLineCommandHandler
        : CommandHandler<Basket, BasketId, DeleteBasketLineCommand>
    {
        #region Virtual Methods

        public override Task<IExecutionResult> ExecuteAsync(
            Basket aggregate,
            DeleteBasketLineCommand command,
            CancellationToken cancellationToken)
        {
            aggregate.DeleteBasketLine(command.DeleteBasketLineApplicationModel.BasketLineId);

            return Task.FromResult(ExecutionResult.Success());
        }

        #endregion
    }
}
