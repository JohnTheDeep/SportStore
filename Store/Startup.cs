﻿using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Store.Models.ApplicationDbContext;
using Store.Models.Interfaces;
using Store.Models.Other;
using Store.Models.Repository;

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
            services.AddMvc();
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            app.UseDeveloperExceptionPage();
            app.UseStatusCodePages();
            app.UseStaticFiles();
            
            app.UseMvc(routes =>
            {
                routes.MapRoute("pagination", "Products/Page{page}", new { Controller = "Product", Action = "List" });
                routes.MapRoute("default","{controller=Product}/{action=List}");   
            });
            SeedData.EnsurePopuldated(app);
        }
    }
}
