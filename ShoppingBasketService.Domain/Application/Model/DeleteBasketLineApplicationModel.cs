using ShoppingBasketService.Domain.DomainModel.ShoppingBasketDomainModel;
using ShoppingBasketService.Domain.DomainModel.ShoppingBasketDomainModel.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingBasketService.Domain.Application.Model
{
    public class DeleteBasketLineApplicationModel
    {
        public BasketId BasketId { get; set; }

        public BasketLineId BasketLineId { get; set; }
    }
}
