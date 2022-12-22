using Microsoft.AspNetCore.Mvc;
using Store.Infrastructure.Extensions;
using Store.Models;
using Store.Models.Interfaces;
using Store.Models.ViewModels;
using System.Linq;
namespace Store.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductRepository _repository;
        public int PageSize { get; set; } = 20;
        public ProductController(IProductRepository repository)
        {
            this._repository = repository;
        }
        private ShoppingCart GetCart()
        {
            return HttpContext.Session.GetJson<ShoppingCart>("ShoppingCart") ?? new ShoppingCart();
        }
        public ViewResult List(string category,int page = 1)
        {
            return
                View(new ProductListViewModel
                {
                    Products = _repository.Products.
                    Where(c => category == null || c.Category == category).
                    OrderBy(p => p.Id).
                    //Пропускает часть обьектов, и показывает остальную часть, в пределах размера страницы
                    //Пример (Page1 - 1 * 2) пропускаем ноль и берем 2 обьекта
                    //Пример (Page2-1 * 2) = пропускаем 2 обьекта и берем следующие 2
                    Skip((page - 1) * PageSize).Take(PageSize),
                    PagingInfo = new PagingInfo
                    {
                        CurrentPage = page,
                        ItemsPerPage = PageSize,
                        //если category null - значит общее число товара в таблице, если category is not null - таблица фильтруется по категории и выводит количество товара
                        TotalItems = category == null ? _repository.Products.Count() : _repository.Products.Where(el => el.Category == category).Count()
                    },
                    CurrentCategory = category,
                    Cart = GetCart()
                })  ;
        }
    }
}
