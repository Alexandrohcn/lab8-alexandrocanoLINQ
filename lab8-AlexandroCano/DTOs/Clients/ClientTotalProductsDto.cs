namespace lab8_AlexandroCano.DTOs.Clients;

public class ClientTotalProductsDto
{
    public int ClientId { get; set; }
    public string Name { get; set; } = null!;
    public int TotalProducts { get; set; }
}
