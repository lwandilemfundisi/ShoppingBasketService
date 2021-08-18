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
    [EventVersion("CreatedBasketEvent", 1)]
    public class CreatedBasketEvent : AggregateEvent<Basket, BasketId>
    {
        public CreatedBasketEvent(string userId)
        {
            UserId = userId;
        }

        public string UserId { get; }
    }
}
