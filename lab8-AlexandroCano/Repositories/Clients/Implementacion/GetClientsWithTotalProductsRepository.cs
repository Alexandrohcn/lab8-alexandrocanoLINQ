using lab8_AlexandroCano.Data;
using lab8_AlexandroCano.DTOs.Clients;
using lab8_AlexandroCano.Repositories.Clients.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace lab8_AlexandroCano.Repositories.Clients.Implementacion;


// LAB 9 - PASO 4: Doble Consulta a la Base de Datos

// Técnica LINQ: dos ToListAsync() independientes + GroupJoin en memoria.
// Objetivo: obtener todos los clientes con el total de productos que
//           han comprado. Se hacen DOS consultas separadas a la BD
//           (una para clientes, otra para sumar Quantity por cliente)
//           y luego se combinan en memoria.
// Endpoint: GET /api/Clients/total-products

public class GetClientsWithTotalProductsRepository(AppDbContext context) : IGetClientsWithTotalProductsRepository
{
    public async Task<IEnumerable<ClientTotalProductsDto>> ExecuteAsync()
    {
        // PASO 4 — PRIMERA CONSULTA: traer la lista de clientes
        var clients = await context.Clients
            .AsNoTracking()
            .Select(c => new { c.ClientId, c.Name })
            .ToListAsync();

        // PASO 4 — SEGUNDA CONSULTA: sumar productos comprados por cliente
        var totals = await context.OrderDetails
            .AsNoTracking()
            .GroupBy(od => od.Order.ClientId)
            .Select(g => new
            {
                ClientId = g.Key,
                TotalProducts = g.Sum(od => od.Quantity)          // Sum() de cantidades por cliente
            })
            .ToListAsync();

        // Combinación en memoria: clientes con su total (0 si nunca compró)
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
