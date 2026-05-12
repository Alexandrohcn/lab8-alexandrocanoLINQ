using lab8_AlexandroCano.Data;
using lab8_AlexandroCano.DTOs.Orders;
using lab8_AlexandroCano.Repositories.Orders.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace lab8_AlexandroCano.Repositories.Orders.Implementacion;


// LAB 9 - PASO 3: Consulta con Include() para Referencias

// Técnica LINQ: AsNoTracking + Include + Where + Select.
// Objetivo: traer un pedido junto con sus productos asociados en una
//           sola consulta usando Include() para la entidad relacionada
//           Product, y proyectarlo a un DTO.
// Endpoint: GET /api/Orders/{orderId}/details

public class GetOrderDetailsRepository(AppDbContext context) : IGetOrderDetailsRepository
{
    public async Task<IEnumerable<OrderDetailItemDto>> ExecuteAsync(int orderId)
    {
        return await context.OrderDetails
            .AsNoTracking()                                           // PASO 2: lectura sin tracking
            .Include(od => od.Product)              // PASO 3: trae la entidad Product asociada
            .Where(od => od.OrderId == orderId)
            .Select(od => new OrderDetailItemDto                      // Proyección a DTO
            {
                OrderId = od.OrderId,
                ProductName = od.Product.Name,
                Quantity = od.Quantity
            })
            .ToListAsync();
    }
}
