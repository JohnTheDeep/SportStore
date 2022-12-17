using Store.Models.ApplicationDbContext;
using Store.Models.Interfaces;
using System.Linq;

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
    }
}
