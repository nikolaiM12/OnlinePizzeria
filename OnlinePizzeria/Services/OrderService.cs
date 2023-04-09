using Microsoft.EntityFrameworkCore;
using OnlinePizzeria.Data;
using OnlinePizzeria.Model;
using OnlinePizzeria.Services.Interfaces;
using OnlinePizzeria.Services.ViewModels;

namespace OnlinePizzeria.Services
{
    public class OrderService : IOrderService
    {
        private readonly ApplicationDbContext context;
        public OrderService(ApplicationDbContext post)
        {
            context = post;
        }
        public async Task<ICollection<OrderViewModel>> GetAll()
        {
            return await context.Orders.Select(order => new OrderViewModel()
            {
                OrderDate = order.OrderDate,
                Customer = order.Customer,
                Pizza = order.Pizza,
                Provider = order.Provider,
                BasePrice = order.BasePrice,
                Address = order.Address,
                City = order.City,
                IsDelivered = order.IsDelivered
            }).ToListAsync();
        }
        public async Task AddOrder(OrderViewModel order)
        {
            var orderDb = new Order();
            
            orderDb.OrderId = Guid.NewGuid().ToString();
            orderDb.Customer = order.Customer;
            orderDb.Address = order.Address;
            orderDb.City = order.City;
            orderDb.OrderDate = order.OrderDate;
            orderDb.Provider = order.Provider;
            orderDb.Pizza = order.Pizza;
            orderDb.BasePrice = order.BasePrice;
            orderDb.IsDelivered = order.IsDelivered;

            context.Add(order);
            await context.SaveChangesAsync();
        }

        public async Task DeleteOrder(string orderId)
        {
            var orderDb = context.Orders.FirstOrDefault(o => o.OrderId == orderId);
            context.Orders.Remove(orderDb);
            await context.SaveChangesAsync();
        }
    }
}
