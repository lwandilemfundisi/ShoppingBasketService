using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingBasketService.Domain.ExternalServices.Models.ExternalRequestModels
{
    public class GetCouponExternalRequestModel
    {
        public string CouponId { get; set; }

        public string UserId { get; set; }
    }
}
