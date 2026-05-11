using lab8_AlexandroCano.DTOs.Clients;
using lab8_AlexandroCano.Repositories.Clients.Interfaces;
using lab8_AlexandroCano.Services.Clients.Interfaces;

namespace lab8_AlexandroCano.Services.Clients;

public class GetClientWithMostOrdersService(IGetClientWithMostOrdersRepository repository) : IGetClientWithMostOrdersService
{
    public Task<ClientWithMostOrdersDto?> ExecuteAsync()
    {
        return repository.ExecuteAsync();
    }
}
