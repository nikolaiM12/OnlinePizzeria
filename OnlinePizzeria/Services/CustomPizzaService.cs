using Microsoft.AspNetCore.Mvc.Rendering;
using OnlinePizzeria.Data.DataModels;
using OnlinePizzeria.Data;
using OnlinePizzeria.Services.Interfaces;
using OnlinePizzeria.Services.ViewModels;
using Microsoft.EntityFrameworkCore;

namespace OnlinePizzeria.Services
{
    public class CustomPizzaService : ICustomPizzaService
    {
        private readonly ApplicationDbContext context;
        private readonly OrderService orderService;
        public CustomPizzaService(ApplicationDbContext post)
        {
            context = post;
            orderService = new OrderService(context);
        }

        public List<CustomPizzaViewModel> GetAll()
        {
            return context.CustomPizzas
                .Include(o => o.Order)
                .Select(p => new CustomPizzaViewModel()
                {
                    Id = p.Id,
                    PizzaName = p.PizzaName,
                    TomatoSauce = p.TomatoSauce,
                    Cheese = p.Cheese,
                    Mushroom = p.Mushroom,
                    Ham = p.Ham,
                    BasePrice = p.BasePrice,
                    Beef = p.Beef,
                    Tuna = p.Tuna,
                    FinalPrice = p.FinalPrice,
                    Price = p.Price,
                    Peperoni = p.Peperoni,
                    Pineapple = p.Pineapple,
                    Order = p.Order,
                    OrderId = p.OrderId
                }).ToList();
        }

        public List<SelectListItem> GetOrders()
        {
            var list = new List<SelectListItem>();

            List<OrderViewModel> orders = orderService.GetAll();
            list = orders.Select(order => new SelectListItem()
            {
                Value = order.Id,
                Text = order.Address
            }).ToList();

            var defaultItem = new SelectListItem()
            {
                Value = null,
                Text = "---Select a Order Address---"
            };

            list.Insert(0, defaultItem);

            return list;
        }
        public async Task CreateAsync(CustomPizzaViewModel model)
        {
            var finalPrice = CalculatePizza(model);

            CustomPizza pizza = new CustomPizza();

            pizza.Id = Guid.NewGuid().ToString();
            pizza.PizzaName = model.PizzaName;
            pizza.TomatoSauce = model.TomatoSauce;
            pizza.Cheese = model.Cheese;
            pizza.Peperoni = model.Peperoni;
            pizza.Mushroom = model.Mushroom;
            pizza.Ham = model.Ham;
            pizza.BasePrice = model.BasePrice;
            pizza.Beef = model.Beef;
            pizza.Tuna = model.Tuna;
            pizza.FinalPrice = model.FinalPrice;
            pizza.Pineapple = model.Pineapple;
            pizza.Price = model.Price;
            pizza.OrderId = model.OrderId;
            pizza.CreatedAt = DateTime.Now;

            await context.CustomPizzas.AddAsync(pizza);
            await context.SaveChangesAsync();
        }

        public async Task DeleteCustomPizza(string id)
        {
            if (string.IsNullOrEmpty(id) || string.IsNullOrWhiteSpace(id))
            {
                throw new ArgumentException("Invalid ID");
            }

            if (id != null)
            {
                var pizzaDb = context.CustomPizzas.FirstOrDefault(p => p.Id == id);
                context.CustomPizzas.Remove(pizzaDb);
                await context.SaveChangesAsync();
            }
        }

        public CustomPizzaViewModel GetDetailsById(string id)
        {
            CustomPizzaViewModel p = context.CustomPizzas
                .Include(p => p.Order)
                .Select(p => new CustomPizzaViewModel()
                {
                    Id = p.Id,
                    PizzaName = p.PizzaName,
                    TomatoSauce = p.TomatoSauce,
                    Cheese = p.Cheese,
                    Peperoni = p.Peperoni,
                    Mushroom = p.Mushroom,
                    Ham = p.Ham,
                    BasePrice = p.BasePrice,
                    Beef = p.Beef,
                    Tuna = p.Tuna,
                    Pineapple = p.Pineapple,
                    FinalPrice = p.FinalPrice,
                    Price = p.Price,
                    Order = p.Order,
                    OrderId = p.OrderId
                }).SingleOrDefault(p => p.Id == id);
            return p;
        }

        public async Task UpdateAsync(CustomPizzaViewModel model)
        {
            if (model == null)
            {
                throw new ArgumentNullException(nameof(model), "Invalid custom pizza model");
            }

            var pizza = await context.CustomPizzas
                .FirstOrDefaultAsync(p => p.Id == model.Id);

            if (pizza == null)
            {
                throw new ArgumentException("Custom pizza not found");
            }

            pizza.PizzaName = model.PizzaName;
            pizza.TomatoSauce = model.TomatoSauce;
            pizza.Cheese = model.Cheese;
            pizza.Peperoni = model.Peperoni;
            pizza.Mushroom = model.Mushroom;
            pizza.Ham = model.Ham;
            pizza.BasePrice = model.BasePrice;
            pizza.Beef = model.Beef;
            pizza.Tuna = model.Tuna;
            pizza.Pineapple = model.Pineapple;
            pizza.FinalPrice = model.FinalPrice;
            pizza.Price = model.Price;
            pizza.Order = model.Order;
            pizza.OrderId = model.OrderId;
            pizza.ModifiedAt = DateTime.Now;

            await context.SaveChangesAsync();
        }
        public async Task<CustomPizzaViewModel> UpdateById(string id)
        {
            var pizza = await context.CustomPizzas
            .Include(p => p.Order)
            .SingleOrDefaultAsync(p => p.Id == id);

            if (pizza == null)
            {
                throw new ArgumentException("Pizza not found");
            }

            return new CustomPizzaViewModel
            {
                Id = pizza.Id,
                PizzaName = pizza.PizzaName,
                TomatoSauce = pizza.TomatoSauce,
                Cheese = pizza.Cheese,
                Peperoni = pizza.Peperoni,
                Mushroom = pizza.Mushroom,
                Ham = pizza.Ham,
                BasePrice = pizza.BasePrice,
                Beef = pizza.Beef,
                Tuna = pizza.Tuna,
                Pineapple = pizza.Pineapple,
                FinalPrice = pizza.FinalPrice,
                Price = pizza.Price,
                Order = pizza.Order,
                OrderId = pizza.OrderId
            };

        }
        public async Task<bool> CustomPizzaExists(string id)
        {
            return await context.CustomPizzas.AnyAsync(p => p.Id == id);
        }

        public float CalculatePizza(CustomPizzaViewModel pizza)
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

            pizza.Price = pizza.FinalPrice;

            return pizza.FinalPrice;
        }
    }
}

