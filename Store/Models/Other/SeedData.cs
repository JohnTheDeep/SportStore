using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Store.Models.ApplicationDbContext;
using System;
using System.Linq;

namespace Store.Models.Other
{
    public static class SeedData
    {
        public static void EnsurePopulated(IServiceProvider services)
        {
            SportDbContext _context = services.GetRequiredService<SportDbContext>();
        }
        public static void EnsurePopuldated(IApplicationBuilder app)
        {
            SportDbContext _context = app.ApplicationServices.GetRequiredService<SportDbContext>();
            _context.Database.Migrate();
            if(!_context.ProductT.Any())
            {
                _context.ProductT.AddRange(
                    new Product { Name = "Tennis rocket", Price = 0, Category = "Tennis rocket's", Description = "Some Description" },
                    new Product { Name = "Tennis white-euro rocket", Price = 0, Category = "Tennis rocket's", Description = "Some Description" },
                    new Product { Name = "Tennis pro rocket", Price = 0, Category = "Tennis rocket's", Description = "Some Description" },
                    new Product { Name = "Tennis black rocket", Price = 0, Category = "Tennis rocket's", Description = "Some Description" },
                    new Product { Name = "Tennis red-pro rocket", Price = 0, Category = "Tennis rocket's", Description = "Some Description" },
                    new Product { Name = "Tennis blue-pro rocket", Price = 0, Category = "Tennis rocket's", Description = "Some Description" },

                    new Product { Name = "Basketball ball", Price = 0, Category = "Basketball", Description = "Some Description" },
                    new Product { Name = "Basketball blue-22-tshirt", Price = 0, Category = "Basketball", Description = "Some Description" },
                    new Product { Name = "Basketball red-13-tshirt", Price = 0, Category = "Basketball", Description = "Some Description" },
                    new Product { Name = "Basketball white-tshirt", Price = 0, Category = "Basketball", Description = "Some Description" },
                    new Product { Name = "Basketball blue-tshirt", Price = 0, Category = "Basketball", Description = "Some Description" },
                    new Product { Name = "Basketball orange-tshirt", Price = 0, Category = "Basketball", Description = "Some Description" });
                _context.SaveChangesAsync();
            }
        }
    }
}
