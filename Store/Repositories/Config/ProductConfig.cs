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
                new Product { ProductId = 1, CategoryId = 1, ImageUrl="/images/1.jpg", ProductName = "Keyboard", Price = 20_000 },
                new Product { ProductId = 2, CategoryId = 1, ImageUrl="/images/2.jpg", ProductName = "Mouse", Price = 3_000 },
                new Product { ProductId = 3, CategoryId = 2, ImageUrl="/images/3.jpg", ProductName = "Monitor", Price = 40_000 },
                new Product { ProductId = 4, CategoryId = 2, ImageUrl="/images/4.jpg", ProductName = "Deck", Price = 5_500 },
                new Product { ProductId = 5, CategoryId = 2, ImageUrl="/images/5.jpg", ProductName = "Computer", Price = 12_000 },
                new Product { ProductId = 6, CategoryId = 2, ImageUrl="/images/6.jpg", ProductName = "Anker Soundcore", Price = 5_250 },
                new Product { ProductId = 7, CategoryId = 2, ImageUrl="/images/7.jpg",ProductName = "Steel Series", Price = 1_100 }
            );
        }
    }
}