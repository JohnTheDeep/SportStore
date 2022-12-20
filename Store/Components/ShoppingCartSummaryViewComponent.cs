using Microsoft.AspNetCore.Mvc;
using Store.Models;

namespace Store.Components
{
    public class ShoppingCartSummaryViewComponent : ViewComponent
    {
        private ShoppingCart _cart;
        public ShoppingCartSummaryViewComponent(ShoppingCart cart)
        {
            this._cart = cart;
        }
        public IViewComponentResult Invoke()
        {
            return View(_cart);     
        }
    }
}
