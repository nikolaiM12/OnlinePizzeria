using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlinePizzeria.Model
{
    public class CreditCardPayment
    {
        [Key]
        public string? CreditCardPaymentId { get; set; }
        public string CardNumber { get; set; }
        public string ExpirationDate { get; set; }
        public string CVV { get; set; }
        public float Amount { get; set; }
        public Customer Customer { get; set; }
        public Order Order { get; set; }
    }
}
