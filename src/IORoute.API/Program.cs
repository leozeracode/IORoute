using IORoute.Infra;
using IORoute.Domain.Usecases;
using IORoute.Infra.Persistence;
using IORoute.API.Extensions;
using Microsoft.AspNetCore.Mvc;
using IORoute.App.Usecases;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers(config =>
{
    config.Filters.Add(new ValidateModelStateFilter());
});

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddInfrastructureServices(builder.Configuration);

builder.Services.AddScoped<IGetBestRoute, GetBestRoute>();

builder.Services.Configure<ApiBehaviorOptions>(options =>
{
    options.SuppressModelStateInvalidFilter = true;
});

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll", builder =>
    {
        builder.AllowAnyOrigin()
               .AllowAnyMethod()
               .AllowAnyHeader();
    });
});

var app = builder.Build();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.UseCors(cors => cors.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod());


app.MigrateDataBase<RouteDbContext>((context, service) =>
{
    var logger = service.GetService<ILogger<RouteContextSeed>>();
    RouteContextSeed.SeedAsync(context, logger).Wait();
});



app.Run();

public partial class Program { }

