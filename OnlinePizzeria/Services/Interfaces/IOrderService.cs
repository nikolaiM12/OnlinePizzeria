using OnlinePizzeria.Services.ViewModels;

namespace OnlinePizzeria.Services.Interfaces
{
    public interface IOrderService
    {
        Task<ICollection<OrderViewModel>> GetAll();
        Task AddOrder(OrderViewModel order);
        Task DeleteOrder(string orderId);
    }
}
