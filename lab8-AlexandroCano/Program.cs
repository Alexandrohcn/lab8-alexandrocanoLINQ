using lab8_AlexandroCano.Data;
using lab8_AlexandroCano.Repositories.Clients;
using lab8_AlexandroCano.Repositories.Clients.Interfaces;
using lab8_AlexandroCano.Repositories.Orders;
using lab8_AlexandroCano.Repositories.Orders.Interfaces;
using lab8_AlexandroCano.Repositories.Products;
using lab8_AlexandroCano.Repositories.Products.Interfaces;
using lab8_AlexandroCano.Repositories.UnitOfWork;
using lab8_AlexandroCano.Services.Clients;
using lab8_AlexandroCano.Services.Clients.Interfaces;
using lab8_AlexandroCano.Services.Orders;
using lab8_AlexandroCano.Services.Orders.Interfaces;
using lab8_AlexandroCano.Services.Products;
using lab8_AlexandroCano.Services.Products.Interfaces;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// MVC + API
builder.Services.AddControllersWithViews();

// DbContext con SQL Server
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// Swagger
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// UnitOfWork
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();

// Repositories - Clients
builder.Services.AddScoped<IGetClientsByNameRepository, GetClientsByNameRepository>();
builder.Services.AddScoped<IGetClientWithMostOrdersRepository, GetClientWithMostOrdersRepository>();
builder.Services.AddScoped<IGetClientsWhoBoughtProductRepository, GetClientsWhoBoughtProductRepository>();
builder.Services.AddScoped<IGetClientsWithTotalProductsRepository, GetClientsWithTotalProductsRepository>();
builder.Services.AddScoped<IGetClientsTotalSalesRepository, GetClientsTotalSalesRepository>();

// Repositories - Orders
builder.Services.AddScoped<IGetOrderDetailsRepository, GetOrderDetailsRepository>();
builder.Services.AddScoped<IGetTotalProductsInOrderRepository, GetTotalProductsInOrderRepository>();
builder.Services.AddScoped<IGetOrdersAfterDateRepository, GetOrdersAfterDateRepository>();
builder.Services.AddScoped<IGetAllOrdersDetailsRepository, GetAllOrdersDetailsRepository>();

// Repositories - Products
builder.Services.AddScoped<IGetProductsByPriceRepository, GetProductsByPriceRepository>();
builder.Services.AddScoped<IGetMostExpensiveProductRepository, GetMostExpensiveProductRepository>();
builder.Services.AddScoped<IGetAveragePriceRepository, GetAveragePriceRepository>();
builder.Services.AddScoped<IGetProductsWithoutDescriptionRepository, GetProductsWithoutDescriptionRepository>();
builder.Services.AddScoped<IGetProductsSoldToClientRepository, GetProductsSoldToClientRepository>();

// Services - Clients
builder.Services.AddScoped<IGetClientsByNameService, GetClientsByNameService>();
builder.Services.AddScoped<IGetClientWithMostOrdersService, GetClientWithMostOrdersService>();
builder.Services.AddScoped<IGetClientsWhoBoughtProductService, GetClientsWhoBoughtProductService>();
builder.Services.AddScoped<IGetClientsWithTotalProductsService, GetClientsWithTotalProductsService>();
builder.Services.AddScoped<IGetClientsTotalSalesService, GetClientsTotalSalesService>();

// Services - Orders
builder.Services.AddScoped<IGetOrderDetailsService, GetOrderDetailsService>();
builder.Services.AddScoped<IGetTotalProductsInOrderService, GetTotalProductsInOrderService>();
builder.Services.AddScoped<IGetOrdersAfterDateService, GetOrdersAfterDateService>();
builder.Services.AddScoped<IGetAllOrdersDetailsService, GetAllOrdersDetailsService>();

// Services - Products
builder.Services.AddScoped<IGetProductsByPriceService, GetProductsByPriceService>();
builder.Services.AddScoped<IGetMostExpensiveProductService, GetMostExpensiveProductService>();
builder.Services.AddScoped<IGetAveragePriceService, GetAveragePriceService>();
builder.Services.AddScoped<IGetProductsWithoutDescriptionService, GetProductsWithoutDescriptionService>();
builder.Services.AddScoped<IGetProductsSoldToClientService, GetProductsSoldToClientService>();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
else
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllers();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
