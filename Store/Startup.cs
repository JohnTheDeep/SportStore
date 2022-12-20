using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Store.Models.ApplicationDbContext;
using Store.Models.Interfaces;
using Store.Models.Other;
using Store.Models.Repository;
using Store.Models;
using Microsoft.AspNetCore.Http;

namespace Store
{
    public class Startup
    {
        private protected IConfiguration _config { get; }
        public Startup(IConfiguration config) => this._config = config;
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<SportDbContext>
                (opt => opt.UseSqlServer(_config["Data:SportStore:_defaultConnectionString"]));
            services.AddTransient<IProductRepository, EFProductRepository>();
            services.AddScoped<ShoppingCart>(el => SessionShoppingCart.GetShoppingCart(el));
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            services.AddMvc();
            services.AddMemoryCache();
            services.AddSession();
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            app.UseDeveloperExceptionPage();
            app.UseStatusCodePages();
            app.UseStaticFiles();
            app.UseSession();
            app.UseMvc(routes =>
            {
                routes.MapRoute(null, "Products/{category}/Page{page:int}", new { Controller = "Product", Action = "List" });
                routes.MapRoute(null, "Products/Page{page:int}", new { Controller = "Product", Action = "List", page = 1 });
                routes.MapRoute(null, "Products/{category}", new { Controller = "Product", Action = "List" , page = 1});
                routes.MapRoute(null, "Products", new { Controller = "Product", Action = "List", page = 1 });
                //routes.MapRoute(null, "{controller}/{action}");
                routes.MapRoute("default", "{controller=Product}/{action=List}");
            });
            SeedData.EnsurePopuldated(app);
        }
    }
}
