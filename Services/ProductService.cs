using Optimise.Api.Data;
using Optimise.Api.Models;

namespace Optimise.Api.Services;

public class ProductService(IProductRepository productRepository) : IProductService
{
    private readonly IProductRepository _productRepository = productRepository;

    public async Task<IEnumerable<Product>> GetProductsAsync(string code, string partOfDescription)
    {
        return await _productRepository.GetProductsAsync(code, partOfDescription);
    }
}