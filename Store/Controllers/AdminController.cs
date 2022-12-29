using Microsoft.AspNetCore.Mvc;
using Store.Models;
using Store.Models.Interfaces;
using System;
using System.Linq;

namespace Store.Controllers
{
    public class AdminController : Controller
    {
        private IProductRepository _repos;
        public AdminController(IProductRepository repos)
        {
            this._repos = repos;
        }
        public ViewResult Index() => View(_repos.Products);
        [HttpPost]
        public IActionResult RemoveProduct(int productId)
        {
            Product _product = _repos.RemoveProduct(productId);
            if(_product !=null)
            {
                TempData["message"] = $"{_product.Name} was deleted";
            }
            return RedirectToAction("Index");
        }
        public ViewResult Edit(int productId)
        {
            return View(_repos.Products.FirstOrDefault(el => el.Id == productId));
        }
        [HttpPost]
        public IActionResult Edit(Product _product)
        {
            if(ModelState.IsValid)
            {
                _repos.SaveProduct(_product);
                TempData["message"] = $"{_product.Name} has been saved";
                return RedirectToAction("Index");
            }
            else
            {
                return View("Edit",_product);
            }
        }
        [HttpGet]
        public ViewResult Create()
        {
            return View("Edit", new Product());
        }
    }
}
