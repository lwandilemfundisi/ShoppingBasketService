using ShoppingBasketService.Domain.Extensions;
using ShoppingBasketService.Domain.ExternalServices.Models.ExternalDtoModels;
using ShoppingBasketService.Domain.ExternalServices.Models.ExternalRequestModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ShoppingBasketService.Domain.ExternalServices
{
    public class DiscountService : IDiscountService
    {
        private readonly HttpClient _httpClient;

        public DiscountService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<CouponExternalDtoModel> GetCoupon(
            GetCouponExternalRequestModel model, 
            CancellationToken cancellationToken)
        {
            var response = await _httpClient.GetAsync(
                $"/discount/getCoupon?couponId={model.CouponId}&userId={model.UserId}",
                cancellationToken);

            return await response.As<CouponExternalDtoModel>();
        }
    }
}
