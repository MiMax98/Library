using Library.Data;
using Library.Models;

namespace Library.Services.Implementations
{
    public class OrderService : IOrderService
    {
        private readonly ApplicationDbContext _context;

        public OrderService(ApplicationDbContext context)
        {
            _context = context;
        }
        public void Create(int bookId, int studentId)
        {
            var order = new Order
            {
                BookId = bookId,
                StudentId = studentId,
                Created = DateTime.Now
            };
            _context.Orders.Add(order);
            _context.SaveChanges();
        }

        public void Return(int orderId)
        {
            var order = _context.Orders.Single(o => o.Id == orderId);
            order.Returned = DateTime.Now;
            _context.Update(order);
            _context.SaveChanges();
        }
    }
}
