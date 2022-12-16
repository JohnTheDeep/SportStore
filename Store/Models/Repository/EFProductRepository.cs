using Store.Models.ApplicationDbContext;
using Store.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Store.Models.Repository
{
    public class EFProductRepository : IProductRepository
    {
        private readonly SportDbContext _context;
        public EFProductRepository(SportDbContext context)
        {
            this._context = context;
        }
        public IQueryable<Product> Products => _context.ProductT;
        public void AddProduct()
        {

        }
    }
}
