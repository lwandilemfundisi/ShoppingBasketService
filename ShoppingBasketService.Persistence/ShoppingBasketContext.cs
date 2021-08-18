using ShoppingBasketService.Persistence.Mappings;
using Microsoft.EntityFrameworkCore;

namespace ShoppingBasketService.Persistence
{
    public class ShoppingBasketContext : DbContext
    {
        public ShoppingBasketContext(DbContextOptions<ShoppingBasketContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ShoppingBasketModelMap();
        }
    }
}
