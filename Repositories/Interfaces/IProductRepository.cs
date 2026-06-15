

using Product_Price_Tracker.Entities;

public interface IProductRepository
{
    Task<List<Product>> GetAllAsync();
}