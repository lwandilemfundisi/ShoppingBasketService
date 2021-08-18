using ShoppingBasketService.Domain.DomainModel.ShoppingBasketDomainModel;
using ShoppingBasketService.Domain.DomainModel.ShoppingBasketDomainModel.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShoppingBasketService.Api.Models
{
    public class UpdateBasketLineRequestModel
    {
        public BasketId BasketId { get; set; }

        public BasketLineId BasketLineId { get; set; }
        public int TicketAmount { get; set; }
    }
}
