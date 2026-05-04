using lab8_AlexandroCano.Data;
using lab8_AlexandroCano.Models;
using lab8_AlexandroCano.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace lab8_AlexandroCano.Repositories;

public class ProductRepository : IProductRepository
{
    private readonly AppDbContext _context;

    public ProductRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Product>> GetProductsByPriceAsync(decimal minPrice)
    {
        return await _context.Products
            .Where(p => p.Price > minPrice)
            .ToListAsync();
    }

    public async Task<Product?> GetMostExpensiveProductAsync()
    {
        return await _context.Products
            .OrderByDescending(p => p.Price)
            .FirstOrDefaultAsync();
    }

    public async Task<decimal> GetAveragePriceAsync()
    {
        return await _context.Products
            .AverageAsync(p => p.Price);
    }

    public async Task<IEnumerable<Product>> GetProductsWithoutDescriptionAsync()
    {
        return await _context.Products
            .Where(p => string.IsNullOrEmpty(p.Description))
            .ToListAsync();
    }

    public async Task<IEnumerable<object>> GetProductsSoldToClientAsync(int clientId)
    {
        return await _context.Orders
            .Where(o => o.ClientId == clientId)
            .SelectMany(o => o.OrderDetails)
            .Include(od => od.Product)
            .Select(od => new
            {
                od.Product.ProductId,
                od.Product.Name,
                od.Product.Price,
                od.Quantity
            })
            .ToListAsync();
    }
}