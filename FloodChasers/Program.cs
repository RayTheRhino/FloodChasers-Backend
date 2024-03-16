using FloodChasersAPI.Data.Common;
using FloodChasersLogic.Alerts.Services;
using FloodChasersLogic.Comments.Services;
using FloodChasersLogic.Dao;
using FloodChasersLogic.Posts.Services;
using FloodChasersLogic.Users.Services;
using FloodChasersModel.Alerts.Services;
using FloodChasersModel.Comments.Services;
using FloodChasersModel.Dao;
using FloodChasersModel.Forums.Services;
using FloodChasersModel.Posts.Services;
using FloodChasersModel.Users.Services;
using Microsoft.OpenApi.Models;
using MongoDB.Driver;
using FloodChasersLogic.Forums.Services;
using FloodChasersModel.Learn.Service;
using FloodChasersLogic.Learn.Service;
using Microsoft.AspNetCore.Mvc;
using FloodChasersModel.APIs;
using FloodChasersLogic.APIs;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

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
    builder.Services.AddScoped<IArticleApi, ArticleApi>();
    builder.Services.AddScoped<IUserService, UserService>();
    builder.Services.AddScoped<IAlertService, AlertService>();
    builder.Services.AddScoped<IPostService, PostService>();
    builder.Services.AddScoped<ICommentService, CommentService>();
    builder.Services.AddScoped<IForumService, ForumService>();
    builder.Services.AddScoped<ILearnService, LearnService>();
}
builder.Services.Configure<ApiBehaviorOptions>(options =>
{
    options.SuppressModelStateInvalidFilter = true;
});
builder.Services.AddAuthorization();
builder.Services.AddControllers();
var app = builder.Build();


app.UseSwagger();
app.UseSwaggerUI(c =>
{
    c.SwaggerEndpoint("/swagger/v1/swagger.json", "Flood Chasesr API V1");
    // Add any additional configuration here
});


app.UseRouting();

app.UseAuthorization();

app.MapControllers();

app.Run();
