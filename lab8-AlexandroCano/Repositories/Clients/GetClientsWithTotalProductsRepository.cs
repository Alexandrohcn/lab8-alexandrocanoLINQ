using lab8_AlexandroCano.Data;
using lab8_AlexandroCano.DTOs.Clients;
using lab8_AlexandroCano.Repositories.Clients.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace lab8_AlexandroCano.Repositories.Clients;

public class GetClientsWithTotalProductsRepository(AppDbContext context) : IGetClientsWithTotalProductsRepository
{
    public async Task<IEnumerable<ClientTotalProductsDto>> ExecuteAsync()
    {
        var clients = await context.Clients
            .AsNoTracking()
            .Select(c => new { c.ClientId, c.Name })
            .ToListAsync();

        var totals = await context.OrderDetails
            .AsNoTracking()
            .GroupBy(od => od.Order.ClientId)
            .Select(g => new
            {
                ClientId = g.Key,
                TotalProducts = g.Sum(od => od.Quantity)
            })
            .ToListAsync();

        return clients
            .GroupJoin(totals,
                c => c.ClientId,
                t => t.ClientId,
                (c, ts) => new ClientTotalProductsDto
                {
                    ClientId = c.ClientId,
                    Name = c.Name,
                    TotalProducts = ts.Select(t => t.TotalProducts).FirstOrDefault()
                })
            .ToList();
    }
}
