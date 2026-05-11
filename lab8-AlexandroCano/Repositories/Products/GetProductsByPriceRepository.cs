using lab8_AlexandroCano.Data;
using lab8_AlexandroCano.DTOs.Products;
using lab8_AlexandroCano.Repositories.Products.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace lab8_AlexandroCano.Repositories.Products;

public class GetProductsByPriceRepository(AppDbContext context) : IGetProductsByPriceRepository
{
    public async Task<IEnumerable<ProductDto>> ExecuteAsync(decimal minPrice)
    {
        return await context.Products
            .AsNoTracking()
            .Where(p => p.Price > minPrice)
            .Select(p => new ProductDto
            {
                ProductId = p.ProductId,
                Name = p.Name,
                Description = p.Description,
                Price = p.Price
            })
            .ToListAsync();
    }
}
