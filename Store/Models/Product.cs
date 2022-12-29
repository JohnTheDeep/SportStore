using System.ComponentModel.DataAnnotations;

namespace Store.Models
{
    public class Product
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage = "Name cannot be empty")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Description cannot be empty")]
        public string Description { get; set; }
        [Required]
        [Range(0.10, double.MaxValue, ErrorMessage = "Enter a positiva value (and value must be greaten 0.10 )")]
        public decimal Price { get; set; }
        [Required(ErrorMessage = "Specify a category")]
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
