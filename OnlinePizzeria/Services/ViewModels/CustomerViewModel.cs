using OnlinePizzeria.Data;
using OnlinePizzeria.Model;
using OnlinePizzeria.Services.Interfaces;

namespace OnlinePizzeria.Services.ViewModels
{
    public class CustomerViewModel
    {
        public string? CustomerId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Address { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public ICollection<Order> Orders { get; set; }
    }
}
