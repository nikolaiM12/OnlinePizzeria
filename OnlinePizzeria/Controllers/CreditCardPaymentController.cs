using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OnlinePizzeria.Model;
using OnlinePizzeria.Services;
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
        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public IActionResult AddPayment()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddPayment([Bind("CardNumber, CVV, ExpirationDate, Amount, Order, Customer")]
        CreditCardPaymentViewModel paymentVM)
        {
            await paymentService.CreateAsync(paymentVM);
            return RedirectToAction(nameof(Index));
        }
        [HttpGet]
        public IActionResult DeletePayment()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeletePayment(string creditCardPaymentId,
            [Bind("CardNumber, CVV, ExpirationDate, Amount, Order, Customer")]
        CreditCardPaymentViewModel paymentVM)
        {
            await paymentService.DeletePayment(creditCardPaymentId);
            return RedirectToAction(nameof(Index));
        }
    }
}
