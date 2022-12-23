using Microsoft.AspNetCore.Mvc.ModelBinding;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Store.Models
{
    public class Order
    {
        [BindNever]
        [Key]
        public int Id { get; set; }
        [BindNever]
        public ICollection<CartLine> Lines { get; set; }
        [BindNever]
        public bool Shipped { get; set; }
        [Required(ErrorMessage = "Name field cannt be empty!")]
        public string Name { get; set; }
        public string AdressLine_1 { get; set; }
        public string AdressLine_2 { get; set; }
        public string AdressLine_3 { get; set; }

        [Required(ErrorMessage = "City field cannt be empty!")]
        public string City { get; set; }
        [Required(ErrorMessage = "State field cannt be empty!")]
        public string State { get; set; }
        [Required(ErrorMessage = "Zip field cannt be empty!")]
        public string Zip { get; set; }
        [Required(ErrorMessage = "Country field cannt be empty!")]
        public string Country { get; set; }
        public bool GiftWrap { get; set; }
    }
}
