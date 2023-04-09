using OnlinePizzeria.Services.ViewModels;

namespace OnlinePizzeria.Services.Interfaces
{
    public interface IPizzaModelService
    {
        Task<ICollection<PizzaViewModel>> GetAll();
        Task CreateAsync(PizzaViewModel model);
        Task DeletePizza(string pizzaModelId);
        PizzaViewModel GetDetailsById(string pizzaModelId);
        Task UpdateAsync(PizzaViewModel model);
        //Task CalculateCustomPizza(PizzaViewModel pizzaViewModel); 
        PizzaViewModel UpdateById(string pizzaModelId);
    }
}
