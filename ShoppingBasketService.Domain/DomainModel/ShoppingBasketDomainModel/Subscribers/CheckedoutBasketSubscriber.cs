using Microservice.Framework.Domain.Events;
using Microservice.Framework.Domain.Jobs;
using Microservice.Framework.Domain.Subscribers;
using ShoppingBasketService.Domain.DomainModel.ShoppingBasketDomainModel.Events;
using ShoppingBasketService.Domain.DomainModel.ShoppingBasketDomainModel.Jobs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ShoppingBasketService.Domain.DomainModel.ShoppingBasketDomainModel.Subscribers
{
    public class CheckedoutBasketSubscriber
        : ISubscribeSynchronousTo<Basket, BasketId, CheckedoutBasketEvent>
    {
        private readonly IJobScheduler _jobScheduler;

        public CheckedoutBasketSubscriber(
            IJobScheduler jobScheduler)
        {
            _jobScheduler = jobScheduler;
        }

        public Task HandleAsync(
            IDomainEvent<Basket, BasketId, CheckedoutBasketEvent> domainEvent, 
            CancellationToken cancellationToken)
        {
            var job = new PublishBasketCheckoutMessageJob(
                domainEvent.AggregateEvent.BasketCheckoutMessage);

            return _jobScheduler.ScheduleNowAsync(job, cancellationToken);
        }
    }
}
