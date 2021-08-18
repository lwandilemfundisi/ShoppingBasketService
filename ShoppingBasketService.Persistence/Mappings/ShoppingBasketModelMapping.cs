using ShoppingBasketService.Persistence.ValueObjectConverters;
using Microsoft.EntityFrameworkCore;
using ShoppingBasketService.Domain.DomainModel.ShoppingBasketDomainModel;
using ShoppingBasketService.Domain.DomainModel.ShoppingBasketDomainModel.Entities;

namespace ShoppingBasketService.Persistence.Mappings
{
    public static class ShoppingBasketModelMapping
    {
        public static ModelBuilder ShoppingBasketModelMap(this ModelBuilder modelBuilder)
        {
            modelBuilder
            .Entity<Basket>()
            .Property(o => o.Id)
            .HasConversion(new SingleValueObjectIdentityValueConverter<BasketId>());

            modelBuilder
            .Entity<BasketLine>()
            .Property(o => o.Id)
            .HasConversion(new SingleValueObjectIdentityValueConverter<BasketLineId>());

            modelBuilder
                .Entity<BasketLine>()
                .HasOne<Basket>()
                .WithMany(c => c.BasketLines);

            return modelBuilder;
        }
    }
}
