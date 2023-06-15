using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.Diagnostics;
using Microsoft.Build.Framework;
using Microsoft.EntityFrameworkCore;
using OnlinePizzeria.Controllers;
using OnlinePizzeria.Data;
using OnlinePizzeria.Data.DataModels;
using OnlinePizzeria.Services;
using OnlinePizzeria.Services.Interfaces;

namespace OnlinePizzeria
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            var connectionString = builder.Configuration.GetConnectionString("DefaultConnection") ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");
            builder.Services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(connectionString));
            builder.Services.AddDatabaseDeveloperPageExceptionFilter();

            builder.Services.AddIdentity<User, Role>(options =>
            {
                options.SignIn.RequireConfirmedEmail = false;
            }).AddEntityFrameworkStores<ApplicationDbContext>()
             .AddDefaultUI()
             .AddTokenProvider<DataProtectorTokenProvider<User>>(TokenOptions.DefaultProvider)
             .AddRoles<Role>();

            builder.Services.AddTransient<UserService, UserService>();
            builder.Services.AddTransient<PizzaModelService, PizzaModelService>();
            builder.Services.AddTransient<OrderService, OrderService>();
            builder.Services.AddTransient<CreditCardPaymentService, CreditCardPaymentService>();
            builder.Services.AddTransient<ProviderService, ProviderService>();
            builder.Services.AddTransient<CustomerService, CustomerService>();
            builder.Services.AddTransient<CustomPizzaService, CustomPizzaService>();

            builder.Services.Configure<IdentityOptions>(options =>
            {
                options.Password.RequireNonAlphanumeric = false;
            });

            builder.Services.AddControllersWithViews();
            builder.Services.AddRazorPages();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseMigrationsEndPoint();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");
            app.MapRazorPages();

            app.Run();
        }
    }
}
