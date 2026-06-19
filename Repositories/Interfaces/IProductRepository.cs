

using Product_Price_Tracker.Entities;

public interface IProductRepository
{
    Task<List<Product>> GetAllAsync();
    Task AddAsync(Product product);
    Task SaveChangesAsync();
    Task<Product?> GetByIdAsync(Guid id);
    Task DeleteAsync(Product product);
    Task AddPriceHistoryAsync(PriceHistory history);
    Task<List<PriceHistory>> GetPriceHistoryAsync(Guid productId);
}