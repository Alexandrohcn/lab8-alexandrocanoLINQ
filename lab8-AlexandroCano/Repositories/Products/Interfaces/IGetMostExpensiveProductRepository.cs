using lab8_AlexandroCano.DTOs.Products;

namespace lab8_AlexandroCano.Repositories.Products.Interfaces;

public interface IGetMostExpensiveProductRepository
{
    Task<ProductDto?> ExecuteAsync();
}
