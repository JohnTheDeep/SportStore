using System.Linq;

namespace Store.Models.Interfaces
{
    public interface IProductRepository
    {
        IQueryable<Product> Products { get; }
        void SaveProduct(Product product);
        Product RemoveProduct(int productId);
    }
}
