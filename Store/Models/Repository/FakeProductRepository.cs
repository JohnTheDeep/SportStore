using Store.Models.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace Store.Models.Repository
{
    public class FakeProductRepository : IProductRepository
    {
        public IQueryable<Product> Products => new List<Product>
        {
            new Product { Name = "Football", Price = 25 },
            new Product { Name = "Surf board", Price = 120 },
            new Product { Name = "Tennis ball", Price = 15 },
            new Product { Name = "Running shoes", Price = 200 },
            new Product { Name = "Football shoes", Price = 190 },
            new Product { Name = "Basketball shoes", Price = 199.99M },
        }.AsQueryable<Product>();
    }
}
