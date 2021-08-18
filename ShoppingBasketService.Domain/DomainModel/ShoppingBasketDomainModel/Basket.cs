using Microservice.Framework.Common;
using Microservice.Framework.Domain.Aggregates;
using ShoppingBasketService.Domain.DomainModel.ShoppingBasketDomainModel.BusMessages;
using ShoppingBasketService.Domain.DomainModel.ShoppingBasketDomainModel.Entities;
using ShoppingBasketService.Domain.DomainModel.ShoppingBasketDomainModel.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingBasketService.Domain.DomainModel.ShoppingBasketDomainModel
{
    public class Basket : AggregateRoot<Basket, BasketId>
    {
        #region Constructors

        public Basket()
            : base(null)
        {

        }

        public Basket(BasketId id)
            : base(id)
        {

        }

        #endregion

        #region Properties

        public string UserId { get; set; }

        public ICollection<BasketLine> BasketLines { get; set; }

        #endregion

        #region Methods

        public void CreateBasket(string userId)
        {
            UserId = userId;
            Emit(new CreatedBasketEvent(userId));
        }

        public void CheckoutBasket(BasketCheckoutMessage basketCheckoutMessage)
        {
            Emit(new CheckedoutBasketEvent(basketCheckoutMessage));
        }

        public BasketLine AddBasketLine(string eventId, int price, int ticketAmount)
        {
            if(!BasketLines.HasItems())
            {
                BasketLines = new List<BasketLine>();
            }

            var basketLine = new BasketLine
            {
                Id = BasketLineId.New,
                EventId = eventId,
                Price = price,
                TicketAmount = ticketAmount
            };

            BasketLines.Add(basketLine);

            Emit(new AddedBasketLineEvent(basketLine));

            return basketLine;
        }

        public void DeleteBasketLine(BasketLineId basketLineId)
        {
            BasketLines.Remove(new BasketLine { Id = basketLineId });

            Emit(new DeletedBasketLineEvent(basketLineId));
        }

        public BasketLine UpdateBasketLine(BasketLineId basketLineId, int ticketAmount)
        {
            var basketLine = BasketLines.First(bl => bl.Id == basketLineId);

            basketLine.TicketAmount = ticketAmount;

            Emit(new UpdatedBasketLineEvent(basketLine));

            return basketLine;
        }

        #endregion

    }
}
