using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.CodeAnalysis.Options;
using Microsoft.EntityFrameworkCore;
using OnlinePizzeria.Data;
using OnlinePizzeria.Data.DataModels;
using OnlinePizzeria.Model;
using OnlinePizzeria.Services.Interfaces;
using OnlinePizzeria.Services.ViewModels;
using System.Drawing;

namespace OnlinePizzeria.Services
{
    public class PizzaModelService : IPizzaModelService
    {
        private readonly ApplicationDbContext context;
        public PizzaModelService(ApplicationDbContext post)
        {
            context = post;
        }
        public async Task<ICollection<PizzaViewModel>> GetAll()
        {
            return await context.Pizza.Select(pizza => new PizzaViewModel()
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
                ProductWeight = pizza.ProductWeight,
                WeightOption = pizza.WeightOption
            }).ToListAsync();
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
            pizzaModel.ProductWeight = model.ProductWeight;
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
                    ProductWeight = pizza.ProductWeight,
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
              pizzaModel.ProductWeight = model.ProductWeight;
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
                    ProductWeight = pizza.ProductWeight,
                    WeightOption = pizza.WeightOption
                }).SingleOrDefault(pizza => pizza.PizzaModelId == pizzaModelId);
            return pizza; 
        }
        public float CalculateCustomPizza(PizzaViewModel pizza, WeightOptionViewModel weight, ProductWeightViewModel product)
        {
            pizza.FinalPrice = pizza.BasePrice;

            if (pizza.TomatoSauce)
            {
                pizza.BasePrice += 1f;
            }
            if (pizza.Cheese)
            {
                pizza.BasePrice += 1f;
            }
            if (pizza.Peperoni)
            {
                pizza.BasePrice += 1.5f;
            }
            if (pizza.Mushroom)
            {
                pizza.BasePrice += 1f;
            }
            if (pizza.Tuna)
            {
                pizza.BasePrice += 1.5f;
            }
            if (pizza.Pineapple)
            {
                pizza.BasePrice += 3f;
            }
            if (pizza.Ham)
            {
                pizza.BasePrice += 2.5f;
            }
            if (pizza.Beef)
            {
                pizza.BasePrice += 2.5f;
            }
            
            switch (pizza.WeightOption.Option)
            {
               case WeightOption.Choice.None:
                   return pizza.BasePrice + 0f;
               case WeightOption.Choice.ExtraLight:
                   return pizza.BasePrice + 0.5f;
               case WeightOption.Choice.Light:
                   return pizza.BasePrice + 0.75f;
               case WeightOption.Choice.Normal:
                   return pizza.BasePrice + 1.25f;
               case WeightOption.Choice.Heavy:
                   return pizza.BasePrice + 1.50f;
               case WeightOption.Choice.ExtraHeavy:
                   return pizza.BasePrice + 2f;
               default:
                   break;
            }
            switch (pizza.PizzaSize.Size)
            {
                case PizzaSize.SizeType.Small:
                    return pizza.BasePrice + 1f;
                case PizzaSize.SizeType.Medium:
                    return pizza.BasePrice + 1.5f;
                case PizzaSize.SizeType.Large:
                    return pizza.BasePrice + 2.0f;
                default:
                    break;
            }
            return pizza.FinalPrice;

        }

    }
}
