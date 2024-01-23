using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Repositories.Contracts;
using Services.Contracts;
using Entities.Models;
using Repositories;

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

        #region RepositoryContext sınıfı DI olarak kullanılırken;
        //// Dependncy Injection patern ile birlikte RepositoryContext Service 
        ////ile birlikte RepositoryContext newleyerek göderecektir.
        //private readonly RepositoryContext _context;
        //public ProductController(RepositoryContext context)
        //{
        //    _context = context;
        //}
        //public IEnumerable<Product> DependencyInjectionSeedData()
        //{
        //    //Yukarıdaki patern kullanıldığından 
        //    //Database içerisindeki, verilere erişebiliyoruz.
        //    return _context.Products;
        //}

        ////View ile geri döndürmek istediğimiz zaman
        //public IActionResult IndexView()
        //{
        //    var model = _context.Products.ToList();
        //    return View(model);
        //}

        //public IActionResult GetProduct(int id)
        //{
        //    Product product = _context.Products.First(p => p.ProductId.Equals(id));
        //    return View(product);
        //} 
        #endregion

        #region Repositories katmanı geldiğinde, Service katmanı yokken;
        //private readonly IRepositoryManager _manager;

        //public ProductController(IRepositoryManager manager)
        //{
        //    _manager = manager;
        //}

        //public IActionResult IndexView()
        //{
        //    var model = _manager.Product.GetAllProducts(false);
        //    return View(model);
        //}
        //public IActionResult GetProduct(int id)
        //{
        //    var product = _manager.Product.GetOneProduct(id, false);
        //    return View(product);
        //} 
        #endregion

        private readonly IServiceManager _manager;

        public ProductController(IServiceManager manager)
        {
            _manager = manager;
        }

        public IActionResult IndexView()
        {
            var model = _manager.ProductService.GetAllProducts(false);
            return View(model);
        }
        //Id'nin route dan geldiğini belirtmek için FromRoute kullanıyoruz.
        public IActionResult GetProduct([FromRoute(Name ="id")] int id)
        {
            var product = _manager.ProductService.GetOneProduct(id, false);
            return View(product);
        }
    }
}