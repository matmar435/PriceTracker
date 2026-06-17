
using Product_Price_Tracker.DTO;
using Product_Price_Tracker.Entities;

public class ProductService
{
    private readonly IProductRepository _repo;

    public ProductService(IProductRepository repo)
    {
        _repo = repo;
    }

    public Task<List<Product>> GetAll()
        => _repo.GetAllAsync();

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

    public async Task<Product?> GetByIdAsync(Guid id)
    {
        return await _repo.GetByIdAsync(id);
    }
}