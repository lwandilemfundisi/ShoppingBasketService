using Microservice.Framework.Persistence.EFCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Microsoft.Extensions.Configuration;
using System;

namespace ShoppingBasketService.Persistence
{
    public class ShoppingBasketContextProvider : IDbContextProvider<ShoppingBasketContext>, IDisposable
    {
        private readonly DbContextOptions<ShoppingBasketContext> _options;

        public ShoppingBasketContextProvider(IConfiguration configuration)
        {
            _options = new DbContextOptionsBuilder<ShoppingBasketContext>()
                .UseSqlServer(configuration["DataConnection:Database"])
                .Options;
        }

        public ShoppingBasketContext CreateContext()
        {
            return new ShoppingBasketContext(_options);
        }

        public void Dispose()
        {
        }
    }
}
