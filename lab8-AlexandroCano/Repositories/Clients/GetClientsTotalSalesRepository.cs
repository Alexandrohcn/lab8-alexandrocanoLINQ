using lab8_AlexandroCano.Data;
using lab8_AlexandroCano.DTOs.Clients;
using lab8_AlexandroCano.Repositories.Clients.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace lab8_AlexandroCano.Repositories.Clients;

public class GetClientsTotalSalesRepository(AppDbContext context) : IGetClientsTotalSalesRepository
{
    public async Task<IEnumerable<ClientTotalSalesDto>> ExecuteAsync()
    {
        return await context.Orders
            .AsNoTracking()
            .GroupBy(o => new { o.ClientId, o.Client.Name })
            .Select(g => new ClientTotalSalesDto
            {
                ClientId = g.Key.ClientId,
                Name = g.Key.Name,
                TotalSales = g.SelectMany(o => o.OrderDetails)
                              .Sum(od => od.Quantity * od.Product.Price)
            })
            .OrderByDescending(x => x.TotalSales)
            .ToListAsync();
    }
}
