

using Microsoft.AspNetCore.Mvc;
using Product_Price_Tracker.DTO;

[ApiController]
[Route("api/products")]
public class ProductsController : ControllerBase
{
	private readonly ProductService _service;

	public ProductsController(ProductService service)
	{
		_service = service;
	}

	[HttpGet]
	public async Task<IActionResult> GetAll()
	{
		var products = await _service.GetAllAsync();
		return Ok(products);
	}

    [HttpPost]
    public async Task<IActionResult> Create(CreateProductDto dto)
    {
        await _service.CreateAsync(dto);

        return Created();
    }

    [HttpGet("{id:guid}")]
    public async Task<IActionResult> GetById(Guid id)
    {
        var product = await _service.GetByIdAsync(id);

        if (product is null)
        {
            return NotFound($"Product with id {id} not found.");
        }

        return Ok(product);
    }

    [HttpDelete("{id:guid}")]
    public async Task<IActionResult> Delete(Guid id)
    {
        var deleted = await _service.DeleteAsync(id);

        if (!deleted)
        {
            return NotFound();
        }

        return NoContent();
    }

    [HttpGet("{id:guid}/history")]
    public async Task<IActionResult> GetHistory(Guid id)
    {
        var history = await _service.GetPriceHistoryAsync(id);

        return Ok(history);
    }
}