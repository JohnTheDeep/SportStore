using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using System.Threading.Tasks;

namespace Store.Models.Other
{
    public static class IdentitySeedData
    {
        private const string adminUser = "admin2";
        private const string adminPassword = "rooot";
        public static async Task EnsurePopulated(UserManager<IdentityUser> userManager)
        {
            IdentityUser user = await userManager.FindByNameAsync(adminUser);
            throw new System.Exception();
        }
    }
}
