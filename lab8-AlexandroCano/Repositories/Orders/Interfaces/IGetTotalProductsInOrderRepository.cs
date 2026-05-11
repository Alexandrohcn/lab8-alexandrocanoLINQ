namespace lab8_AlexandroCano.Repositories.Orders.Interfaces;

public interface IGetTotalProductsInOrderRepository
{
    Task<int> ExecuteAsync(int orderId);
}
