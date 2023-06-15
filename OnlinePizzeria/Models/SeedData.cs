//using Microsoft.EntityFrameworkCore;
//using OnlinePizzeria.Model;
//using OnlinePizzeria.Services.ViewModels;
//using System.Text.Json;

//namespace OnlinePizzeria.Models
//{
//    public static class SeedData
//    {
//        public static void SeedCustomers(this ModelBuilder builder)
//        {
//            string json = File.ReadAllText("Customer_DATA.json");
//            List<CustomerViewModel> customers = JsonSerializer.Deserialize<List<CustomerViewModel>>(json);

//            foreach (var customer in customers)
//            {
//                Customer newCustomer = new Customer
//                {
//                    Id = Guid.NewGuid().ToString(),
//                    FirstName = customer.FirstName,
//                    LastName = customer.LastName,
//                    PhoneNumber = customer.PhoneNumber,
//                    Email = customer.Email,
//                    Address = customer.Address
//                };

//                builder.Entity<Customer>().HasData(newCustomer);
//            }
//        }
//    }
//}
