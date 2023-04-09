namespace OnlinePizzeria.Data.DataModels
{
    public class PizzaSize
    {
        public string? Id { get; set; }
        public string? PizzaModelId { get; set; }
        public enum SizeType
        {
            Small,
            Medium,
            Large,
        }
        public SizeType Size { get; set; }

    }
}
