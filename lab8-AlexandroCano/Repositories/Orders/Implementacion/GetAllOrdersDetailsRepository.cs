using lab8_AlexandroCano.Data;
using lab8_AlexandroCano.DTOs.Orders;
using lab8_AlexandroCano.Repositories.Orders.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace lab8_AlexandroCano.Repositories.Orders.Implementacion;


// LAB 9 - PASO 3: Consulta con Include() y ThenInclude()

// Técnica LINQ: AsNoTracking + Include + ThenInclude + Select anidado.
// Objetivo: obtener todas las órdenes con su cliente, sus detalles y
//           los productos relacionados en UNA sola consulta SQL,
//           devolviendo el resultado como DTO anidado.
// Endpoint: GET /api/Orders/details

public class GetAllOrdersDetailsRepository(AppDbContext context) : IGetAllOrdersDetailsRepository
{
    public async Task<IEnumerable<OrderWithDetailsDto>> ExecuteAsync()
    {
        return await context.Orders
            .AsNoTracking()                                       // PASO 2: lectura sin tracking
            .Include(o => o.Client)                               // PASO 3: incluye el Cliente de cada orden
            .Include(o => o.OrderDetails)                         // PASO 3: incluye los detalles de la orden
                .ThenInclude(od => od.Product)                    // PASO 3: y los productos de cada detalle
            .Select(o => new OrderWithDetailsDto                  // Proyección anidada a DTO
            {
                OrderId = o.OrderId,
                ClientName = o.Client.Name,
                OrderDate = o.OrderDate,
                Details = o.OrderDetails.Select(od => new OrderProductLineDto
                {
                    ProductName = od.Product.Name,
                    Quantity = od.Quantity
                }).ToList()
            })
            .ToListAsync();
    }
}
