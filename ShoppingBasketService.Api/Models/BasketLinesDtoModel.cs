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
        public BasketLineId Id { get; set; }
        public BasketId BasketId { get; set; }
        public string EventName { get; set; }
        public string Date { get; set; }
        public decimal TicketPrice { get; set; }
        public int Quantity { get; set; }
        public int Total { get; set; }
    }
}
