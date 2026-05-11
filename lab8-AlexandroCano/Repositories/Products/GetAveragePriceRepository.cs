using lab8_AlexandroCano.Data;
using lab8_AlexandroCano.Repositories.Products.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace lab8_AlexandroCano.Repositories.Products;

public class GetAveragePriceRepository(AppDbContext context) : IGetAveragePriceRepository
{
    public async Task<decimal> ExecuteAsync()
    {
        if (!await context.Products.AnyAsync())
        {
            return 0m;
        }

        return await context.Products
            .AsNoTracking()
            .AverageAsync(p => p.Price);
    }
}
