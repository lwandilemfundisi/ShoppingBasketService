using ShoppingBasketService.Domain.DomainModel.ShoppingBasketDomainModel;
using ShoppingBasketService.Domain.DomainModel.ShoppingBasketDomainModel.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShoppingBasketService.Api.Models
{
    public class BasketLinesDtoModel
    {
        public IList<BasketLineDtoModel> BasketLines { get; set; }
    }

    public class BasketLineDtoModel
    {
        public BasketLineId BasketLineId { get; set; }
        public BasketId BasketId { get; set; }
        public string EventId { get; set; }
        public int Price { get; set; }
        public int TicketAmount { get; set; }
    }
}
