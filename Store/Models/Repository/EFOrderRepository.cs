using Microsoft.EntityFrameworkCore;
using Store.Models.ApplicationDbContext;
using Store.Models.Interfaces;
using System.Linq;

namespace Store.Models.Repository
{
    public class EFOrderRepository : IOrderRepository
    {
        private SportDbContext _context;
        public EFOrderRepository(SportDbContext context)
        {
            this._context = context;
        }
        public IQueryable<Order> Orders => _context.OrdersT
            .Include(el => el.Lines)
            .ThenInclude(el => el.Product);

        public void SaveOrder(Order order)
        {
            _context.AttachRange(order.Lines.Select(el => el.Product));
            if(order.Id == 0)
            {
                _context.OrdersT.Add(order);
            }
            _context.SaveChanges();
        }
    }
}
