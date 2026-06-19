

using Microsoft.EntityFrameworkCore;
using Product_Price_Tracker.Data;
using Product_Price_Tracker.Entities;

public class ProductRepository : IProductRepository
{
    private readonly ApplicationDbContext _context;

    public ProductRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<List<Product>> GetAllAsync()
        => await _context.Products.ToListAsync();

    public async Task AddAsync(Product product)
    {
        await _context.Products.AddAsync(product);
    }

    public async Task SaveChangesAsync()
    {
        await _context.SaveChangesAsync();
    }

    public async Task<Product?> GetByIdAsync(Guid id)
    {
        return await _context.Products.FindAsync(id);
    }

    public Task DeleteAsync(Product product)
    {
        _context.Products.Remove(product);
        return Task.CompletedTask;
    }

    public async Task AddPriceHistoryAsync(PriceHistory history)
    {
        await _context.PriceHistories.AddAsync(history);
    }

    public async Task<List<PriceHistory>> GetPriceHistoryAsync(Guid productId)
    {
        return await _context.PriceHistories
            .Where(p => p.ProductId == productId)
            .OrderByDescending(p => p.CheckedAt)
            .ToListAsync();
    }
}