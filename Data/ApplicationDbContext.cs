using Microsoft.EntityFrameworkCore;
using Product_Price_Tracker.Entities;

namespace Product_Price_Tracker.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(
            DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Product> Products => Set<Product>();
        public DbSet<PriceHistory> PriceHistories { get; set; }
    }
}
