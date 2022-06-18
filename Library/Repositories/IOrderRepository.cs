using Library.Models;

namespace Library.Repositories
{
    public interface IOrderRepository
    {
        Order? GetOrder(int orderId);
        IQueryable<Order> GetOrders();
        void AddOrder(Order order);
        void UpdateOrder(Order order);
    }
}
