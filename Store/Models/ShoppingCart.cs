using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Store.Models
{
    public class ShoppingCart
    {
        private List<CartLine> _lineCollection { get; set; } = new List<CartLine>();
        public virtual void AddItem(Product product, int quantity)
        {
            CartLine _line = _lineCollection.Where(el => el.Product.Id == product.Id).FirstOrDefault();
            if(_line is null)
            {
                _lineCollection.Add(new CartLine(product,quantity));
            }
            else {_line.Quantity += quantity; }
        } 
        public virtual void RemoveLine(Product _product) =>
            _lineCollection?.RemoveAll(el=>el.Product.Id == _product.Id);

        public virtual decimal CalculateTotalValue() => _lineCollection.Sum(el => el.Product.Price * el.Quantity);

        public virtual void Clear() => _lineCollection.Clear();

        public virtual IEnumerable<CartLine> Lines => _lineCollection;
    }
}
