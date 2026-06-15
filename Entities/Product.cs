namespace Product_Price_Tracker.Entities
{
    public class Product
    {
        public Guid Id { get; set; }

        public string Name { get; set; } = string.Empty;

        public string Url { get; set; } = string.Empty;

        public decimal TargetPrice { get; set; }

        public decimal CurrentPrice { get; set; }

        public DateTime CreatedAt { get; set; }
    }
}
