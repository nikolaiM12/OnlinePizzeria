using OnlinePizzeria.Model;

namespace OnlinePizzeria.Services.ViewModels
{
    public class CreditCardPaymentViewModel
    {
        public string? CreditCardPaymentId { get; set; }
        public string CardNumber { get; set; }
        public string ExpirationDate { get; set; }
        public string CVV { get; set; }
        public float Amount { get; set; }
        public Customer Customer { get; set; }
        public Order Order { get; set; }
    }
}
