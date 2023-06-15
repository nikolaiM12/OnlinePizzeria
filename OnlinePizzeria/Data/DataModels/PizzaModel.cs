using OnlinePizzeria.Data.DataModels.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlinePizzeria.Model
{
    public class PizzaModel : BaseClass
    {
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
        public byte[] ImageData { get; set; }
        public float Price { get; set; }
        public Order Order { get; set; }
        public string OrderId { get; set; }
    }
}
