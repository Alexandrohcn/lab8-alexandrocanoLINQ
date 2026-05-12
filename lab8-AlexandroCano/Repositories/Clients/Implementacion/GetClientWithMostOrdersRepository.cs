using lab8_AlexandroCano.Data;
using lab8_AlexandroCano.DTOs.Clients;
using lab8_AlexandroCano.Repositories.Clients.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace lab8_AlexandroCano.Repositories.Clients.Implementacion;

public class GetClientWithMostOrdersRepository(AppDbContext context) : IGetClientWithMostOrdersRepository
{
    public async Task<ClientWithMostOrdersDto?> ExecuteAsync()
    {
        return await context.Orders
            .AsNoTracking()
            .GroupBy(o => o.ClientId)
            .Select(g => new
            {
                ClientId = g.Key,
                OrderCount = g.Count()
            })
            .OrderByDescending(x => x.OrderCount)
            .Join(context.Clients,
                orderGroup => orderGroup.ClientId,
                client => client.ClientId,
                (orderGroup, client) => new ClientWithMostOrdersDto
                {
                    ClientId = client.ClientId,
                    Name = client.Name,
                    Email = client.Email,
                    OrderCount = orderGroup.OrderCount
                })
            .FirstOrDefaultAsync();
    }
}
