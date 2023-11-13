using Microsoft.EntityFrameworkCore;

namespace StoreApp.Models
{
    public class RepositoryContext:DbContext
    {
        public DbSet<Product> Products { get; set; }

        public RepositoryContext(DbContextOptions<RepositoryContext> options):base(options)
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
            // modelBuilder.Entity<Product>().HasData()

        }

    }
}