using Microsoft.EntityFrameworkCore;
using Optimise.Api.Models;

namespace Optimise.Api.Data;

public class ProductRepository(OptimiseDbContext context) : IProductRepository
{
    private readonly OptimiseDbContext _context = context;

    public async Task<IEnumerable<Product>> GetProductsAsync(string? code, string? partOfDescription)
    {
        var query = _context.Products.AsQueryable();

        if (!string.IsNullOrWhiteSpace(code))
        {
            query = query.Where(p => p.Code.Contains(code));
        }

        if (!string.IsNullOrWhiteSpace(partOfDescription))
        {
            query = query.Where(p => p.Description.Contains(partOfDescription));
        }

        return await query.ToListAsync();
    }

    public async Task<Product?> GetProductByCodeAsync(string code)
    {
        return await _context.Products.FindAsync(code);
    }

    public async Task AddProductAsync(Product product)
    {
        await _context.Products.AddAsync(product);
        await _context.SaveChangesAsync();
    }

    public async Task UpdateProductAsync(Product product)
    {
        _context.Products.Update(product);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteProductAsync(string code)
    {
        var product = await _context.Products.FindAsync(code);
        if (product != null)
        {
            _context.Products.Remove(product);
            await _context.SaveChangesAsync();
        }
    }
}