using Optimise.Api.Models;

namespace Optimise.Api.Data;

public interface IProductRepository
{
    Task<IEnumerable<Product>> GetProductsAsync(string? code, string? partOfDescription);
    Task<Product?> GetProductByCodeAsync(string code);
    Task AddProductAsync(Product product);
    Task UpdateProductAsync(Product product);
    Task DeleteProductAsync(string code);
}