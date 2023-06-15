using OnlinePizzeria.Services.ViewModels;

namespace OnlinePizzeria.Services.Interfaces
{
    public interface IPizzaModelService
    {
        List<PizzaViewModel> GetAll();
        Task CreateAsync(PizzaViewModel model, IFormFile imageFile);
        Task DeletePizza(string id);
        PizzaViewModel GetDetailsById(string id);
        Task UpdateAsync(PizzaViewModel model, IFormFile imageFile);
        Task<PizzaViewModel> UpdateById(string id);
        Task<bool> PizzaExists(string id);
        float CalculatePizza(PizzaViewModel pizza);
    }
}
