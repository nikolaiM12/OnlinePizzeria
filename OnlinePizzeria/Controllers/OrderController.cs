using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using OnlinePizzeria.Model;
using OnlinePizzeria.Services;
using OnlinePizzeria.Services.Interfaces;
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
        [Authorize(Roles = "User")]
        [HttpGet]
        public IActionResult Index()
        {
            List<OrderViewModel> orders = orderService.GetAll();
            return View(orders);
        }

        [HttpGet]
        public IActionResult Details(string id)
        {
            ViewBag.Customers = orderService.GetCustomers();
            ViewBag.Providers = orderService.GetProviders();
            OrderViewModel order = orderService.GetDetailsById(id);
            bool isCourseNull = order == null;
            if (isCourseNull)
            {
                return NotFound();
            }

            return this.View(order);
        }
        [HttpGet]
        public IActionResult AddOrder()
        {
            ViewBag.Customers = orderService.GetCustomers();
            ViewBag.Providers = orderService.GetProviders();
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddOrder(OrderViewModel order)
        {
            if (order == null)
            {
                return BadRequest("Invalid order data");
            }

            TempData["success"] = "Order added successfully";
            await orderService.CreateAsync(order);
            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public IActionResult DeleteOrder()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteOrder(string id)
        {
            OrderViewModel order = orderService.GetDetailsById(id);
            if (order == null)
            {
                return NotFound();
            }
            TempData["success"] = "Order deleted successfully";
            await orderService.DeleteOrder(id);
            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public async Task<IActionResult> UpdateOrder(string id)
        {
            ViewBag.Customers = orderService.GetCustomers();
            ViewBag.Providers = orderService.GetProviders();
            OrderViewModel order = await orderService.UpdateById(id);

            if (order == null)
            {
                return NotFound();
            }

            return View(order);
        }

        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public async Task<IActionResult> UpdateOrder(OrderViewModel model)
        {
            bool orderExists = await OrderExists(model.Id!);

            if (orderExists)
            {
               TempData["success"] = "Order updated successfully";
               await orderService.UpdateAsync(model);
               return RedirectToAction(nameof(Index));
            }

            else
            {
               ModelState.AddModelError(string.Empty, "Order not found");
            }

            return View(model);
        }
        
        private async Task<bool> OrderExists(string id)
        {
            return await orderService.OrderExists(id);
        }
    }
}
