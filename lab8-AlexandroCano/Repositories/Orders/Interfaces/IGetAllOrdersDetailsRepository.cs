using lab8_AlexandroCano.DTOs.Orders;

namespace lab8_AlexandroCano.Repositories.Orders.Interfaces;

public interface IGetAllOrdersDetailsRepository
{
    Task<IEnumerable<OrderWithDetailsDto>> ExecuteAsync();
}
