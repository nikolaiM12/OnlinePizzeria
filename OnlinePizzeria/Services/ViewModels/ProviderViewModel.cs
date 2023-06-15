using OnlinePizzeria.Model;
using System.ComponentModel.DataAnnotations;

namespace OnlinePizzeria.Services.ViewModels
{
    public class ProviderViewModel
    {
        public string? Id { get; set; }
        [Required(ErrorMessage = "Name is required")]
        [RegularExpression(@"^[A-Za-z]+(\s[A-Za-z]+)?$", ErrorMessage = "Only alphabetic characters are allowed.")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Phone number is required")]
        [RegularExpression(@"^\(?([0-9]{3})\)?[-.●]?([0-9]{3})[-.●]?([0-9]{4})$", ErrorMessage = "Invalid phone number")]
        public string PhoneNumber { get; set; }
        [Required(ErrorMessage = "Veliche is required")]
        public string Veliche { get; set; }
        public bool IsAvailable { get; set; }
        public double Rating { get; set; }
        public List<Order> Order { get; set; }
    }
}
