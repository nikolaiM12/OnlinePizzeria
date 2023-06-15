using OnlinePizzeria.Model;
using System.ComponentModel.DataAnnotations;

namespace OnlinePizzeria.Services.ViewModels
{
    public class PizzaViewModel
    {
        public string Id { get; set; }
        public string ImageTitle { get; set; }
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
        public string Description { get; set; }
        public string ImageUrl { get; set; }
        [Display(Name = "Image File")]
        public IFormFile ImageFile { get; set; }
        public byte[] ImageData { get; set; }
        public float Price { get; set; }
        public Order Order { get; set; }
        public string OrderId { get; set; }
    }
}

