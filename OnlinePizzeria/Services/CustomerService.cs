using Microsoft.EntityFrameworkCore;
using OnlinePizzeria.Data;
using OnlinePizzeria.Model;
using OnlinePizzeria.Services.Interfaces;
using OnlinePizzeria.Services.ViewModels;
using System.Reflection.Metadata.Ecma335;

namespace OnlinePizzeria.Services
{
    public class CustomerService : ICustomerService
    {
        private readonly ApplicationDbContext context;
        public CustomerService(ApplicationDbContext post)
        {
            context = post;
        }

        public List<CustomerViewModel> GetAll()
        {
            return context.Customers
                .Select(customer => new CustomerViewModel()
                {
                    Id = customer.Id,
                    Address = customer.Address,
                    Email = customer.Email,
                    FirstName = customer.FirstName,
                    LastName = customer.LastName,
                    PhoneNumber = customer.PhoneNumber,
                }).ToList();
        }

        public async Task CreateAsync(CustomerViewModel model)
        {
            Customer customer = new Customer
            {
                Id = Guid.NewGuid().ToString(),
                Address = model.Address,
                Email = model.Email,
                FirstName = model.FirstName,
                LastName = model.LastName,
                PhoneNumber = model.PhoneNumber,
                CreatedAt = DateTime.Now
            };

            await context.Customers.AddAsync(customer);
            await context.SaveChangesAsync();
        }

        public async Task DeleteCustomer(string id)
        {
            if (string.IsNullOrEmpty(id) || string.IsNullOrWhiteSpace(id))
            {
                throw new ArgumentException("Invalid ID");
            }

            var customer = await context.Customers
            .Include(o => o.Order)
            .FirstOrDefaultAsync(o => o.Id == id);

            if (customer != null)
            {
                context.Customers.Remove(customer);
                await context.SaveChangesAsync();
            }
        }

        public CustomerViewModel GetDetailsById(string id)
        {
            return context.Customers
            .Include(c => c.Order)
            .Select(customer => new CustomerViewModel
            {
                Id = customer.Id,
                Address = customer.Address,
                Order = customer.Order,
                PhoneNumber = customer.PhoneNumber,
                Email = customer.Email,
                FirstName = customer.FirstName,
                LastName = customer.LastName,
            })
            .SingleOrDefault(customer => customer.Id == id);
        }

        public async Task UpdateAsync(CustomerViewModel model)
        {
            if (model == null)
            {
                throw new ArgumentNullException(nameof(model), "Invalid customer model");
            }

            var customer = await context.Customers
                .FirstOrDefaultAsync(c => c.Id == model.Id);

            if (customer == null)
            {
                throw new ArgumentException("Customer not found");
            }

            customer.Address = model.Address;
            customer.PhoneNumber = model.PhoneNumber;
            customer.FirstName = model.FirstName;
            customer.LastName = model.LastName;
            customer.Email = model.Email;
            customer.ModifiedAt = DateTime.Now;

            await context.SaveChangesAsync();
        }

        public async Task<CustomerViewModel> UpdateById(string id)
        {
            var customer = await context.Customers
            .SingleOrDefaultAsync(o => o.Id == id);

            if (customer == null)
            {
                throw new ArgumentException("Customer not found");
            }

            return new CustomerViewModel
            {
                Id = customer.Id,
                Address = customer.Address,
                PhoneNumber = customer.PhoneNumber,
                Email = customer.Email,
                FirstName = customer.FirstName,
                LastName = customer.LastName,
            };
        }
        public async Task<bool> CustomerExists(string id)
        {
            return await context.Customers.AnyAsync(c => c.Id == id);
        }

    }
}
