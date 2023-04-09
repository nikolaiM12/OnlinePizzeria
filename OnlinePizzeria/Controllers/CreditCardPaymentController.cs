using Microsoft.AspNetCore.Mvc;

namespace OnlinePizzeria.Controllers
{
    public class CreditCardPaymentController : Controller
    {
        public IActionResult CreditCardIndex()
        {
            return View();
        }
    }
}
