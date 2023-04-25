﻿namespace OnlinePizzeria.Data.DataModels
{
    public class WeightOption
    {
        public string? Id { get; set; }
        public string? PizzaModelId { get; set; }
        public enum Choice
        {
            None,
            ExtraLight,
            Light,
            Normal,
            Heavy,
            ExtraHeavy
        }
        public Choice Option { get; set; }
        public enum Product
        {
            TomatoWeight,
            CheeseWeight,
            PeperoniWeight,
            MushroomWeight,
            TunaWeight,
            PineappleWeight,
            HamWeight,
            BeefWeight
        }
        public Product Products { get; set; }
    }
}