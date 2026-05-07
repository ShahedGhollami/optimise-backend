using Optimise.Api.Models;

namespace Optimise.Api.Services;

public interface IProductService
{
    Task<IEnumerable<Product>> GetProductsAsync(string code, string partOfDescription);
}