using OnlinePizzeria.Services.ViewModels;

namespace OnlinePizzeria.Services.Interfaces
{
    public interface IPizzaModelService
    {
        List<PizzaViewModel> GetAll();
        Task CreateAsync(PizzaViewModel model);
        Task DeletePizza(string pizzaModelId);
        PizzaViewModel GetDetailsById(string pizzaModelId);
        Task UpdateAsync(PizzaViewModel model);
        PizzaViewModel UpdateById(string pizzaModelId);
        float CalculateCustomPizza(PizzaViewModel pizza, WeightOptionViewModel weight);
    }
}
