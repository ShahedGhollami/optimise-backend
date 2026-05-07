using Microsoft.EntityFrameworkCore;
using Optimise.Api.Models;

namespace Optimise.Api.Data;

public class OptimiseDbContext(DbContextOptions<OptimiseDbContext> options) : DbContext(options)
{
    public required DbSet<Product> Products { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        // Configure Product entity
        modelBuilder.Entity<Product>(entity =>
        {
            entity.HasKey(e => e.Code);
            entity.Property(e => e.Code).HasMaxLength(50).IsRequired();
            entity.Property(e => e.Description).HasMaxLength(500);
            entity.Property(e => e.Model).HasMaxLength(100);
            entity.Property(e => e.ProductGroup).HasMaxLength(100);
        });
    }
}