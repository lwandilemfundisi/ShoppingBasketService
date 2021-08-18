using Microservice.Framework.Domain.Events;
using Microservice.Framework.Domain.Events.AggregateEvents;
using ShoppingBasketService.Domain.DomainModel.ShoppingBasketDomainModel.BusMessages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingBasketService.Domain.DomainModel.ShoppingBasketDomainModel.Events
{
    [EventVersion("CheckedoutBasketEvent", 1)]
    public class CheckedoutBasketEvent : AggregateEvent<Basket, BasketId>
    {
        #region Constructors

        public CheckedoutBasketEvent(BasketCheckoutMessage basketCheckoutMessage)
        {
            BasketCheckoutMessage = basketCheckoutMessage;
        }

        #endregion

        #region Properties

        public BasketCheckoutMessage BasketCheckoutMessage { get; }

        #endregion
    }
}
