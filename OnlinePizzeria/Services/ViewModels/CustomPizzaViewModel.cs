using OnlinePizzeria.Model;

namespace OnlinePizzeria.Services.ViewModels
{
    public class CustomPizzaViewModel
    {
        public string Id { get; set; }
        public string PizzaName { get; set; }
        public float BasePrice { get; set; }
        public bool TomatoSauce { get; set; }
        public bool Cheese { get; set; }
        public bool Peperoni { get; set; }
        public bool Mushroom { get; set; }
        public bool Tuna { get; set; }
        public bool Pineapple { get; set; }
        public bool Ham { get; set; }
        public bool Beef { get; set; }
        public float FinalPrice { get; set; }
        public float Price { get; set; }
        public Order Order { get; set; }
        public string OrderId { get; set; }
    }
}
