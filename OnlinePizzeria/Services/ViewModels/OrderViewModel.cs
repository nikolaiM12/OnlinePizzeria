using OnlinePizzeria.Data.DataModels;
using OnlinePizzeria.Model;
using System.ComponentModel.DataAnnotations;

namespace OnlinePizzeria.Services.ViewModels
{
    public class OrderViewModel
    {
        public string Id { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public DateTime OrderDate { get; set; }
        public float Price { get; set; }
        public virtual Provider Provider { get; set; }
        public string ProviderId { get; set; }
        public virtual Customer Customer { get; set; }
        public string CustomerId { get; set; }
        public List<PizzaModel> Pizzas { get; set; }
        public List<CustomPizza> CustomPizzas { get; set; }
    }
}
