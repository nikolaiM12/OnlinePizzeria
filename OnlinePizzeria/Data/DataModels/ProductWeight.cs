namespace OnlinePizzeria.Data.DataModels
{
    public class ProductWeight
    {
        public string? Id { get; set; }
        public string? PizzaModelId { get; set; }
        public float TomatoWeight { get; set; }
        public float CheeseWeight { get; set; }
        public float PeperoniWeight { get; set; }
        public float MushroomWeight { get; set; }
        public float TunaWeight { get; set; }
        public float PineappleWeight { get; set; }
        public float HamWeight { get; set; }
        public float BeefWeight { get; set; }
    }
}
