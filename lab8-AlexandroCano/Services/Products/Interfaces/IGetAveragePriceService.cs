using lab8_AlexandroCano.DTOs.Products;

namespace lab8_AlexandroCano.Services.Products.Interfaces;

public interface IGetAveragePriceService
{
    Task<AveragePriceDto> ExecuteAsync();
}
