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
    [EventVersion("UpdatedBasketLineEvent", 1)]
    public class UpdatedBasketLineEvent : AggregateEvent<Basket, BasketId>
    {
        public UpdatedBasketLineEvent(BasketLine basketLine)
        {
            BasketLine = basketLine;
        }

        public BasketLine BasketLine { get; }
    }
}
