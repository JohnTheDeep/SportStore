using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;
using Store.Infrastructure.Extensions;
using System;

namespace Store.Models
{
    public class SessionShoppingCart : ShoppingCart
    {
        public static ShoppingCart GetShoppingCart(IServiceProvider services)
        {
            ISession _session = services.GetRequiredService<IHttpContextAccessor>()?
                .HttpContext.Session;
            SessionShoppingCart _cart = _session?.GetJson<SessionShoppingCart>("ShoppingCart") ?? new SessionShoppingCart();
            _cart.Session = _session;
            return _cart;
        }
        [JsonIgnore]
        public ISession Session { get; set; }
        public override void AddItem(Product product, int quantity)
        {
            base.AddItem(product, quantity);
            Session.SetJson("ShoppingCart", this);
        }
        public override void RemoveLine(Product _product)
        {
            base.RemoveLine(_product);
            Session.SetJson("ShoppingCart", this);
        }
        public override void Clear()
        {
            base.Clear();
            Session.Remove("ShoppingCart");
        }
    }
}
