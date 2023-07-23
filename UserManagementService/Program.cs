using Models;
using MongoDB.Driver;
using Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddControllers();

builder.Services.AddSwaggerGen();
builder.Services.AddHealthChecks();

//builder.Services.AddScoped<ILogger, ILogger>();
AddConfig(builder);
builder.Services.AddScoped<IMongoRepository<Users>, MongoRepository<Users>>();


var app = builder.Build();

// Configure the HTTP request pipeline.
app.UseSwagger();
app.UseSwaggerUI();
app.UseHttpsRedirection();

app.MapHealthChecks("HealthCheck");

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();


static void AddConfig(WebApplicationBuilder builder)
{
    var appSettings = builder.Configuration.Get<AppSettings>();
    builder.Services.AddSingleton<IConnectionStrings>(appSettings.ConnectionStrings);
    builder.Services.AddSingleton<ICollectionNames>(appSettings.CollectionNames);
    builder.Services.AddSingleton<IMongoClient>(new MongoClient(appSettings.ConnectionStrings.MongoConnection));
    builder.Services.AddSingleton<IMongoDatabase>(new MongoClient(appSettings.ConnectionStrings.MongoConnection).GetDatabase(appSettings.DatabaseName));
}