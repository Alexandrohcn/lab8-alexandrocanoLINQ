namespace lab8_AlexandroCano.DTOs.Clients;

public class ClientWithMostOrdersDto
{
    public int ClientId { get; set; }
    public string Name { get; set; } = null!;
    public string Email { get; set; } = null!;
    public int OrderCount { get; set; }
}
