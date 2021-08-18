using Microservice.Framework.Domain.ExecutionResults;
using ShoppingBasketService.Domain.Application.Model;
using ShoppingBasketService.Domain.DomainModel.ShoppingBasketDomainModel;
using ShoppingBasketService.Domain.DomainModel.ShoppingBasketDomainModel.BusMessages;
using ShoppingBasketService.Domain.DomainModel.ShoppingBasketDomainModel.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ShoppingBasketService.Domain.Application
{
    public interface IShoppingBasketService
    {
        Task<Basket> CreateBasket(
            string userId, 
            CancellationToken cancellationToken);

        Task<IExecutionResult> CheckoutBasket(
            BasketCheckoutApplicationModel basketCheckoutApplicationModel, 
            CancellationToken cancellationToken);
        Task<Basket> GetBasket(
            BasketId basketId, 
            string userId, 
            CancellationToken none);
        Task<IExecutionResult> AddBasketLine(
            BasketId basketId,
            AddBasketLineApplicationModel addBasketLineApplicationModel, 
            CancellationToken none);
        Task<BasketLine> GetBasketLine(
            BasketId basketId, 
            BasketLineId basketLineId, 
            CancellationToken none);
        Task<IExecutionResult> UpdateBasketLine(
            BasketId basketId, 
            UpdateBasketLineApplicationModel updateBasketLineApplicationModel, 
            CancellationToken none);
        Task<IExecutionResult> DeleteBasketLine(
            BasketId basketId, 
            DeleteBasketLineApplicationModel deleteBasketLineApplicationModel, 
            CancellationToken none);
    }
}
