using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OnlinePizzeria.Model;
using OnlinePizzeria.Services;
using OnlinePizzeria.Services.Interfaces;
using OnlinePizzeria.Services.ViewModels;

namespace OnlinePizzeria.Controllers
{
    public class CustomerController : Controller
    {
        public CustomerService customerService { get; set; }
        public CustomerController(CustomerService service)
        {
            customerService = service;
        }
        [Authorize(Roles = "User")]
        [HttpGet]
        public IActionResult Index()
        {
            List<CustomerViewModel> customers = customerService.GetAll();
            return View(customers);
        }

        [HttpGet]
        public IActionResult Details(string id)
        {
            CustomerViewModel customer = customerService.GetDetailsById(id);
            bool isCourseNull = customer == null;
            if (isCourseNull)
            {
                return NotFound();
            }

            return this.View(customer);
        }
        [HttpGet]
        public IActionResult AddCustomer()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddCustomer(CustomerViewModel customer)
        {
            if (ModelState.IsValid)
            {
                return View(customer);
            }
            TempData["success"] = "Customer added successfully";
            await customerService.CreateAsync(customer);
            return RedirectToAction(nameof(Index));
        }
        [HttpGet]
        public IActionResult DeleteCustomer()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteCustomer(string id)
        {
            CustomerViewModel customer = customerService.GetDetailsById(id);
            if (customer == null)
            {
                return NotFound();
            }
            TempData["success"] = "Customer deleted successfully";
            await customerService.DeleteCustomer(id);
            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public async Task<IActionResult> UpdateCustomer(string id)
        {
            CustomerViewModel customer = await customerService.UpdateById(id);

            if (customer == null)
            {
                return NotFound();
            }

            return View(customer);
        }

        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public async Task<IActionResult> UpdateCustomer(CustomerViewModel model)
        {
            if (!ModelState.IsValid)
            {
                bool customerExists = await CustomerExists(model.Id!);

                if (customerExists)
                {
                    TempData["success"] = "Customer updated successfully";
                    await customerService.UpdateAsync(model);
                    return RedirectToAction(nameof(Index));
                }
                else
                {
                    ModelState.AddModelError(string.Empty, "Customer not found");
                }
            }
            return View(model);
        }
        private async Task<bool> CustomerExists(string id)
        {
            return await customerService.CustomerExists(id);
        }
    }
}
