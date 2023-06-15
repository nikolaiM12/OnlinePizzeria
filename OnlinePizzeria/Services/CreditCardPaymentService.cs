using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using OnlinePizzeria.Data;
using OnlinePizzeria.Model;
using OnlinePizzeria.Services.Interfaces;
using OnlinePizzeria.Services.ViewModels;

namespace OnlinePizzeria.Services
{
    public class CreditCardPaymentService : ICreditCardPaymentService
    {
        private readonly ApplicationDbContext context;
        private readonly CustomerService customerService;
        private readonly OrderService orderService;

        public CreditCardPaymentService(ApplicationDbContext post)
        {
            context = post;
            customerService = new CustomerService(context);
            orderService = new OrderService(context);
        }

        public List<CreditCardPaymentViewModel> GetAll()
        {
            return context.OnlinePayment
                .Include(payment => payment.Order)
                .Include(payment => payment.Customer)
                .Select(payment => new CreditCardPaymentViewModel()
                {
                    Id = payment.Id,
                    CardNumber = payment.CardNumber,
                    ExpirationDate = payment.ExpirationDate,
                    CVV = payment.CVV,
                    Amount = payment.Amount,
                    Order = payment.Order,
                    OrderId = payment.OrderId,
                    Customer = payment.Customer,
                    CustomerId = payment.CustomerId
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
        public async Task CreateAsync(CreditCardPaymentViewModel model)
        {
            if (model.CustomerId == "")
            {
            }
            if (model.OrderId == "")
            {
            }
            else
            {
                CreditCardPayment payment = new()
                {
                    Id = Guid.NewGuid().ToString(),
                    CardNumber = model.CardNumber,
                    CVV = model.CVV,
                    Amount = model.Amount,
                    ExpirationDate = model.ExpirationDate,
                    CustomerId = model.CustomerId,
                    OrderId = model.OrderId,
                    CreatedAt = DateTime.Now
                };

                await context.OnlinePayment.AddAsync(payment);
                await context.SaveChangesAsync();
            }

        }

        public async Task DeletePayment(string id)
        {
            if (string.IsNullOrEmpty(id) || string.IsNullOrWhiteSpace(id))
            {
                throw new ArgumentException("Invalid ID");
            }

            var payment = await context.OnlinePayment
            .Include(o => o.Customer)
            .Include(o => o.Order)
            .FirstOrDefaultAsync(o => o.Id == id);

            if (payment != null)
            {
                context.OnlinePayment.Remove(payment);
                await context.SaveChangesAsync();
            }
        }

        public CreditCardPaymentViewModel GetDetailsById(string id)
        {
            return context.OnlinePayment
            .Include(c => c.Customer)
            .Include(o => o.Order)
            .Select(payment => new CreditCardPaymentViewModel
            {
                Id = payment.Id,
                CardNumber = payment.CardNumber,
                Amount = payment.Amount,
                ExpirationDate = payment.ExpirationDate,
                CVV = payment.CVV,
                CustomerId = payment.CustomerId,
                OrderId = payment.OrderId,
                Customer = payment.Customer,
                Order = payment.Order
            })
            .SingleOrDefault(payment => payment.Id == id);
        }

        public async Task UpdateAsync(CreditCardPaymentViewModel model)
        {
            if (model == null)
            {
                throw new ArgumentNullException(nameof(model), "Invalid payment model");
            }

            var payment = await context.OnlinePayment
                .FirstOrDefaultAsync(o => o.Id == model.Id);

            if (payment == null)
            {
                throw new ArgumentException("Payment not found");
            }

            payment.CardNumber = model.CardNumber;
            payment.CVV = model.CVV;
            payment.ExpirationDate = model.ExpirationDate;
            payment.Amount = model.Amount;
            payment.Customer = model.Customer;
            payment.CustomerId = model.CustomerId;
            payment.Order = model.Order;
            payment.OrderId = model.OrderId;
            payment.ModifiedAt = DateTime.Now;

            await context.SaveChangesAsync();
        }

        public async Task<CreditCardPaymentViewModel> UpdateById(string id)
        {
            var payment = await context.OnlinePayment
            .Include(o => o.Customer)
            .Include(o => o.Order)
            .SingleOrDefaultAsync(o => o.Id == id);

            if (payment == null)
            {
                throw new ArgumentException("Payment not found");
            }

            return new CreditCardPaymentViewModel
            {
                Id = payment.Id,
                CardNumber = payment.CardNumber,
                CVV = payment.CVV,
                ExpirationDate = payment.ExpirationDate,
                Amount = payment.Amount,
                Order = payment.Order,
                OrderId = payment.OrderId,
                Customer = payment.Customer,
                CustomerId = payment.CustomerId
            };
        }
        public async Task<bool> PaymentExists(string id)
        {
            return await context.OnlinePayment.AnyAsync(p => p.Id == id);
        }
    }
}

