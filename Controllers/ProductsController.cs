using Microsoft.AspNetCore.Mvc;
using Optimise.Api.Services;

namespace Optimise.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ProductsController(IProductService productService) : ControllerBase
{
    private readonly IProductService _productService = productService;

    [HttpGet]
    public async Task<IActionResult> GetProducts(
        [FromQuery] string? code = null,
        [FromQuery] string? partOfDescription = null)
    {
        var products = await _productService.GetProductsAsync(code, partOfDescription);
        return Ok(products);
    }
}