using Library.Data;
using Library.Models;

namespace Library.Repositories.Implementations
{
    public class OrderRepository : IOrderRepository
    {
        private readonly ApplicationDbContext _context;

        public OrderRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public void AddOrder(Order order)
        {
            _context.Orders.Add(order);
            _context.SaveChanges();
        }

        public Order? GetOrder(int orderId)
        {
            return _context.Orders.SingleOrDefault(o => o.Id == orderId);
        }

        public IQueryable<Order> GetOrders()
        {
            return _context.Orders;
        }

        public void UpdateOrder(Order order)
        {
            _context.Update(order);
            _context.SaveChanges();
        }
    }
}
