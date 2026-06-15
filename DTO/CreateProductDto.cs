namespace Product_Price_Tracker.DTO
{
    public class CreateProductDto
    {
        public string Name { get; set; } = string.Empty;

        public string Url { get; set; } = string.Empty;

        public decimal TargetPrice { get; set; }
    }
}
