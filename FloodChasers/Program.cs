using FloodChasersAPI.Data.Common;
using FloodChasersLogic.Alerts.Services;
using FloodChasersLogic.Dao;
using FloodChasersLogic.Users.Services;
using FloodChasersModel.Alerts.Services;
using FloodChasersModel.Dao;
using FloodChasersModel.Users.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using MongoDB.Driver;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSingleton<IMongoClient>(serviceProvider => {
    var configuration = serviceProvider.GetRequiredService<IConfiguration>();
    var connectionString = configuration.GetConnectionString("MongoDB");
    return new MongoClient(connectionString);
});
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "Flood Chasesr API", Version = "v1" });
});

LoadDI(builder);

static void LoadDI(WebApplicationBuilder builder)
{
    builder.Services.AddScoped(typeof(IGenericDeo<>), typeof(GenericDao<>));
    builder.Services.AddScoped<IUserService, UserService>();
    builder.Services.AddScoped<IAlertService, AlertService>();
}

var app = builder.Build();


app.UseSwagger();
app.UseSwaggerUI(c =>
{
    c.SwaggerEndpoint("/swagger/v1/swagger.json", "Flood Chasesr API V1");
    // Add any additional configuration here
});


app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
