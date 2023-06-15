using OnlinePizzeria.Services.ViewModels;

namespace OnlinePizzeria.Services.Interfaces
{
    public interface IOrderService
    {
        List<OrderViewModel> GetAll();
        Task CreateAsync(OrderViewModel model);
        Task DeleteOrder(string id);
        OrderViewModel GetDetailsById(string id);
        Task UpdateAsync(OrderViewModel model);
        Task<OrderViewModel> UpdateById(string id);
        Task<bool> OrderExists(string id);
    }
}
