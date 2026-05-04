using lab8_AlexandroCano.Data;
using lab8_AlexandroCano.Models;
using lab8_AlexandroCano.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace lab8_AlexandroCano.Repositories;

public class ClientRepository : IClientRepository
{
    private readonly AppDbContext _context;

    public ClientRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Client>> GetClientsByNameAsync(string name)
    {
        return await _context.Clients
            .Where(c => c.Name.Contains(name))
            .ToListAsync();
    }

    public async Task<object?> GetClientWithMostOrdersAsync()
    {
        return await _context.Orders
            .GroupBy(o => o.ClientId)
            .Select(g => new
            {
                ClientId = g.Key,
                OrderCount = g.Count()
            })
            .OrderByDescending(x => x.OrderCount)
            .Join(_context.Clients,
                orderGroup => orderGroup.ClientId,
                client => client.ClientId,
                (orderGroup, client) => new
                {
                    client.ClientId,
                    client.Name,
                    client.Email,
                    orderGroup.OrderCount
                })
            .FirstOrDefaultAsync();
    }

    public async Task<IEnumerable<object>> GetClientsWhoBoughtProductAsync(int productId)
    {
        return await _context.OrderDetails
            .Where(od => od.ProductId == productId)
            .Include(od => od.Order)
            .ThenInclude(o => o.Client)
            .Select(od => new
            {
                od.Order.Client.ClientId,
                od.Order.Client.Name,
                od.Order.Client.Email
            })
            .Distinct()
            .ToListAsync();
    }
}