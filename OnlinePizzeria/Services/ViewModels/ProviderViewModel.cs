using OnlinePizzeria.Model;

namespace OnlinePizzeria.Services.ViewModels
{
    public class ProviderViewModel
    {
        public string? ProviderId { get; set; }
        public string Name { get; set; }
        public string PhoneNumber { get; set; }
        public string Veliche { get; set; }
        public bool IsAvailable { get; set; }
        public double Rating { get; set; }
        public ICollection<Order> DeliveredOrders { get; set; }
    }
}
