using ShopEZ.API.Data;
using Microsoft.EntityFrameworkCore;
using ShopEZ.API.Repositories.Interfaces;
using ShopEZ.API.Repositories;
using ShopEZ.API.Services.Interfaces;
using ShopEZ.API.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services
builder.Services.AddControllers();
builder.Services.AddScoped<IProductRepository, ProductRepository>();
builder.Services.AddScoped<IProductService, ProductService>();
builder.Services.AddScoped<IOrderService, OrderService>();

builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();
app.UseAuthorization();

app.MapControllers();

app.Run();