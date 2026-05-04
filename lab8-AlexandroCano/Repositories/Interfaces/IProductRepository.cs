using lab8_AlexandroCano.Models;

namespace lab8_AlexandroCano.Repositories.Interfaces;

public interface IProductRepository
{
    Task<IEnumerable<Product>> GetProductsByPriceAsync(decimal minPrice);
    Task<Product?> GetMostExpensiveProductAsync();
    Task<decimal> GetAveragePriceAsync();
    Task<IEnumerable<Product>> GetProductsWithoutDescriptionAsync();
    Task<IEnumerable<object>> GetProductsSoldToClientAsync(int clientId);
}