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
            RoleManager<IdentityRole> roleManager = app.ApplicationServices.GetRequiredService<RoleManager<IdentityRole>>();
            IdentityUser user = await userManager.FindByNameAsync(adminUser);
            var role = new IdentityRole { Name = "Admin" };
            var res = await roleManager.CreateAsync(role);

            var result = await userManager.AddToRoleAsync(user, role.Name);
            var us = await userManager.FindByNameAsync("admin");
            var rol = await roleManager.FindByNameAsync("Admin"); 
            
        }
    }
}
