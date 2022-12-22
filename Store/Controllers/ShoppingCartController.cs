using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Store.Models;
using Store.Models.Interfaces;
using System.Linq;
using Store.Infrastructure.Extensions;
using Store.Models.ViewModels;
using Xceed.Wpf.Toolkit;
using static System.Net.Mime.MediaTypeNames;

namespace Store.Controllers
{
    public class ShoppingCartController : Controller
    {
        private IProductRepository _repos;
        private ShoppingCart _cart;
        public ShoppingCartController(IProductRepository repos, ShoppingCart cart)
        {
            this._repos = repos;
            this._cart = cart;
        }
        public ViewResult Index(string _returnUrl)
        {
            return View(new ShoppingCartIndexViewModel { Cart = _cart, ReturnUrl = _returnUrl });
        }
        public RedirectToActionResult AddToCart(int _productId, string _returnUrl)
        {
            Product _product = _repos.Products.FirstOrDefault(el => el.Id == _productId);
            if (_product != null)
            {
                _cart.AddItem(_product,1);
            }
            return RedirectToAction("Index", new { _returnUrl });
        }
        public RedirectToActionResult RemoveFromCart(int _productId,string _returnUrl)
        {
            Product _product = _repos.Products.FirstOrDefault(el => el.Id == _productId);
            if (_product != null)
            {
                _cart.RemoveLine(_product);
            }
            return RedirectToAction("Index", new { _returnUrl });
        }
        private protected void SaveCart(ShoppingCart _cart)
        {
            HttpContext.Session.SetJson("ShoppingCart", _cart);
        }
        private ShoppingCart GetCart()
        {
            return HttpContext.Session.GetJson<ShoppingCart>("ShoppingCart") ?? new ShoppingCart();
        }
    }
}
