using lab8_AlexandroCano.DTOs.Products;

namespace lab8_AlexandroCano.Services.Products.Interfaces;

public interface IGetProductsWithoutDescriptionService
{
    Task<IEnumerable<ProductDto>> ExecuteAsync();
}
