namespace lab8_AlexandroCano.DTOs.Orders;

public class OrderDetailItemDto
{
    public int OrderId { get; set; }
    public string ProductName { get; set; } = null!;
    public int Quantity { get; set; }
}
