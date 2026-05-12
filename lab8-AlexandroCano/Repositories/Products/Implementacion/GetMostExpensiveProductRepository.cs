using lab8_AlexandroCano.Data;
using lab8_AlexandroCano.DTOs.Products;
using lab8_AlexandroCano.Repositories.Products.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace lab8_AlexandroCano.Repositories.Products.Implementacion;


// LAB 9 - MEJORA PROPIA con LINQ

// Técnica LINQ: AsNoTracking + OrderByDescending + Select(DTO) + FirstOrDefault.
// Objetivo: obtener el producto más caro del catálogo.
// Endpoint: GET /api/Products/most-expensive

public class GetMostExpensiveProductRepository(AppDbContext context) : IGetMostExpensiveProductRepository
{
    public async Task<ProductDto?> ExecuteAsync()
    {
        return await context.Products
            .AsNoTracking()                                  // PASO 2: lectura sin tracking
            .OrderByDescending(p => p.Price)                 // Mejora: ordena por precio descendente
            .Select(p => new ProductDto                      // Proyección a DTO
            {
                ProductId = p.ProductId,
                Name = p.Name,
                Description = p.Description,
                Price = p.Price
            })
            .FirstOrDefaultAsync();                          // Toma solo el primero (el más caro)
    }
}
