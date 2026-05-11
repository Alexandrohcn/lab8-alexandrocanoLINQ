using lab8_AlexandroCano.Data;
using lab8_AlexandroCano.DTOs.Orders;
using lab8_AlexandroCano.Repositories.Orders.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace lab8_AlexandroCano.Repositories.Orders;

public class GetOrderDetailsRepository(AppDbContext context) : IGetOrderDetailsRepository
{
    public async Task<IEnumerable<OrderDetailItemDto>> ExecuteAsync(int orderId)
    {
        return await context.OrderDetails
            .AsNoTracking()
            .Where(od => od.OrderId == orderId)
            .Select(od => new OrderDetailItemDto
            {
                OrderId = od.OrderId,
                ProductName = od.Product.Name,
                Quantity = od.Quantity
            })
            .ToListAsync();
    }
}
