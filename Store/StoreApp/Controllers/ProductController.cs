using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Store.Entities.Models;
using Store.Repositories;

namespace StoreApp.Controllers
{
    public class ProductController : Controller
    {
        
        public IEnumerable<Product> Index()
        {
            //Geriye bir değer döndürmek istediğimiz zaman Index end point ile
            //erişebiliriz.
            return new List<Product>()
            {
                new Product(){ProductId=1, ProductName="Computer", Price=1500}
            };
        }
        public IEnumerable<Product> SeedData()
        {
            //Database içerisindeki, verilere erişebilmek için kullanılabilir.
            var context = new RepositoryContext
            (
            new DbContextOptionsBuilder<RepositoryContext>()
            .UseSqlite("Data Source=C:\\.Net\\BTK\\BTKMVC\\ProductDb.db")
            .Options  
            );
            return context.Products;
        }
            
            // Dependncy Injection patern ile birlikte RepositoryContext Service 
            //ile birlikte RepositoryContext newleyerek göderecektir.
        private readonly RepositoryContext _context;
        public ProductController(RepositoryContext context)
        {
            _context= context;
        }
         public IEnumerable<Product> DependencyInjectionSeedData()
        {
            //Yukarıdaki patern kullanıldığından 
            //Database içerisindeki, verilere erişebiliyoruz.
            return _context.Products;
        }

        //View ile geri döndürmek istediğimiz zaman
        public IActionResult IndexView()
        {
            var model = _context.Products.ToList();
            return View(model);
        }

        public IActionResult GetProduct(int id)
        {
            Product product = _context.Products.First(p=>p.ProductId.Equals(id));
            return View(product);
        }
    }
}