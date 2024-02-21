using ClothStoreSalesAPI.Filters;
using Data.Models;
using Data.Repository;
using Data.Repository.Interface;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddSingleton<List<Item>>();
builder.Services.AddSingleton<IItemRepository, ItemRepositoryInMemory>();
builder.Services.AddSingleton<ISaleRepository, SaleRepositoryInMemory>();
builder.Services.AddSingleton<IReturnRepository, ReturnRepositoryInMemory>();
builder.Services.AddSingleton<IExchangeRepository, ExchangeRepositoryInMemory>();

builder.Services.AddScoped<LogActionFilter>();

builder.Services.AddControllers(options =>
{
    options.Filters.Add<ExceptionFilter>();
    options.Filters.Add<LogActionFilter>();
});

builder.Services.AddCors(corsOptions =>
{
    corsOptions.AddPolicy("localhost", policyBuilder =>
    {
        policyBuilder.WithOrigins("http://localhost:5500");
    });
});

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
    app.UseCors("localhost");
}

app.UseAuthorization();

app.MapControllers();

app.Run();
