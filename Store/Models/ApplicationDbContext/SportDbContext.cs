using Microsoft.EntityFrameworkCore;

namespace Store.Models.ApplicationDbContext
{
    public class SportDbContext : DbContext
    {
        public SportDbContext(DbContextOptions<SportDbContext> optionsBuilder) : base(optionsBuilder) => Database.EnsureCreated(); 
        protected internal DbSet<Product> ProductT { get; set; }
    }
}
