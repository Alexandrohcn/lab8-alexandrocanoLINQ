using lab8_AlexandroCano.DTOs.Clients;

namespace lab8_AlexandroCano.Services.Clients.Interfaces;

public interface IGetClientWithMostOrdersService
{
    Task<ClientWithMostOrdersDto?> ExecuteAsync();
}
