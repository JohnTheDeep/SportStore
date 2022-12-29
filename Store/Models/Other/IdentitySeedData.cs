using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using Store.Models.ApplicationDbContext;

namespace Store.Models.Other
{
    public static class IdentitySeedData
    {
        private const string adminUser = "admin2";
        private const string adminPassword = "rooot";
        public static async void EnsurePopulated(IApplicationBuilder app)
        {
            UserManager<IdentityUser> userManager = app.ApplicationServices.GetRequiredService<UserManager<IdentityUser>>();
            IdentityUser user = await userManager.FindByNameAsync(adminUser);
            
                user = new IdentityUser("admin2");
                var result = await userManager.CreateAsync(user, adminPassword);
            
        }
    }
}
