using Microsoft.AspNetCore.Mvc;
using OnlinePizzeria.Data;
using OnlinePizzeria.Model;
using OnlinePizzeria.Services;
using OnlinePizzeria.Services.ViewModels;

namespace OnlinePizzeria.Controllers
{
    public class PizzaModelController : Controller
    {
        public PizzaModelService pizzaService { get; set; }

        public PizzaModelController(PizzaModelService service)
        {
            pizzaService = service;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult CustomPizzaIndex()
        {
            return View();
        }
        public IActionResult CreditCardIndex(PizzaViewModel pizza, WeightOptionViewModel weight, ProductWeightViewModel product)
        {
            pizza.FinalPrice = pizzaService.CalculateCustomPizza(pizza, weight, product);
            return RedirectToAction("~/Views/CreditCardPayment/CreditCardIndex.cshtml", new { pizza.PizzaName, pizza.FinalPrice });
        }
    }
}