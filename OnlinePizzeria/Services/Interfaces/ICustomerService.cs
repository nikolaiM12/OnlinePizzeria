using OnlinePizzeria.Services.ViewModels;

namespace OnlinePizzeria.Services.Interfaces
{
    public interface ICustomerService
    {
        Task <ICollection<CustomerViewModel>> GetAll();
        Task CreateAsync(CustomerViewModel model);
        Task DeleteCustomer(string customerId);
        CustomerViewModel GetDetailsById(string customerId);
        Task UpdateAsync(CustomerViewModel model);
        CustomerViewModel UpdateById(string customerId);
    }
}
