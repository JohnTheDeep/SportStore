using Microsoft.EntityFrameworkCore;

namespace Store.Models.ApplicationDbContext
{
    public class SportDbContext : DbContext
    {
        protected internal DbSet<Product> ProductT { get; set; }
        protected internal DbSet<Order> OrdersT { get; set; }

        public SportDbContext(DbContextOptions<SportDbContext> optionsBuilder) : base(optionsBuilder) => Database.EnsureCreated(); 

    }
}
