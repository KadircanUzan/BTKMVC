using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Entities.Models;

namespace Repositories.Config
{
    public class ProductConfig : IEntityTypeConfiguration<Product>
    {
       
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.HasKey(p=>p.ProductId);

            builder.Property(p=>p.ProductName).IsRequired();
            builder.Property(p=>p.Price).IsRequired();

            builder.HasData(
                new Product { ProductId = 2, CategoryId = 1, ProductName = "Keyboard", Price = 20_000 },
                new Product { ProductId = 3, CategoryId = 1, ProductName = "Mouse", Price = 3_000 },
                new Product { ProductId = 4, CategoryId = 2, ProductName = "Monitor", Price = 40_000 },
                new Product { ProductId = 5, CategoryId = 2, ProductName = "Deck", Price = 5_500 },
                new Product { ProductId = 1, CategoryId = 2, ProductName = "Computer", Price = 10_000 },
                new Product { ProductId = 1, CategoryId = 2, ProductName = "Computer", Price = 10_000 },
                new Product { ProductId = 1, CategoryId = 2, ProductName = "Computer", Price = 10_000 }
            );
        }
    }
}