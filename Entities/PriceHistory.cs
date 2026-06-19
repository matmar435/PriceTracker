namespace Product_Price_Tracker.Entities
{
    public class PriceHistory
    {
        public Guid Id { get; set; }

        public Guid ProductId { get; set; }

        public decimal Price { get; set; }

        public DateTime CheckedAt { get; set; }

        public Product Product { get; set; } = null!;
    }
}
