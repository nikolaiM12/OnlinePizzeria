using OnlinePizzeria.Services.ViewModels;

namespace OnlinePizzeria.Services.Interfaces
{
    public interface ICustomPizzaService
    {
        List<CustomPizzaViewModel> GetAll();
        Task CreateAsync(CustomPizzaViewModel model);
        Task DeleteCustomPizza(string id);
        CustomPizzaViewModel GetDetailsById(string id);
        Task UpdateAsync(CustomPizzaViewModel model);
        Task<CustomPizzaViewModel> UpdateById(string id);
        Task<bool> CustomPizzaExists(string id);
        float CalculatePizza(CustomPizzaViewModel pizza);
    }
}
