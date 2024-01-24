using Microsoft.AspNetCore.Mvc;
using Services.Contracts;
using Entities.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using Entities.Dtos;

namespace StoreApp.Areas.Admin.Controllers
{   
    [Area("Admin")]

    public class ProductController : Controller
    {
        private readonly IServiceManager _manager;

        public ProductController(IServiceManager manager)
        {
            _manager = manager;
        }

        public IActionResult Index()
        {
            var model = _manager.ProductService.GetAllProducts(false); 
            return View(model);
        }

        public IActionResult Create()
        {
            //1.Yol dinamik
            ViewBag.Categories = _manager.CategoryService.GetAllCategories(false);
            //2.Yol dinamik tag helpers ile
            ViewBag.Categories =
            new SelectList(_manager.CategoryService.GetAllCategories(false),"CategoryId","CategoryName","1");
            
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([FromForm] ProductDtoForInsertion productDto)
        {
            if (ModelState.IsValid)
            {
                _manager.ProductService.CreateProduct(productDto);
                return RedirectToAction("Index");
            }
            return View();
        }


        public IActionResult Update([FromRoute(Name ="id")] int id)
        {
            var model = _manager.ProductService.GetOneProduct(id,false);
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Update(Product product)
        {
            if (ModelState.IsValid)
            {
                _manager.ProductService.UpdateOneProduct(product);
                return RedirectToAction("Index");
            }
            return View();
        }

        public IActionResult Delete([FromRoute(Name ="id")] int id)
        {
            _manager.ProductService.DeleteOneProduct(id);
            return RedirectToAction("Index");
        }

    }
}