using lab8_AlexandroCano.Data;
using lab8_AlexandroCano.DTOs.Clients;
using lab8_AlexandroCano.Repositories.Clients.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace lab8_AlexandroCano.Repositories.Clients.Implementacion;

public class GetClientsWhoBoughtProductRepository(AppDbContext context) : IGetClientsWhoBoughtProductRepository
{
    public async Task<IEnumerable<ClientWhoBoughtProductDto>> ExecuteAsync(int productId)
    {
        return await context.OrderDetails
            .AsNoTracking()
            .Where(od => od.ProductId == productId)
            .Select(od => new ClientWhoBoughtProductDto
            {
                ClientId = od.Order.Client.ClientId,
                Name = od.Order.Client.Name,
                Email = od.Order.Client.Email
            })
            .Distinct()
            .ToListAsync();
    }
}
