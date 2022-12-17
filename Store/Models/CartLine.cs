using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;

namespace Store.Models
{
    public class CartLine
    {
        [Key]
        public int Id { get; set; }
        public Product Product { get; set; }
        public int Quantity { get; set; }
        [JsonConstructor]
        public CartLine() { }
        public CartLine(Product _product, int _quantity)
        {
            this.Product = _product;
            this.Quantity = _quantity;
        }
        public CartLine(int _id,Product _product, int _quantity)
        {
            this.Id = _id;
            this.Product = _product;
            this.Quantity = _quantity;
        }
    }
}
