using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Store.Models;
using Store.Models.Interfaces;
using System.Linq;
using Store.Infrastructure.Extensions;
using Store.Models.ViewModels;

namespace Store.Controllers
{
    public class ShoppingCartController : Controller
    {
        private IProductRepository _repos;
        public ShoppingCartController(IProductRepository repos)
        {
            this._repos = repos;
        }
        public ViewResult Index(string _returnUrl)
        {
            return View(new ShoppingCartIndexViewModel { Cart = GetCart(), ReturnUrl = _returnUrl });
        }
        public RedirectToActionResult AddToCart(int _productId, string _returnUrl)
        {
            Product _product = _repos.Products.FirstOrDefault(el => el.Id == _productId);
            if (_product != null)
            {
                ShoppingCart _cart = GetCart();
                _cart.AddItem(_product,1);
                SaveCart(_cart);
            }
            return RedirectToAction("Index", new { _returnUrl });
        }
        public RedirectToActionResult RemoveFromCart(int _productId,string _returnUrl)
        {
            Product _product = _repos.Products.FirstOrDefault(el => el.Id == _productId);
            if (_product != null)
            {
                ShoppingCart _cart = GetCart();
                _cart.RemoveLine(_product);
                SaveCart(_cart);
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
