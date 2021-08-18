using ShoppingBasketService.Domain.ExternalServices.Models.ExternalDtoModels;
using ShoppingBasketService.Domain.ExternalServices.Models.ExternalRequestModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ShoppingBasketService.Domain.ExternalServices
{
    public interface IDiscountService
    {
        Task<CouponExternalDtoModel> GetCoupon(
            GetCouponExternalRequestModel model, 
            CancellationToken cancellationToken);
    }
}
