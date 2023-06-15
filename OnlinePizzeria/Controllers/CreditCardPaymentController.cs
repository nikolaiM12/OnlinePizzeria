using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OnlinePizzeria.Services;
using OnlinePizzeria.Services.Interfaces;
using OnlinePizzeria.Services.ViewModels;

namespace OnlinePizzeria.Controllers
{
	public class CreditCardPaymentController : Controller
	{
        public CreditCardPaymentService paymentService { get; set; }
        public CreditCardPaymentController(CreditCardPaymentService service)
        {
            paymentService = service;
        }
        [Authorize(Roles = "User")]
        [HttpGet]
        public IActionResult Index()
        {
            List<CreditCardPaymentViewModel> payments = paymentService.GetAll();
            return View(payments);
        }

        [HttpGet]
        public IActionResult Details(string id)
        {
            ViewBag.Customers = paymentService.GetCustomers();
            ViewBag.Orders = paymentService.GetOrders();
            CreditCardPaymentViewModel payments = paymentService.GetDetailsById(id);
            bool isCourseNull = payments == null;
            if (isCourseNull)
            {
                return NotFound();
            }

            return this.View(payments);
        }
        [HttpGet]
        public IActionResult AddPayment()
        {
            ViewBag.Customers = paymentService.GetCustomers();
            ViewBag.Orders = paymentService.GetOrders();
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddPayment(CreditCardPaymentViewModel payment)
        {
            if (ModelState.IsValid)
            {
                return View(payment);
            }
            TempData["success"] = "Payment added successfully";
            await paymentService.CreateAsync(payment);
            return RedirectToAction(nameof(Index));
        }
        [HttpGet]
        public IActionResult DeletePayment()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeletePayment(string id)
        {
            CreditCardPaymentViewModel payment = paymentService.GetDetailsById(id);
            if (payment == null)
            {
                return NotFound();
            }
            TempData["success"] = "Payment deleted successfully";
            await paymentService.DeletePayment(id);
            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public async Task<IActionResult> UpdatePayment(string id)
        {
            ViewBag.Customers = paymentService.GetCustomers();
            ViewBag.Orders = paymentService.GetOrders();
            CreditCardPaymentViewModel payment = await paymentService.UpdateById(id);

            if (payment == null)
            {
                return NotFound();
            }

            return View(payment);
        }

        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public async Task<IActionResult> UpdatePayment(CreditCardPaymentViewModel model)
        {
            if (!ModelState.IsValid)
            {
                bool paymentExists = await PaymentExists(model.Id!);

                if (paymentExists)
                {
                    TempData["success"] = "Payment updated successfully";
                    await paymentService.UpdateAsync(model);
                    return RedirectToAction(nameof(Index));
                }
                else
                {
                    ModelState.AddModelError(string.Empty, "Payment not found");
                }
            }

            return View(model);
        }
        private async Task<bool> PaymentExists(string id)
        {
            return await paymentService.PaymentExists(id);
        }
    }
}
