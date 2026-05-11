using lab8_AlexandroCano.DTOs.Products;

namespace lab8_AlexandroCano.Repositories.Products.Interfaces;

public interface IGetProductsWithoutDescriptionRepository
{
    Task<IEnumerable<ProductDto>> ExecuteAsync();
}
