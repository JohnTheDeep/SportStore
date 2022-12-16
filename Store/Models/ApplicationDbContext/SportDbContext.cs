using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
namespace Store.Models.ApplicationDbContext
{
    public class SportDbContext : DbContext
    {
        public SportDbContext(DbContextOptions<SportDbContext> optionsBuilder) : base(optionsBuilder) { Database.EnsureCreated(); }
        protected internal DbSet<Product> ProductT { get; set; }
    }
}
