using Microsoft.AspNetCore.Mvc;
using Services.Contracts;
using Entities.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using Entities.Dtos;
using System.Runtime.CompilerServices;

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
            // ViewBag.Categories = _manager.CategoryService.GetAllCategories(false);
            //2.Yol dinamik tag helpers ile
            ViewBag.Categories = GetCategoriesSelectList();
            return View();
        }

        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([FromForm] ProductDtoForInsertion productDto,IFormFile file)
        {
            if (ModelState.IsValid)
            {
                string path = Path.Combine(Directory.GetCurrentDirectory(),"wwwroot","images",file.FileName);
                using (var stream = new FileStream(path,FileMode.Create))
                {
                    await file.CopyToAsync(stream);
                }
                productDto.ImageUrl = string.Concat("/images/",file.FileName);
                _manager.ProductService.CreateProduct(productDto);
                return RedirectToAction("Index");
            }
            return View();
        }


        public IActionResult Update([FromRoute(Name ="id")] int id)
        {
            ViewBag.Categories = GetCategoriesSelectList();
            var model = _manager.ProductService.GetOneProductForUpdate(id,false);
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Update([FromForm] ProductDtoForUpdate productDto, IFormFile file)
        {
              if (ModelState.IsValid)
            {
                string path = Path.Combine(Directory.GetCurrentDirectory(),"wwwroot","images",file.FileName);
                using (var stream = new FileStream(path,FileMode.Create))
                {
                    await file.CopyToAsync(stream);
                }
                productDto.ImageUrl = string.Concat("/images/",file.FileName);
                _manager.ProductService.UpdateOneProduct(productDto);
                return RedirectToAction("Index");
            }
            return View();
        }

        public IActionResult Delete([FromRoute(Name ="id")] int id)
        {
            _manager.ProductService.DeleteOneProduct(id);
            return RedirectToAction("Index");
        }

        private SelectList GetCategoriesSelectList()
        {
            return new SelectList(_manager.CategoryService.GetAllCategories(false),
            "CategoryId",
            "CategoryName",
            "1");
        }

    }
}