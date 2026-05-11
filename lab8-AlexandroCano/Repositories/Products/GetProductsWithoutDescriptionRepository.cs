using lab8_AlexandroCano.Data;
using lab8_AlexandroCano.DTOs.Products;
using lab8_AlexandroCano.Repositories.Products.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace lab8_AlexandroCano.Repositories.Products;

public class GetProductsWithoutDescriptionRepository(AppDbContext context) : IGetProductsWithoutDescriptionRepository
{
    public async Task<IEnumerable<ProductDto>> ExecuteAsync()
    {
        return await context.Products
            .AsNoTracking()
            .Where(p => p.Description == null || p.Description == "")
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
