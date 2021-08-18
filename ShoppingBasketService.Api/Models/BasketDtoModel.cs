using ShoppingBasketService.Domain.DomainModel.ShoppingBasketDomainModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShoppingBasketService.Api.Models
{
    public class BasketDtoModel
    {
        public BasketId tId { get; set; }
        public string UserId { get; set; }
        public int NumberOfItems { get; set; }
        public string CouponId { get; set; }
    }
}
