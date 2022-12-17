using System.ComponentModel.DataAnnotations;

namespace Store.Models
{
    public class Product
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public string Category { get; set; }
        public Product(string _name, string _description, decimal _price, string _category)
        {
            this.Name = _name;
            this.Description = _description;
            this.Price = _price;
            this.Category = _category;
        }
        public Product(int _id,string _name, string _description, decimal _price, string _category)
        {
            this.Id = _id;
            this.Name = _name;
            this.Description = _description;
            this.Price = _price;
            this.Category = _category;
        }
        public Product() { }
    }
}
