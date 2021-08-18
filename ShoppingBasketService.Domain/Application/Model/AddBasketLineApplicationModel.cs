using ShoppingBasketService.Domain.DomainModel.ShoppingBasketDomainModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingBasketService.Domain.Application.Model
{
    public class AddBasketLineApplicationModel
    {
        public BasketId BasketId { get; set; }

        public string EventId { get; set; }

        public int Price { get; set; }

        public int TicketAmount { get; set; }
    }
}
