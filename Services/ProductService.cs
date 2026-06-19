
using Product_Price_Tracker.DTO;
using Product_Price_Tracker.Entities;

public class ProductService
{
    private readonly IProductRepository _repo;

    public ProductService(IProductRepository repo)
    {
        _repo = repo;
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
        var product = new Product
        {
            Id = Guid.NewGuid(),
            Name = dto.Name,
            Url = dto.Url,
            TargetPrice = dto.TargetPrice,
            CurrentPrice = 0,
            CreatedAt = DateTime.UtcNow
        };

        await _repo.AddAsync(product);
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