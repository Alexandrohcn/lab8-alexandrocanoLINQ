using lab8_AlexandroCano.DTOs.Clients;
using lab8_AlexandroCano.Repositories.Clients.Interfaces;
using lab8_AlexandroCano.Services.Clients.Interfaces;

namespace lab8_AlexandroCano.Services.Clients;

public class GetClientsByNameService(IGetClientsByNameRepository repository) : IGetClientsByNameService
{
    public Task<IEnumerable<ClientDto>> ExecuteAsync(string name)
    {
        if (string.IsNullOrWhiteSpace(name))
        {
            throw new ArgumentException("El nombre es obligatorio.", nameof(name));
        }

        return repository.ExecuteAsync(name.Trim());
    }
}
