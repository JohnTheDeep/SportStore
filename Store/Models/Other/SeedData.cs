using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Store.Models.ApplicationDbContext;
using System.Linq;

namespace Store.Models.Other
{
    public static class SeedData
    {
        public static void EnsurePopuldated(IApplicationBuilder app)
        {
            SportDbContext _context = app.ApplicationServices.GetRequiredService<SportDbContext>();
            _context.Database.Migrate();
            if(!_context.ProductT.Any())
            {
                _context.ProductT.AddRange(
                    new Product { Name = "Basketball shoes", Price = 165.99M, Category = "Shoes", Description = "" },
                    new Product { Name = "Football shoes", Price = 199.99M, Category = "Shoes", Description = "" },
                    new Product { Name = "Tennis ball", Price = 25, Category = "Tennis", Description = "" },
                    new Product { Name = "Basketball ball", Price = 25.99M, Category = "Balls", Description = "" },
                    new Product { Name = "Football shorts", Price = 0, Category = "Clothing", Description = "" },
                    new Product { Name = "Football t-shirt", Price = 0, Category = "Clothing", Description = "" });
                _context.SaveChangesAsync();
            }
        }
    }
}
