using lab8_AlexandroCano.DTOs.Products;
using lab8_AlexandroCano.Repositories.Products.Interfaces;
using lab8_AlexandroCano.Services.Products.Interfaces;

namespace lab8_AlexandroCano.Services.Products;

public class GetAveragePriceService(IGetAveragePriceRepository repository) : IGetAveragePriceService
{
    public async Task<AveragePriceDto> ExecuteAsync()
    {
        var average = await repository.ExecuteAsync();
        return new AveragePriceDto { AveragePrice = average };
    }
}
