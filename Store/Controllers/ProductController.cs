using Microsoft.AspNetCore.Mvc;
using Store.Models.Interfaces;
using Store.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Store.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductRepository _repository;
        public int Pages { get; set; } = 4;
        public ProductController(IProductRepository repository)
        {
            this._repository = repository;
        }
        public ViewResult List(int page = 1)
        {
            return
                View(new ProductListViewModel
                {
                    Products = _repository.Products.
                    OrderBy(p => p.Id).
                    Skip((page - 1) * Pages).Take(Pages),
                    PagingInfo = new PagingInfo 
                    {
                        CurrentPage = page,
                        ItemsPerPage = Pages,
                        TotalItems = _repository.Products.Count()
                    }
                });
        }
    }
}
