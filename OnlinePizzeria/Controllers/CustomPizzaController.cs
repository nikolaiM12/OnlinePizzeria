using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OnlinePizzeria.Services;
using OnlinePizzeria.Services.ViewModels;

namespace OnlinePizzeria.Controllers
{
    public class CustomPizzaController : Controller
    {
        private readonly CustomPizzaService customPizzaService;

        public CustomPizzaController(CustomPizzaService service)
        {
            customPizzaService = service;
        }
        [Authorize(Roles = "User")]
        [HttpGet]
        public IActionResult Index()
        {
            List<CustomPizzaViewModel> pizzas = customPizzaService.GetAll();
            return View(pizzas);
        }

        [HttpGet]
        public IActionResult Details(string id)
        {
            CustomPizzaViewModel pizza = customPizzaService.GetDetailsById(id);
            bool isPizzaNull = pizza == null;
            if (isPizzaNull)
            {
                return NotFound();
            }

            return View(pizza);
        }

        [HttpGet]
        public IActionResult AddCustomPizza()
        {
            ViewBag.Orders = customPizzaService.GetOrders();
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddCustomPizza(CustomPizzaViewModel pizza)
        {
            if (pizza == null)
            {
                return BadRequest("Invalid custom pizza data");
            }
            
            float price = customPizzaService.CalculatePizza(pizza);
            pizza.Price = price;
            await customPizzaService.CreateAsync(pizza);
            TempData["success"] = "Custom pizza added successfully";

            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public IActionResult DeleteCustomPizza()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteCustomPizza(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            await customPizzaService.DeleteCustomPizza(id);
            TempData["success"] = "Custom pizza deleted successfully";
            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public async Task<IActionResult> UpdateCustomPizza(string id)
        {
            ViewBag.Orders = customPizzaService.GetOrders();
            CustomPizzaViewModel pizza = await customPizzaService.UpdateById(id);

            if (pizza == null)
            {
                return NotFound();
            }

            return View(pizza);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> UpdateCustomPizza(CustomPizzaViewModel model)
        {
            bool customPizzaExists = await CustomPizzaExists(model.Id!);

            if (customPizzaExists)
            {
                float price = customPizzaService.CalculatePizza(model);
                model.Price = price;
                await customPizzaService.UpdateAsync(model);
                TempData["success"] = "Custom pizza updated successfully";
                return RedirectToAction(nameof(Index));
            }
            else
            {
                ModelState.AddModelError(string.Empty, "Custom pizza not found");
            }

            return View(model);
        }

        private async Task<bool> CustomPizzaExists(string id)
        {
            return await customPizzaService.CustomPizzaExists(id);
        }
    }
}
