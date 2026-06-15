

using Microsoft.AspNetCore.Mvc;

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
}