using Microsoft.AspNetCore.Mvc;
using Moq;
using Store.Controllers;
using Store.Models;
using Store.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xunit;
using Microsoft.AspNetCore.Mvc.Routing;
using Store.Infrastructure;
using Microsoft.AspNetCore.Razor.TagHelpers;
using System.Threading.Tasks;
using Store.Models.ViewModels;
using Store.Components;
using Microsoft.AspNetCore.Mvc.ViewComponents;

namespace StoreTesting
{
    public class ProductControllerTest
    {
        [Fact]
        public void Categories()
        {
            Mock<IProductRepository> mock = new Mock<IProductRepository>();
            mock.Setup(m => m.Products).Returns((new Product[] 
            {
                new Product{Id = 1, Name = "P1", Category = "Apples"},
                new Product{Id = 1, Name = "P2", Category = "Apples"},
                new Product{Id = 1, Name = "P3", Category = "Banannas"},
                new Product{Id = 1, Name = "P4", Category = "Drugs"},
                new Product{Id = 1, Name = "P5", Category = "Apples"},
            }).AsQueryable);

            NavigationMenuViewComponent target = new NavigationMenuViewComponent(mock.Object);
            string[] values = (((IEnumerable<string>)(target.Invoke() as ViewViewComponentResult).ViewData.Model)).ToArray();
            Assert.True(Enumerable.SequenceEqual(new string [] { "Apples", "Banannas", "Drugs" }, values));
        }
        [Fact]
        public void Paging()
        {
            var urlHelper = new Mock<IUrlHelper>();
            urlHelper.SetupSequence(x => x.Action(It.IsAny<UrlActionContext>()))
                .Returns("Test/Page1")
                .Returns("Test/Page2")
                .Returns("Test/Page3");

            var urlHelperFactory = new Mock<IUrlHelperFactory>(); urlHelperFactory.Setup(f =>
                f.GetUrlHelper(It.IsAny<ActionContext>()))
                .Returns(urlHelper.Object);

            PageLinkTagHelper helper =
            new PageLinkTagHelper(urlHelperFactory.Object) {
            PageModel = new PagingInfo {
                CurrentPage = 2,
                TotalItems = 28,
                ItemsPerPage = 10
                },
                PageAction = "Test"
            };  

            TagHelperContext ctx = new TagHelperContext(
                new TagHelperAttributeList(),
                new Dictionary<object, object>(), "");

            var content = new Mock<TagHelperContent>();
            TagHelperOutput output = new TagHelperOutput("div",
            new TagHelperAttributeList(),
            (cache, encoder) => Task.FromResult(content.Object));
            // Действие
            helper.Process(ctx, output);
            // Утверждение
            Assert.Equal(@"<a href=""Test/Page1"">l</a>"
            + @"<a href=""Test/Page2"">2</a> "
            + @"<a href=""Test/Page3"">3</a>", output.Content.GetContent().ToString());
        }
        //[Fact]
        //public void Can_Paginate()
        //{
        //    Mock<IProductRepository> mock = new Mock<IProductRepository>();
        //    mock.Setup(m => m.Products).Returns((new Product[] 
        //    {
        //        new Product { Name = "P1", Price = 165.99M, Category = "Shoes", Description = "" },
        //        new Product { Name = "P2", Price = 199.99M, Category = "Shoes", Description = "" },
        //        new Product { Name = "P3", Price = 25, Category = "Tennis", Description = "" },
        //        new Product { Name = "P4", Price = 25.99M, Category = "Balls", Description = "" },
        //        new Product { Name = "P5", Price = 0, Category = "Clothing", Description = "" },
        //        new Product { Name = "P6", Price = 0, Category = "Clothing", Description = "" }
        //    }).AsQueryable<Product>());
        //    ProductController controller = new ProductController(mock.Object);
        //    controller.Pages = 3;

        //    IEnumerable<Product> result = controller.List(2).ViewData.Model as IEnumerable<Product>;

        //    Product[] prodArray = result.ToArray();
        //    Assert.True(prodArray.Length == 2);
        //    Assert.Equal("P4", prodArray[0].Name);
        //    Assert.Equal("P5", prodArray[1].Name);
        //}
    }
}
