using lab8_AlexandroCano.Data;
using lab8_AlexandroCano.DTOs.Clients;
using lab8_AlexandroCano.Repositories.Clients.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace lab8_AlexandroCano.Repositories.Clients.Implementacion;


// PASO 2: Consulta con AsNoTracking() + DTO
// Técnica LINQ: AsNoTracking + Where + Select (proyección a DTO).
// Endpoint: GET /api/Clients/search?name=

public class GetClientsByNameRepository(AppDbContext context) : IGetClientsByNameRepository
{
    public async Task<IEnumerable<ClientDto>> ExecuteAsync(string name)
    {
        return await context.Clients
            .AsNoTracking()                                    // PASO 2: sin tracking → mejor rendimiento en lecturas
            .Where(c => c.Name.Contains(name))           // Filtro LINQ traducido a SQL LIKE
            .Select(c => new ClientDto                   // PASO 2: proyección a DTO (no se devuelve la entidad EF)
            {
                ClientId = c.ClientId,
                Name = c.Name,
                Email = c.Email
            })
            .ToListAsync();
    }
}
