using OnlinePizzeria.Model;

namespace OnlinePizzeria.Services.ViewModels
{
    public class OrderViewModel
    {
        public string? OrderId { get; set; }
        public Customer Customer { get; set; }
        public ICollection<PizzaModel> Pizza { get; set; }
        public float BasePrice { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public DateTime OrderDate { get; set; }
        public Provider Provider { get; set; }
        public bool IsDelivered { get; set; }
    }
}
