

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
		var products = await _service.GetAll();
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
            return NotFound();
        }

        return Ok(product);
    }
}