using System.Reflection;
using Entities.Models;
using Microsoft.EntityFrameworkCore;

namespace Repositories
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
            //Entity Configurationları çağırmak için;
            //1.yol 
            // modelBuilder.ApplyConfiguration(new ProductConfig());
            // modelBuilder.ApplyConfiguration(new CategoryConfig());

            //2.yol
            //İlgili ifadenin Config dosyasını dinamik olarak görmektedir.
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
            /*
            Bu örnekte, Product entity'sine ait beş örnek eklenmiştir. Bu örnekler, uygulama
            ilk çalıştığında veritabanına eklenir. Böylece, uygulama ilk kez çalıştığında,
            veritabanı başlangıç ​​verileriyle doldurulmuş olur.
            */

        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.EnableSensitiveDataLogging();
        }   


    }
}
