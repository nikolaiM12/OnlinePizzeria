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

        public async Task<ICollection<CustomerViewModel>> GetAll()
        {
            return await context.Customers.Select(customer => new CustomerViewModel()
            {
                Address = customer.Address,
                Email = customer.Email,
                FirstName = customer.FirstName,
                LastName = customer.LastName,
                PhoneNumber = customer.PhoneNumber,
                Orders = customer.Orders
            }).ToListAsync();
        }

        public async Task CreateAsync(CustomerViewModel model)
        {
            Customer customer = new Customer();

            customer.CustomerId = Guid.NewGuid().ToString();
            customer.FirstName = model.FirstName;
            customer.LastName = model.LastName;
            customer.PhoneNumber = model.PhoneNumber;
            customer.Email = model.Email;
            customer.Address = model.Address;
            customer.Orders = model.Orders;

            await context.Customers.AddAsync(customer);
            await context.SaveChangesAsync();
        }

        public async Task DeleteCustomer(string customerId)
        {
            var customerDb = context.Customers.FirstOrDefault(x => x.CustomerId == customerId);
            context.Customers.Remove(customerDb);
            await context.SaveChangesAsync();
        }

        public CustomerViewModel GetDetailsById(string customerId)
        {
            CustomerViewModel customer = context.Customers
                .Select(customer => new CustomerViewModel()
                {
                    CustomerId = customer.CustomerId,
                    FirstName = customer.FirstName,
                    LastName = customer.LastName,
                    PhoneNumber = customer.PhoneNumber,
                    Address = customer.Address,
                    Email = customer.Email,
                    Orders = customer.Orders
                }).SingleOrDefault(customer => customer.CustomerId == customerId);
            return customer;
        }

        public async Task UpdateAsync(CustomerViewModel model)
        {
            Customer? customer = context.Customers.Find(model.CustomerId);

            bool isCustomerNull = customer == null;
            if (isCustomerNull)
            {
                return;
            }
            customer.PhoneNumber = model.PhoneNumber;
            customer.Address = model.Address;
            customer.Orders = model.Orders;
            customer.FirstName = model.FirstName;
            customer.LastName = model.LastName;
            customer.Email = model.Email;

            context.Customers.Update(customer);
            await context.SaveChangesAsync();
        }

        public CustomerViewModel UpdateById(string customerId)
        {
            CustomerViewModel customer = context.Customers
                .Select(customer => new CustomerViewModel()
                {
                    CustomerId = customer.CustomerId,
                    FirstName = customer.FirstName,
                    LastName = customer.LastName,
                    PhoneNumber = customer.PhoneNumber,
                    Address = customer.Address,
                    Email = customer.Email,
                    Orders = customer.Orders
                }).SingleOrDefault(customer => customer.CustomerId == customerId);
            return customer; 
        }
    }
}