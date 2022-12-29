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

        public void SaveProduct(Product product)
        {
            if(product.Id == 0)
            {
                _context.ProductT.Add(product);
            }
            else
            {
                Product _entry = _context.ProductT.FirstOrDefault(el => el.Id == product.Id);
                if (_entry != null)
                {
                    _entry.Name = product.Name;
                    _entry.Description = product.Description;
                    _entry.Price = product.Price;
                    _entry.Category = product.Category;
                }
            }
            _context.SaveChanges();
        }
        public Product RemoveProduct(int productId)
        {
            Product _product = _context.ProductT.FirstOrDefault(el => el.Id == productId);
            if(_product != null)
            {
                _context.Remove(_product);
                _context.SaveChanges();
            }
            return _product;
        }
    }
}
