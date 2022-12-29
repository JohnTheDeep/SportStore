using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Store.Models.ApplicationDbContext
{
    public class IdentityContext : IdentityDbContext<IdentityUser>
    {
        public IdentityContext(DbContextOptions<IdentityContext> _options) : base(_options) { Database.EnsureCreated(); }
    }
}
