using Microsoft.AspNetCore.Mvc;
using Store.Models.Interfaces;
using System.Linq;

namespace Store.Components
{
    public class NavigationMenuViewComponent : ViewComponent
    {
        private IProductRepository _repos;
        public NavigationMenuViewComponent(IProductRepository repos)
        {
            this._repos = repos;
        }
        public IViewComponentResult Invoke()
        {
            ViewBag.SelectedCategory = RouteData?.Values["category"];
            return View(_repos.Products.Select(x => x.Category).Distinct().OrderBy(x => x));
        }
    }
}
