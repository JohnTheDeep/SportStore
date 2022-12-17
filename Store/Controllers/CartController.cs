using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Store.Models;
using Store.Models.Interfaces;
using System.Linq;
using Newtonsoft.Json;
using Store.Infrastructure.Extensions;

namespace Store.Controllers
{
    public class CartController : Controller
    {
        private IProductRepository _repos;
        public CartController(IProductRepository repos)
        {
            this._repos = repos;
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
