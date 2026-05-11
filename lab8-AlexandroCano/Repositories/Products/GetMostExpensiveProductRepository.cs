using lab8_AlexandroCano.Data;
using lab8_AlexandroCano.DTOs.Products;
using lab8_AlexandroCano.Repositories.Products.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace lab8_AlexandroCano.Repositories.Products;

public class GetMostExpensiveProductRepository(AppDbContext context) : IGetMostExpensiveProductRepository
{
    public async Task<ProductDto?> ExecuteAsync()
    {
        return await context.Products
            .AsNoTracking()
            .OrderByDescending(p => p.Price)
            .Select(p => new ProductDto
            {
                ProductId = p.ProductId,
                Name = p.Name,
                Description = p.Description,
                Price = p.Price
            })
            .FirstOrDefaultAsync();
    }
}
