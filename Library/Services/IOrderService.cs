namespace Library.Services
{
    public interface IOrderService
    {
        void Create(int bookId, int studentId);
        void Return(int orderId);
    }
}
