using Microservice.Framework.Domain.Events;
using Microservice.Framework.Domain.Events.AggregateEvents;
using ShoppingBasketService.Domain.DomainModel.ShoppingBasketDomainModel.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingBasketService.Domain.DomainModel.ShoppingBasketDomainModel.Events
{
    [EventVersion("DeletedBasketLineEvent", 1)]
    public class DeletedBasketLineEvent : AggregateEvent<Basket, BasketId>
    {
        public DeletedBasketLineEvent(BasketLineId basketLineId)
        {
            BasketLineId = basketLineId;
        }

        public BasketLineId BasketLineId { get; }
    }
}
