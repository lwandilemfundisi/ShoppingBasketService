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
    [EventVersion("AddedBasketLineEvent", 1)]
    public class AddedBasketLineEvent : AggregateEvent<Basket, BasketId>
    {
        public AddedBasketLineEvent(BasketLine basketLine)
        {
            BasketLine = basketLine;
        }

        public BasketLine BasketLine { get; }
    }
}
