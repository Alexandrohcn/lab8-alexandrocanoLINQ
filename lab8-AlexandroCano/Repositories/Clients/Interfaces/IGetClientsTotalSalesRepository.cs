using lab8_AlexandroCano.DTOs.Clients;

namespace lab8_AlexandroCano.Repositories.Clients.Interfaces;

public interface IGetClientsTotalSalesRepository
{
    Task<IEnumerable<ClientTotalSalesDto>> ExecuteAsync();
}
