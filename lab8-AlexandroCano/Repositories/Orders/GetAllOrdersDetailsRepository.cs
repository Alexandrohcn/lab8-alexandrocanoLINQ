using lab8_AlexandroCano.Data;
using lab8_AlexandroCano.DTOs.Orders;
using lab8_AlexandroCano.Repositories.Orders.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace lab8_AlexandroCano.Repositories.Orders;

public class GetAllOrdersDetailsRepository(AppDbContext context) : IGetAllOrdersDetailsRepository
{
    public async Task<IEnumerable<OrderWithDetailsDto>> ExecuteAsync()
    {
        return await context.Orders
            .AsNoTracking()
            .Select(o => new OrderWithDetailsDto
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
