using OnlinePizzeria.Data.DataModels;
using OnlinePizzeria.Data.DataModels.Base;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OnlinePizzeria.Model
{
    public class Order : BaseClass
    {
        public string Address { get; set; }
        public string City { get; set; }
        public DateTime OrderDate { get; set; }
        public float Price { get; set; }
        public Provider Provider { get; set; }
        public string ProviderId { get; set; }
        public List<PizzaModel> Pizzas { get; set; }
        public List<CustomPizza> CustomPizzas { get; set; }
        public Customer Customer { get; set; }
        public string CustomerId { get; set; }
    }
}