using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Store.Models.ViewModels
{
    public class ShoppingCartIndexViewModel
    {
        public ShoppingCart Cart { get; set; }
        public string ReturnUrl { get; set; }
    }
}
