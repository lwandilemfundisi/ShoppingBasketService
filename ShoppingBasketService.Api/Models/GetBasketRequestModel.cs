using ShoppingBasketService.Domain.DomainModel.ShoppingBasketDomainModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShoppingBasketService.Api.Models
{
    public class GetBasketRequestModel
    {
        public BasketId BasketId { get; set; }

        public string UserId { get; set; }
    }
}
