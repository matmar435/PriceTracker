
using Microsoft.EntityFrameworkCore;
using Product_Price_Tracker.DTO;
using Product_Price_Tracker.Entities;
using Product_Price_Tracker.Provider.Interfaces;
using Product_Price_Tracker.Services.Interfaces;

public class ProductService
{
    private readonly IProductRepository _repo;
    private readonly IPriceProvider _priceProvider;

    public ProductService(IProductRepository repo, IPriceProvider priceProvider)
    {
        _repo = repo;
        _priceProvider = priceProvider;
    }

    public async Task<List<ProductDto>> GetAllAsync()
    {
        var products = await _repo.GetAllAsync();

        return products.Select(p => new ProductDto
        {
            Id = p.Id,
            Name = p.Name,
            CurrentPrice = p.CurrentPrice,
            TargetPrice = p.TargetPrice
        }).ToList();
    }

    public async Task CreateAsync(CreateProductDto dto)
    {
        var currentPrice = await _priceProvider.GetCurrentPriceAsync(dto.Url) ?? 0;

        var product = new Product
        {
            Id = Guid.NewGuid(),
            Name = dto.Name,
            Url = dto.Url,
            TargetPrice = dto.TargetPrice,
            CurrentPrice =currentPrice,
            CreatedAt = DateTime.UtcNow
        };

        await _repo.AddAsync(product);
        await _repo.SaveChangesAsync();

        var history = new PriceHistory
        {
            Id = Guid.NewGuid(),
            ProductId = product.Id,
            Price = currentPrice,
            CheckedAt = DateTime.UtcNow
        };

        await _repo.AddPriceHistoryAsync(history);
        await _repo.SaveChangesAsync();
    }

    public async Task<ProductDto> GetByIdAsync(Guid id)
    {
        var product = await _repo.GetByIdAsync(id);

        if (product is null)
        {
            return null;
        }

        return new ProductDto
        {
            Id = product.Id,
            Name = product.Name,
            CurrentPrice = product.CurrentPrice,
            TargetPrice = product.TargetPrice
        };
    }

    public async Task<bool> DeleteAsync(Guid id)
    {
        var product = await _repo.GetByIdAsync(id);

        if (product is null)
        {
            return false;
        }

        await _repo.DeleteAsync(product);
        await _repo.SaveChangesAsync();

        return true;
    }
}