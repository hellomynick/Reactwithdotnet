using BasketServices;
using BasketServices.Model;
using BasketServices.Repositories;
using Microsoft.Extensions.Options;
using Microsoft.OpenApi.Models;
using StackExchange.Redis;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
builder.Services.AddTransient<IBasketRepository, BasketRepository>();
builder.Services.AddEndpointsApiExplorer();

builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo
    {
        Version = "v1",
        Title = "Basket - WebApi",
    });
});
IConnectionMultiplexer redis = ConnectionMultiplexer.Connect("basketdata,6379");
builder.Services.AddScoped(x => redis.GetDatabase());

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "BasketServices");
    });
}


app.UseAuthorization();

app.MapControllers();

app.Run();
