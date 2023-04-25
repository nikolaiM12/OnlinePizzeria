using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.View;
using OnlinePizzeria.Data;
using OnlinePizzeria.Model;
using OnlinePizzeria.Models;
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
            return this.View();
        }

        public IActionResult CustomPizza()
        {
            return View();
        }
        [HttpPost]
        public IActionResult OrderIndex(PizzaViewModel pizza, WeightOptionViewModel weight)
        {
            pizza.FinalPrice = pizzaService.CalculateCustomPizza(pizza, weight);
            return RedirectToAction("~/Views/Order/Index.cshtml", new {pizza.PizzaName, pizza.FinalPrice});
        }
        //[HttpGet]
        //public IActionResult Details(string id)
        //{
        //    PizzaViewModel pizza = pizzaService.GetDetailsById(id);

        //    bool isCourseNull = pizza == null;
        //    if (isCourseNull)
        //    {
        //        return this.RedirectToAction("Index");
        //    }

        //    return this.View(pizza);
        //}
    }
}