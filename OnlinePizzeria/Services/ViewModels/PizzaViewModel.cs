﻿using OnlinePizzeria.Data.DataModels;
using OnlinePizzeria.Model;
using System.ComponentModel.DataAnnotations;

namespace OnlinePizzeria.Services.ViewModels
{
    public class PizzaViewModel
    {
        public string? PizzaModelId { get; set; }
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
        public virtual PizzaSize PizzaSize { get; set; }
        public virtual WeightOption WeightOption { get; set; }
        
    }
}
