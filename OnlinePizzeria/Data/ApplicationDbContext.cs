using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Model;

namespace WebApplication2.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {

        }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<CreditCardPayment> OnlinePayment { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<PizzaModel> Pizza { get; set; }
        public DbSet<Provider> Providers { get; set; }

         protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
         {
            optionsBuilder.UseSqlServer("Server=LAPTOP-DPN235VU\\SQLEXPRESS;Database=OnlinePizzeriaDB;Trusted_Connection=True;TrustServerCertificate=True;");
         }
    }
}