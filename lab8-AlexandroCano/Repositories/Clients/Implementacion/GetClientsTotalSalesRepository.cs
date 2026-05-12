using lab8_AlexandroCano.Data;
using lab8_AlexandroCano.DTOs.Clients;
using lab8_AlexandroCano.Repositories.Clients.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace lab8_AlexandroCano.Repositories.Clients.Implementacion;


// LAB 9 - PASO 5: Consulta Avanzada con Filtros y Agrupación

// Técnica LINQ: AsNoTracking + GroupBy + Sum + OrderByDescending.
// Objetivo: calcular el TOTAL DE VENTAS por cliente (Quantity * Price)
//           agrupando por cliente y ordenando de mayor a menor.
// Endpoint: GET /api/Clients/total-sales

public class GetClientsTotalSalesRepository(AppDbContext context) : IGetClientsTotalSalesRepository
{
    public async Task<IEnumerable<ClientTotalSalesDto>> ExecuteAsync()
    {
        return await context.Orders
            .AsNoTracking()                                                  // PASO 2: lectura sin tracking
            .GroupBy(o => new { o.ClientId, o.Client.Name })                 // PASO 5: agrupación por cliente
            .Select(g => new ClientTotalSalesDto
            {
                ClientId = g.Key.ClientId,
                Name = g.Key.Name,
                TotalSales = g.SelectMany(o => o.OrderDetails)
                              .Sum(od => od.Quantity * od.Product.Price)     // PASO 5: Sum(Quantity * Price)
            })
            .OrderByDescending(x => x.TotalSales)                            // PASO 5: orden descendente por total
            .ToListAsync();
    }
}
