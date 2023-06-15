using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.CodeAnalysis.FlowAnalysis.DataFlow;
using Microsoft.EntityFrameworkCore;
using OnlinePizzeria.Data;
using OnlinePizzeria.Model;
using OnlinePizzeria.Services.Interfaces;
using OnlinePizzeria.Services.ViewModels;
using System.Runtime.Intrinsics.Arm;

namespace OnlinePizzeria.Services
{
    public class OrderService : IOrderService
    {
        private readonly ApplicationDbContext context;
        private readonly CustomerService customerService;
        private readonly ProviderService providerService;

        public OrderService(ApplicationDbContext context)
        {
            this.context = context;
            customerService = new CustomerService(context);
            providerService = new ProviderService(context);
        }

        public List<OrderViewModel> GetAll()
        {
            return context.Orders
                .Include(order => order.Customer)
                .Include(order => order.Provider)
                .Select(order => new OrderViewModel()
                {
                    Id = order.Id,
                    Address = order.Address,
                    City = order.City,
                    Price = order.Price,
                    OrderDate = order.OrderDate,
                    CustomerId = order.CustomerId,
                    ProviderId = order.ProviderId,
                    Customer = order.Customer,
                    Provider = order.Provider
                }).ToList();
        }
        public List<SelectListItem> GetCustomers()
        {
            var list = new List<SelectListItem>();

            List<CustomerViewModel> customers = customerService.GetAll();
            list = customers.Select(customer => new SelectListItem()
            {
                Value = customer.Id,
                Text = $"{customer.FirstName} {customer.LastName}"
            }).ToList();

            var defaultItem = new SelectListItem()
            {
                Value = null,
                Text = "---Select a Customer---"
            };

            list.Insert(0, defaultItem);

            return list;
        }

        public List<SelectListItem> GetProviders()
        {
            var list = new List<SelectListItem>();

            List<ProviderViewModel> providers = providerService.GetAll();
            providers = providers.Where(provider => provider.IsAvailable).ToList();
            list = providers.Select(provider => new SelectListItem()
            {
                Value = provider.Id,
                Text = provider.Name
            }).ToList();

            var defaultItem = new SelectListItem()
            {
                Value = null,
                Text = "---Select a Provider---"
            };

            list.Insert(0, defaultItem);

            return list;
        }
        public async Task CreateAsync(OrderViewModel model)
        {
            if (model.CustomerId == "")
            {
            }
            if (model.ProviderId == "")
            {
            }
            else
            {
                Order order = new()
                {
                    Id = Guid.NewGuid().ToString(),
                    Address = model.Address,
                    City = model.City,
                    Price = model.Price,
                    OrderDate = model.OrderDate,
                    CustomerId = model.CustomerId,
                    ProviderId = model.ProviderId,
                    CreatedAt = DateTime.Now
                };

                await context.Orders.AddAsync(order);
                await context.SaveChangesAsync();
            }

        }

        public async Task DeleteOrder(string id)
        {
            if (string.IsNullOrEmpty(id) || string.IsNullOrWhiteSpace(id))
            {
                throw new ArgumentException("Invalid ID");
            }

            var order = await context.Orders
                .Include(o => o.Provider)
                .Include(o => o.Customer)
                .Include(o => o.CustomPizzas)
                .FirstOrDefaultAsync(o => o.Id == id);

            if (order != null)
            {
                context.Orders.Remove(order);
                await context.SaveChangesAsync();
            }
        }

        public OrderViewModel GetDetailsById(string id)
        {
            return context.Orders
                .Include(c => c.Customer)
                .Include(p => p.Provider)
                .Select(order => new OrderViewModel
                {
                    Id = order.Id,
                    Address = order.Address,
                    City = order.City,
                    Price = order.Price,
                    OrderDate = order.OrderDate,
                    ProviderId = order.ProviderId,
                    Provider = order.Provider,
                    Customer = order.Customer,
                    CustomerId = order.CustomerId
                })
                .SingleOrDefault(order => order.Id == id);
        }

        public async Task UpdateAsync(OrderViewModel model)
        {
            if (model == null)
            {
                throw new ArgumentNullException(nameof(model), "Invalid order model");
            }

            var order = await context.Orders
                .FirstOrDefaultAsync(o => o.Id == model.Id);

            if (order == null)
            {
                throw new ArgumentException("Order not found");
            }

            order.OrderDate = model.OrderDate;
            order.Address = model.Address;
            order.City = model.City;
            order.Price = model.Price;
            order.ModifiedAt = DateTime.Now;

            await context.SaveChangesAsync();
        }

        public async Task<OrderViewModel> UpdateById(string id)
        {
            var order = await context.Orders
            .SingleOrDefaultAsync(o => o.Id == id);

            if (order == null)
            {
                throw new ArgumentException("Order not found");
            }

            return new OrderViewModel
            {
                Id = order.Id,
                Address = order.Address,
                City = order.City,
                Price = order.Price,
                OrderDate = order.OrderDate,
            };

        }

        public async Task<bool> OrderExists(string id)
        {
            return await context.Orders.AnyAsync(o => o.Id == id);
        }

    }
}
