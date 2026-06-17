using System.ComponentModel.DataAnnotations;

namespace Product_Price_Tracker.DTO
{
    public class CreateProductDto
    {
        [Required]
        [StringLength(200)]
        public string Name { get; set; } = string.Empty;

        [Required]
        [Url]
        public string Url { get; set; } = string.Empty;

        [Range(0.01, double.MaxValue)]
        public decimal TargetPrice { get; set; }
    }
}
