using Coffee.Services;
using Coffee.Services.Interfaces;
using Business.Middlewares;
using Business.ServiceResult.Interfaces;
using Business.ServiceResult;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddScoped<ICoffeeService, CoffeeService>();
builder.Services.AddSingleton<ICounterService, CounterService>();
builder.Services.AddScoped<IServiceResultFactory, ServiceResultFactory>();


var app = builder.Build();

var _config = builder.Configuration;

app.UseMiddleware<Http418HandlerMiddleware>
    (_config.GetValue<int>("Http418_Month"),
    _config.GetValue<int>("Http418_Day"));

app.MapControllers();

app.Run();
