using lab8_AlexandroCano.DTOs.Orders;
using lab8_AlexandroCano.Repositories.Orders.Interfaces;
using lab8_AlexandroCano.Services.Orders.Interfaces;

namespace lab8_AlexandroCano.Services.Orders;

public class GetAllOrdersDetailsService(IGetAllOrdersDetailsRepository repository) : IGetAllOrdersDetailsService
{
    public Task<IEnumerable<OrderWithDetailsDto>> ExecuteAsync()
    {
        return repository.ExecuteAsync();
    }
}
