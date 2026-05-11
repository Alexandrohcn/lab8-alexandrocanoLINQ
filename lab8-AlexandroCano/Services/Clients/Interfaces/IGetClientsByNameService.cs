using lab8_AlexandroCano.DTOs.Clients;

namespace lab8_AlexandroCano.Services.Clients.Interfaces;

public interface IGetClientsByNameService
{
    Task<IEnumerable<ClientDto>> ExecuteAsync(string name);
}
