using Microservice.Framework.Domain;
using Microservice.Framework.Domain.Extensions;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using ShoppingBasketService.Domain.Extensions;
using ShoppingBasketService.Domain.ExternalServices;
using System;
using System.Reflection;

namespace ShoppingBasketService.Domain
{
    public static class ShoppingBasketServiceDomainExtensions
    {
        public static Assembly Assembly { get; } 
            = typeof(ShoppingBasketServiceDomainExtensions).Assembly;

        public static IDomainContainer ConfigureShoppingBasketServiceDomain(
            this IServiceCollection services,
            IConfiguration configuration = null)
        {
            return DomainContainer.New(services)
                .AddDefaults(Assembly)
                .AddExternalService<IDiscountService, DiscountService>(httpclient =>
                {
                    httpclient.BaseAddress = new Uri(
                        configuration["ExternalServices:DiscountServiceApi"]);
                });
        }
    }
}
