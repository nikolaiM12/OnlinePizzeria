using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using OnlinePizzeria.Data;
using OnlinePizzeria.Model;
using OnlinePizzeria.Services.Interfaces;
using OnlinePizzeria.Services.ViewModels;

namespace OnlinePizzeria.Services
{
    public class PizzaModelService : IPizzaModelService
    {
        private readonly ApplicationDbContext context;
        private readonly OrderService orderService;
        public PizzaModelService(ApplicationDbContext post)
        {
            context = post;
            orderService = new OrderService(context);
        }

        public List<PizzaViewModel> GetAll()
        {
            return context.Pizza
                .Include(p => p.Order)
                .Select(pizza => new PizzaViewModel()
                {
                    Id = pizza.Id,
                    PizzaName = pizza.PizzaName,
                    ImageTitle = pizza.ImageTitle,
                    TomatoSauce = pizza.TomatoSauce,
                    Cheese = pizza.Cheese,
                    Peperoni = pizza.Peperoni,
                    Mushroom = pizza.Mushroom,
                    Ham = pizza.Ham,
                    BasePrice = pizza.BasePrice,
                    Pineapple = pizza.Pineapple,
                    FinalPrice = pizza.FinalPrice,
                    Beef = pizza.Beef,
                    Tuna = pizza.Tuna,
                    Description = pizza.Description,
                    ImageUrl = pizza.ImageUrl,
                    Price = pizza.Price,
                    ImageData = pizza.ImageData,
                    Order = pizza.Order,
                    OrderId = pizza.OrderId
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
        public async Task CreateAsync(PizzaViewModel model, IFormFile imageFile)
        {
            var finalPrice = CalculatePizza(model);

            PizzaModel pizza = new PizzaModel();

            pizza.Id = Guid.NewGuid().ToString();
            pizza.PizzaName = model.PizzaName;
            pizza.ImageTitle = model.ImageTitle;
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
            pizza.Description = model.Description;
            pizza.ImageUrl = model.ImageUrl;
            pizza.Price = model.Price;
            pizza.OrderId = model.OrderId;
            pizza.CreatedAt = DateTime.Now;

            if (imageFile != null && imageFile.Length > 0)
            {
                using (var memoryStream = new MemoryStream())
                {
                    await imageFile.CopyToAsync(memoryStream);
                    pizza.ImageData = memoryStream.ToArray();
                }
            }
            else
            {
                pizza.ImageData = new byte[0];
            }


            await context.Pizza.AddAsync(pizza);
            await context.SaveChangesAsync();
        }

        public async Task DeletePizza(string id)
        {
            if (string.IsNullOrEmpty(id) || string.IsNullOrWhiteSpace(id))
            {
                throw new ArgumentException("Invalid ID");
            }

            var pizza = await context.Pizza
            .Include(p => p.Order)
            .FirstOrDefaultAsync(o => o.Id == id);

            if (pizza != null)
            {
                context.Pizza.Remove(pizza);
                await context.SaveChangesAsync();
            }
        }

        public PizzaViewModel GetDetailsById(string id)
        {
            PizzaViewModel pizza = context.Pizza
                .Include(pizza => pizza.Order)
                .Select(pizza => new PizzaViewModel()
                {
                    Id = pizza.Id,
                    ImageTitle = pizza.ImageTitle,
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
                    ImageUrl = pizza.ImageUrl,
                    Description = pizza.Description,
                    Price = pizza.Price,
                    Order = pizza.Order,
                    OrderId = pizza.OrderId
                }).SingleOrDefault(pizza => pizza.Id == id);
            return pizza;
        }

        public async Task UpdateAsync(PizzaViewModel model, IFormFile imageFile)
        {
            if (model == null)
            {
                throw new ArgumentNullException(nameof(model), "Invalid pizza model");
            }

            var pizza = await context.Pizza
                .FirstOrDefaultAsync(p => p.Id == model.Id);

            if (pizza == null)
            {
                throw new ArgumentException("Pizza not found");
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
            pizza.ImageUrl = model.ImageUrl;
            pizza.Description = model.Description;
            pizza.ImageData = model.ImageData;
            pizza.Order = model.Order;
            pizza.OrderId = model.OrderId;
            pizza.ModifiedAt = DateTime.Now;

            if (model.ImageFile != null && model.ImageFile.Length > 0)
            {
                using (var memoryStream = new MemoryStream())
                {
                    await model.ImageFile.CopyToAsync(memoryStream);
                    model.ImageData = memoryStream.ToArray();
                }
            }

            await context.SaveChangesAsync();
        }

        public async Task<PizzaViewModel> UpdateById(string id)
        {
            if (!await PizzaExists(id))
            {
                throw new ArgumentNullException(nameof(id), "Pizza not found");
            }
            PizzaViewModel pizza = await context.Pizza
            .Include(o => o.Order)
            .Where(p => p.Id == id)
            .Select(p => new PizzaViewModel
            {
                Id = p.Id,
                ImageTitle = p.ImageTitle,
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
                Description = p.Description,
                ImageUrl = p.ImageUrl,
                Price = p.Price,
                Order = p.Order,
                OrderId = p.OrderId
            }).SingleOrDefaultAsync();

            if (pizza.ImageFile != null && pizza.ImageFile.Length > 0)
            {
                using (var memoryStream = new MemoryStream())
                {
                    await pizza.ImageFile.CopyToAsync(memoryStream);
                    pizza.ImageData = memoryStream.ToArray();
                }
            }

            return pizza;
        }

        public async Task<bool> PizzaExists(string id)
        {
            return await context.Pizza.AnyAsync(p => p.Id == id);
        }

        public float CalculatePizza(PizzaViewModel pizza)
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




