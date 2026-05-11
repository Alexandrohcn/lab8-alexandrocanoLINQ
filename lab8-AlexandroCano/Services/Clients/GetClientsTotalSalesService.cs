using lab8_AlexandroCano.DTOs.Clients;
using lab8_AlexandroCano.Repositories.Clients.Interfaces;
using lab8_AlexandroCano.Services.Clients.Interfaces;

namespace lab8_AlexandroCano.Services.Clients;

public class GetClientsTotalSalesService(IGetClientsTotalSalesRepository repository) : IGetClientsTotalSalesService
{
    public Task<IEnumerable<ClientTotalSalesDto>> ExecuteAsync()
    {
        return repository.ExecuteAsync();
    }
}
