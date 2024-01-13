using Entities.Models;
using Microsoft.EntityFrameworkCore;
using Store.Entities.Models;
namespace Store.Repositories
{
    public class RepositoryContext : DbContext
    {
        public DbSet<Product> Products { get; set; }

        public DbSet<Category> Categories { get; set; }

        public RepositoryContext(DbContextOptions<RepositoryContext> options) : base(options)
        {

        }

        /*
        Modeller oluşturulurken
        Protected: access modify olarak kullanarak ilgili sınıfın base classına
        çağrışımda bulunduğumuzu anlıyoruz.
        Override: yani DBContext sınıfında OnMoldeCreating metodunun virtual olduğunu
        düşünüyoruz.
        ModelBuilder: Sınıf üzerinde bu işlemin yapıldığını söylüyorum.
        */
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);//Base deki OnModelCreating metodunu çağırır.

            modelBuilder.Entity<Product>()
            .HasData(
                new Product { ProductId = 1, ProductName = "Computer", Price = 10_000 },
                new Product { ProductId = 2, ProductName = "Keyboard", Price = 20_000 },
                new Product { ProductId = 3, ProductName = "Mouse", Price = 3_000 },
                new Product { ProductId = 4, ProductName = "Monitor", Price = 40_000 },
                new Product { ProductId = 5, ProductName = "Deck", Price = 5_500 }
            );

            modelBuilder.Entity<Category>()
           .HasData(
               new Category { CategoryId = 1, CategoryName = "Book" },
               new Category { CategoryId = 2, CategoryName = "Electronic" }
           );
            /*
            Bu örnekte, Product entity'sine ait beş örnek eklenmiştir. Bu örnekler, uygulama
            ilk çalıştığında veritabanına eklenir. Böylece, uygulama ilk kez çalıştığında,
            veritabanı başlangıç ​​verileriyle doldurulmuş olur.
            */

        }

    }
}
