using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Store.Models;
using Store.Models.Interfaces;
using System.Linq;

namespace Store.Controllers
{
    public class OrderController : Controller
    {
        private IOrderRepository _repos;
        private ShoppingCart _cart;
        public OrderController(IOrderRepository repos, ShoppingCart cart)
        {
            this._repos = repos;
            this._cart = cart;
        }
        [Authorize(Roles = "Admin")]
        public ViewResult List() 
        {
            return View(_repos.Orders.Where(el => !el.Shipped));    
        }
        [Authorize]
        [HttpPost]
        public IActionResult MarkShipped(int orderId)
        {
            Order order = _repos.Orders.FirstOrDefault(el=>el.Id == orderId);
            if(order != null)
            {
                order.Shipped = true;
                _repos.SaveOrder(order);
            }
            return RedirectToAction(nameof(List));
        }
        public IActionResult Checkout() => View(new Order());
        [HttpPost]
        public IActionResult Checkout(Order order)
        {
            if(_cart.Lines.Count() == 0)
            {
                ModelState.AddModelError("","Sorry, your cart is empty");
            }
            if(ModelState.IsValid)
            {
                order.Lines = _cart.Lines.ToArray();
                _repos.SaveOrder(order);
                return RedirectToAction(nameof(Completed));
            }
            else
            {
                return View(order);
            }
        }
        public ViewResult Completed()
        {
            _cart?.Clear();
            return View();
        }
    }
}
