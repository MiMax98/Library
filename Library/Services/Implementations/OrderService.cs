using Library.Models;
using Library.Repositories;

namespace Library.Services.Implementations
{
    public class OrderService : IOrderService
    {
        private readonly IOrderRepository _orderRepository;

        public OrderService(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }
        public void Create(int bookId, int studentId)
        {
            var order = new Order
            {
                BookId = bookId,
                StudentId = studentId,
                Created = DateTime.Now
            };
            _orderRepository.AddOrder(order);
        }

        public void Return(int orderId)
        {
            var order = _orderRepository.GetOrder(orderId);
            if (order == null)
            {
                throw new InvalidOperationException("Wypożyczenie nie istnieje");
            }
            order.Returned = DateTime.Now;
            _orderRepository.UpdateOrder(order);
        }
    }
}
