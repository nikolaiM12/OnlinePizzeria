using OnlinePizzeria.Services.ViewModels;

namespace OnlinePizzeria.Services.Interfaces
{
    public interface ICustomerService
    {
        List<CustomerViewModel> GetAll();
        Task CreateAsync(CustomerViewModel model);
        Task DeleteCustomer(string id);
        CustomerViewModel GetDetailsById(string id);
        Task UpdateAsync(CustomerViewModel model);
        Task<CustomerViewModel> UpdateById(string id);
        Task<bool> CustomerExists(string id);
    }
}
