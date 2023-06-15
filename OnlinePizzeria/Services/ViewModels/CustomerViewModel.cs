using OnlinePizzeria.Data;
using OnlinePizzeria.Model;
using OnlinePizzeria.Services.Interfaces;
using System.ComponentModel.DataAnnotations;

namespace OnlinePizzeria.Services.ViewModels
{
    public class CustomerViewModel
    {
        public string? Id { get; set; }
        [Required(ErrorMessage= "First Name is required")]
        [RegularExpression(@"^[A-Za-z]+$", ErrorMessage = "Only alphabetic characters are allowed.")]
        public string FirstName { get; set; }
        [Required(ErrorMessage = "Last Name is required")]
        [RegularExpression(@"^[A-Za-z]+$", ErrorMessage = "Only alphabetic characters are allowed.")]
        public string LastName { get; set; }
        [Required(ErrorMessage = "Address is required")]
        public string Address { get; set; }
        [Required(ErrorMessage = "Phone number is required")]
        [RegularExpression(@"^\(?([0-9]{3})\)?[-.●]?([0-9]{3})[-.●]?([0-9]{4})$", ErrorMessage = "Invalid phone number")]
        public string PhoneNumber { get; set; }
        [Required(ErrorMessage = "Email is required")]
        public string Email { get; set; }
        public List<Order> Order { get; set; }
        
    }
}
