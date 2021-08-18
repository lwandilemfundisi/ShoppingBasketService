using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System;
using System.IO;

namespace ShoppingBasketService.Persistence
{
    public class ShoppingBasketContextFactory : IDesignTimeDbContextFactory<ShoppingBasketContext>
    {
        public ShoppingBasketContext CreateDbContext(string[] args)
        {
            var envName = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT");

            var configuration = new ConfigurationBuilder()
                .SetBasePath(Path.Combine(Directory.GetCurrentDirectory()))
                .AddJsonFile("appsettings.json", optional: false)
                .AddJsonFile($"appsettings.{envName}.json", optional: false)
                .Build();

            var optionsBuilder = new DbContextOptionsBuilder<ShoppingBasketContext>();
            optionsBuilder.UseSqlServer(configuration["DataConnection:Database"]);

            return new ShoppingBasketContext(optionsBuilder.Options);
        }
    }
}
