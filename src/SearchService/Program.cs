using System.Net;
using MongoDB.Driver;
using MongoDB.Entities;
using SearchService;
//using MongoDB.Entities.Core; // Add this line

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();


var app = builder.Build();


app.UseAuthorization();

app.MapControllers();

await DB.InitAsync("searchDb", MongoClientSettings.FromConnectionString(builder.Configuration.GetConnectionString("MongoDbConnection")));

await DB.Index<Item>()
    .Key(t => t.Name, KeyType.Text)
    .Key(t => t.Description, KeyType.Text)
    .Key(t => t.Category, KeyType.Text)
    .CreateAsync();

app.Run();
