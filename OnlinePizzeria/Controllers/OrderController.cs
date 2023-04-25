using Microsoft.AspNetCore.Mvc;
using OnlinePizzeria.Model;
using OnlinePizzeria.Services;
using OnlinePizzeria.Services.ViewModels;

namespace OnlinePizzeria.Controllers
{
    public class OrderController : Controller
    {
        public OrderService orderService { get; set; }

        public OrderController(OrderService service)
        {
            orderService = service;
        }
        public IActionResult Index()
        {
            return View();
        }

    }
}
