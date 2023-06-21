using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.View;
using OnlinePizzeria.Data;
using OnlinePizzeria.Model;
using OnlinePizzeria.Models;
using OnlinePizzeria.Services;
using OnlinePizzeria.Services.Interfaces;
using OnlinePizzeria.Services.ViewModels;

namespace OnlinePizzeria.Controllers
{
    public class PizzaModelController : Controller
    {
        private readonly PizzaModelService pizzaService;

        public PizzaModelController(PizzaModelService service)
        {
            pizzaService = service;
        }
        [Authorize(Roles = "User")]
        [HttpGet]
        public IActionResult Index()
        {
            List<PizzaViewModel> pizzas = pizzaService.GetAll();
            return View(pizzas);
        }

        [HttpGet]
        public IActionResult Details(string id)
        {
            ViewBag.Orders = pizzaService.GetOrders();
            PizzaViewModel pizza = pizzaService.GetDetailsById(id);
            bool isPizzaNull = pizza == null;
            if (isPizzaNull)
            {
                return NotFound();
            }

            return View(pizza);
        }

        [HttpGet]
        public IActionResult AddPizza()
        {
            ViewBag.Orders = pizzaService.GetOrders();
            return View();
        }

         [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddPizza(PizzaViewModel pizza, IFormFile imageFile)
        {
            if (pizza == null)
            {
                return BadRequest("Invalid pizza data");
            }

            float price = pizzaService.CalculatePizza(pizza);
            pizza.Price = price;

            if (imageFile != null && imageFile.Length > 0)
            {
                using (var memoryStream = new MemoryStream())
                {
                    await imageFile.CopyToAsync(memoryStream);
                    pizza.ImageData = memoryStream.ToArray();
                }

                ViewBag.Orders = pizzaService.GetOrders();
                await pizzaService.CreateAsync(pizza, imageFile);
                TempData["success"] = "Pizza added successfully";
                return RedirectToAction(nameof(Index));
            }

            else
            {
                ModelState.AddModelError(string.Empty, "No image file provided");
            }

            return View(pizza);
        }

        [HttpGet]
        public IActionResult DeletePizza()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeletePizza(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            await pizzaService.DeletePizza(id);
            TempData["success"] = "Pizza deleted successfully";
            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public async Task<IActionResult> UpdatePizza(string id)
        {
            ViewBag.Orders = pizzaService.GetOrders();
            if (id == null)
            {
                return NotFound();
            }

            PizzaViewModel pizza = await pizzaService.UpdateById(id);
            if (pizza == null)
            {
                return NotFound();
            }

            return View(pizza);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> UpdatePizza(PizzaViewModel model, IFormFile imageFile)
        {
            float price = pizzaService.CalculatePizza(model);
            model.Price = price;

            if (imageFile != null && imageFile.Length > 0)
            {
                using (var memoryStream = new MemoryStream())
                {
                    await imageFile.CopyToAsync(memoryStream);
                    model.ImageData = memoryStream.ToArray();
                }
                await pizzaService.UpdateAsync(model, imageFile);
                TempData["success"] = "Pizza updated successfully";
                return RedirectToAction(nameof(Index));
            }

            else
            {
                ModelState.AddModelError(string.Empty, "No image file provided");
            }

            return View(model);
        }

        [HttpGet]
        public IActionResult PizzaDetails(string id, string imageUrl)
        {
            var pizza = pizzaService.GetDetailsById(id);

            if (pizza == null)
            {
                return NotFound();
            }

            pizza.ImageUrl = imageUrl;

            return View(pizza);
        }
    }
}
