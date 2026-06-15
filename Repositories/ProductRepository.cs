

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
}