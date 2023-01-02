using Microservice.Framework.Domain.Jobs;
using Microsoft.Extensions.DependencyInjection;
using ShoppingBasketService.Domain.DomainModel.ShoppingBasketDomainModel.BusMessages;
using ShoppingBasketService.Integration.MessageBus;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ShoppingBasketService.Domain.DomainModel.ShoppingBasketDomainModel.Jobs
{
    [JobVersion("PublishBasketCheckoutMessageJob", 1)]
    public class PublishBasketCheckoutMessageJob : IJob
    {
        public PublishBasketCheckoutMessageJob(
            BasketCheckoutMessage basketCheckoutMessage)
        {
            BasketCheckoutMessage = basketCheckoutMessage;
        }

        public BasketCheckoutMessage BasketCheckoutMessage { get; }

        public async Task ExecuteAsync(
            IServiceProvider serviceProvider, 
            CancellationToken cancellationToken)
        {
            var messageBus = serviceProvider.GetRequiredService<IMessageBus>();
            await messageBus.PublishMessage(BasketCheckoutMessage, "checkout");
        }
    }
}
