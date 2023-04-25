using OnlinePizzeria.Data;
using OnlinePizzeria.Data.DataModels;
using OnlinePizzeria.Model;
using OnlinePizzeria.Services.Interfaces;
using OnlinePizzeria.Services.ViewModels;

namespace OnlinePizzeria.Services
{
    public class PizzaModelService : IPizzaModelService
    {
        private readonly ApplicationDbContext context;
        public PizzaModelService(ApplicationDbContext post)
        {
            context = post;
        }
        public List<PizzaViewModel> GetAll()
        {
            return context.Pizza.Select(pizza => new PizzaViewModel()
            {
                ImageTitle = pizza.ImageTitle,
                PizzaName = pizza.PizzaName,
                BasePrice = pizza.BasePrice,
                TomatoSauce = pizza.TomatoSauce,
                Cheese = pizza.Cheese,
                Peperoni = pizza.Peperoni,
                Mushroom = pizza.Mushroom,
                Tuna = pizza.Tuna,
                Pineapple = pizza.Pineapple,
                Ham = pizza.Ham,
                Beef = pizza.Beef,
                FinalPrice = pizza.FinalPrice,
                PizzaSize = pizza.PizzaSize,
                WeightOption = pizza.WeightOption
            }).ToList();
        }
        public async Task CreateAsync(PizzaViewModel model)
        {
            PizzaModel pizzaModel = new PizzaModel();

            pizzaModel.PizzaModelId = model.PizzaModelId;
            pizzaModel.ImageTitle = model.ImageTitle;
            pizzaModel.PizzaName = model.PizzaName;
            pizzaModel.BasePrice = model.BasePrice;
            pizzaModel.TomatoSauce = model.TomatoSauce;
            pizzaModel.Cheese = model.Cheese;
            pizzaModel.Peperoni = model.Peperoni;
            pizzaModel.Mushroom = model.Mushroom;
            pizzaModel.Tuna = model.Tuna;
            pizzaModel.Pineapple = model.Pineapple;
            pizzaModel.Ham = model.Ham;
            pizzaModel.Beef = model.Beef;
            pizzaModel.FinalPrice = model.FinalPrice;
            pizzaModel.PizzaSize = model.PizzaSize;
            pizzaModel.WeightOption = model.WeightOption;

            await context.Pizza.AddAsync(pizzaModel);
            await context.SaveChangesAsync();
        }
        public async Task DeletePizza(string pizzaModelId)
        {
            var pizzamodelDb = context.Pizza.FirstOrDefault(x => x.PizzaModelId == pizzaModelId);
            context.Pizza.Remove(pizzamodelDb);
            await context.SaveChangesAsync();
        }

        public PizzaViewModel GetDetailsById(string pizzaModelId)
        {
            PizzaViewModel pizza = context.Pizza
                .Select(pizza => new PizzaViewModel()
                {
                    PizzaModelId = pizza.PizzaModelId,
                    ImageTitle = pizza.ImageTitle,
                    PizzaName = pizza.PizzaName,
                    BasePrice = pizza.BasePrice,
                    TomatoSauce = pizza.TomatoSauce,
                    Cheese = pizza.Cheese,
                    Peperoni = pizza.Peperoni,
                    Mushroom = pizza.Mushroom,
                    Tuna = pizza.Tuna,
                    Pineapple = pizza.Pineapple,
                    Ham = pizza.Ham,
                    Beef = pizza.Beef,
                    FinalPrice = pizza.FinalPrice,
                    PizzaSize = pizza.PizzaSize,
                    WeightOption = pizza.WeightOption
                }).SingleOrDefault(pizza => pizza.PizzaModelId == pizzaModelId);
            return pizza;
        }
        public async Task UpdateAsync(PizzaViewModel model)
        {
            PizzaModel? pizzaModel = context.Pizza.Find(model.PizzaModelId);
            bool isPizzaNull = pizzaModel == null;
            if (isPizzaNull)
            {
                return;
            }
            pizzaModel.ImageTitle = model.ImageTitle;
            pizzaModel.PizzaName = model.PizzaName;
            pizzaModel.BasePrice = model.BasePrice;
            pizzaModel.TomatoSauce = model.TomatoSauce;
            pizzaModel.Cheese = model.Cheese;
            pizzaModel.Peperoni = model.Peperoni;
            pizzaModel.Mushroom = model.Mushroom;
            pizzaModel.Tuna = model.Tuna;
            pizzaModel.Pineapple = model.Pineapple;
            pizzaModel.Ham = model.Ham;
            pizzaModel.Beef = model.Beef;
            pizzaModel.FinalPrice = model.FinalPrice;
            pizzaModel.PizzaSize = model.PizzaSize;
            pizzaModel.WeightOption = model.WeightOption;

            context.Pizza.Update(pizzaModel);
            await context.SaveChangesAsync();
        }
        public PizzaViewModel UpdateById(string pizzaModelId)
        {
            PizzaViewModel pizza = context.Pizza
                .Select(pizza => new PizzaViewModel()
                {
                    PizzaModelId = pizza.PizzaModelId,
                    ImageTitle = pizza.ImageTitle,
                    PizzaName = pizza.PizzaName,
                    BasePrice = pizza.BasePrice,
                    TomatoSauce = pizza.TomatoSauce,
                    Cheese = pizza.Cheese,
                    Peperoni = pizza.Peperoni,
                    Mushroom = pizza.Mushroom,
                    Tuna = pizza.Tuna,
                    Pineapple = pizza.Pineapple,
                    Ham = pizza.Ham,
                    Beef = pizza.Beef,
                    FinalPrice = pizza.FinalPrice,
                    PizzaSize = pizza.PizzaSize,
                    WeightOption = pizza.WeightOption
                }).SingleOrDefault(pizza => pizza.PizzaModelId == pizzaModelId);
            return pizza;
        }
        public float CalculateCustomPizza(PizzaViewModel pizza, WeightOptionViewModel weight)
        {
            pizza.FinalPrice = pizza.BasePrice;

            if (pizza.TomatoSauce)
            {
                pizza.FinalPrice += 1f;
            }
            if (pizza.Cheese)
            {
                pizza.FinalPrice += 1f;
            }
            if (pizza.Peperoni)
            {
                pizza.FinalPrice += 1.5f;
            }
            if (pizza.Mushroom)
            {
                pizza.FinalPrice += 1f;
            }
            if (pizza.Tuna)
            {
                pizza.FinalPrice += 1.5f;
            }
            if (pizza.Pineapple)
            {
                pizza.FinalPrice += 3f;
            }
            if (pizza.Ham)
            {
                pizza.FinalPrice += 2.5f;
            }
            if (pizza.Beef)
            {
                pizza.FinalPrice += 2.5f;
            }
            switch (pizza.PizzaSize.Size)
            {
                case PizzaSize.SizeType.Small:
                    return pizza.FinalPrice + 1f;
                case PizzaSize.SizeType.Medium:
                    return pizza.FinalPrice + 1.5f;
                case PizzaSize.SizeType.Large:
                    return pizza.FinalPrice + 2.0f;
            }

            switch(pizza.WeightOption.Products)
            {
                case WeightOption.Product.TomatoWeight:
                    return pizza.FinalPrice;
                case WeightOption.Product.HamWeight:
                    return pizza.FinalPrice + 0.25f;
                case WeightOption.Product.BeefWeight:
                    return pizza.FinalPrice + 0.5f;
                case WeightOption.Product.CheeseWeight:
                    return pizza.FinalPrice + 0.75f;
                case WeightOption.Product.MushroomWeight:
                    return pizza.FinalPrice + 1f;
                case WeightOption.Product.TunaWeight:
                    return pizza.FinalPrice + 2f;
            }
            return pizza.FinalPrice; 

        }

    }
}


