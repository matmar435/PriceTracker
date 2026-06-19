namespace Product_Price_Tracker.DTO
{
    public class ProductDto
    {
        public Guid Id { get; set; }

        public string Name { get; set; } = string.Empty;

        public decimal CurrentPrice { get; set; }

        public decimal TargetPrice { get; set; }
    }
}
