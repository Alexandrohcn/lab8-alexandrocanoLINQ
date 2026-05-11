using lab8_AlexandroCano.Data;
using lab8_AlexandroCano.DTOs.Clients;
using lab8_AlexandroCano.Repositories.Clients.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace lab8_AlexandroCano.Repositories.Clients;

public class GetClientsByNameRepository(AppDbContext context) : IGetClientsByNameRepository
{
    public async Task<IEnumerable<ClientDto>> ExecuteAsync(string name)
    {
        return await context.Clients
            .AsNoTracking()
            .Where(c => c.Name.Contains(name))
            .Select(c => new ClientDto
            {
                ClientId = c.ClientId,
                Name = c.Name,
                Email = c.Email
            })
            .ToListAsync();
    }
}
