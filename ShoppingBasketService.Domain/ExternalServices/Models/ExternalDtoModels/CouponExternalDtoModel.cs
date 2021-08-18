using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingBasketService.Domain.ExternalServices.Models.ExternalDtoModels
{
    public class CouponExternalDtoModel
    {
        public string CouponId { get; set; }
        public string Code { get; set; }
        public int Amount { get; set; }
        public bool AlreadyUsed { get; set; }
    }
}
