using lab8_AlexandroCano.DTOs.Clients;
using lab8_AlexandroCano.Repositories.Clients.Interfaces;
using lab8_AlexandroCano.Services.Clients.Interfaces;

namespace lab8_AlexandroCano.Services.Clients;

public class GetClientsWithTotalProductsService(IGetClientsWithTotalProductsRepository repository) : IGetClientsWithTotalProductsService
{
    public Task<IEnumerable<ClientTotalProductsDto>> ExecuteAsync()
    {
        return repository.ExecuteAsync();
    }
}
