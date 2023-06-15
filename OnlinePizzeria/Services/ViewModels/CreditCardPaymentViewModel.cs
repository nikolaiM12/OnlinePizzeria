using Microsoft.Build.Framework;
using OnlinePizzeria.Model;
using System.ComponentModel.DataAnnotations;
using RequiredAttribute = System.ComponentModel.DataAnnotations.RequiredAttribute;

namespace OnlinePizzeria.Services.ViewModels
{
    public class CreditCardPaymentViewModel
    {
        public string? Id { get; set; }
        [Required(ErrorMessage = "Card Number is required")]
        [RegularExpression(@"^(?:(?<visa>4[0-9]{3}-?[0-9]{4}-?[0-9]{4}-?[0-9]{4}(?:-?[0-9]{3})?)|(?<mastercard>5[1-5][0-9]{14}))$", 
        ErrorMessage = "Invalid card number")]
        public string CardNumber { get; set; }
        [Required(ErrorMessage = "Expiration Date is required")]
        [RegularExpression(@"^(0[1-9]|1[0-2])\/?([0-9]{4}|[0-9]{2})$",
        ErrorMessage = "Invalid expiration date")]
        public string ExpirationDate { get; set; }
        [Required(ErrorMessage = "CVV is required")]
        [RegularExpression(@"^[0-9]{3,4}$", ErrorMessage = "Invalid CVV")]
        public string CVV { get; set; }
        [Required(ErrorMessage = "Amount is required")]
        public float Amount { get; set; }
        public Customer Customer { get; set; }
        public string CustomerId { get; set; }
        public Order Order { get; set; }
        public string OrderId { get; set; }
    }
}
