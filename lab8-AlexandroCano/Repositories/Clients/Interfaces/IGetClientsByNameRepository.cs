using lab8_AlexandroCano.DTOs.Clients;

namespace lab8_AlexandroCano.Repositories.Clients.Interfaces;

public interface IGetClientsByNameRepository
{
    Task<IEnumerable<ClientDto>> ExecuteAsync(string name);
}
