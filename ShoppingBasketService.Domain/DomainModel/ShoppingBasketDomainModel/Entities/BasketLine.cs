using Microservice.Framework.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingBasketService.Domain.DomainModel.ShoppingBasketDomainModel.Entities
{
    public class BasketLine : Entity<BasketLineId>
    {
        #region Properties

        public string EventId { get; set; }
        public int TicketAmount { get; set; }
        public int Price { get; set; }
        
        #endregion
    }
}
