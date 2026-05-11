using lab8_AlexandroCano.Data;
using lab8_AlexandroCano.DTOs.Products;
using lab8_AlexandroCano.Repositories.Products.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace lab8_AlexandroCano.Repositories.Products;

public class GetProductsSoldToClientRepository(AppDbContext context) : IGetProductsSoldToClientRepository
{
    public async Task<IEnumerable<ProductSoldToClientDto>> ExecuteAsync(int clientId)
    {
        return await context.Orders
            .AsNoTracking()
            .Where(o => o.ClientId == clientId)
            .SelectMany(o => o.OrderDetails)
            .Select(od => new ProductSoldToClientDto
            {
                ProductId = od.Product.ProductId,
                Name = od.Product.Name,
                Price = od.Product.Price,
                Quantity = od.Quantity
            })
            .ToListAsync();
    }
}
