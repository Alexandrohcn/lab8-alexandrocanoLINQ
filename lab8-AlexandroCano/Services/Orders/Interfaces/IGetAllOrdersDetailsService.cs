using lab8_AlexandroCano.DTOs.Orders;

namespace lab8_AlexandroCano.Services.Orders.Interfaces;

public interface IGetAllOrdersDetailsService
{
    Task<IEnumerable<OrderWithDetailsDto>> ExecuteAsync();
}
