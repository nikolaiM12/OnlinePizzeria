using Microsoft.AspNetCore.Mvc;
using OnlinePizzeria.Services;

namespace OnlinePizzeria.Controllers
{
    public class CustomerController : Controller
    {
        public CustomerService customerService { get; set; }
        public CustomerController(CustomerService service)
        {
            customerService = service;
        }
        public IActionResult Index()
        {
            return View();
        }
    }
}
