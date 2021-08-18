using ShoppingBasketService.Domain.DomainModel.ShoppingBasketDomainModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShoppingBasketService.Api.Models
{
    public class AddBasketLineRequestModel
    {
        public BasketId BasketId { get; set; }

        public string EventId { get; set; }

        public int Price { get; set; }

        public int TicketAmount { get; set; }
    }
}
