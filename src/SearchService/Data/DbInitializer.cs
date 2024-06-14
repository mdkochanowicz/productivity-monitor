using MongoDB.Entities;
using MongoDB.Driver;
using System.Text.Json;

namespace SearchService;

public class DbInitializer
{
    public static async Task InitDb(WebApplication app)
    {
        await DB.InitAsync("searchDb", MongoClientSettings.FromConnectionString(app.Configuration.GetConnectionString("MongoDbConnection")));

await DB.Index<Item>()
    .Key(t => t.Name, KeyType.Text)
    .Key(t => t.Description, KeyType.Text)
    .Key(t => t.Category, KeyType.Text)
    .CreateAsync();

    var count = await DB.CountAsync<Item>();

    /*
    if(count == 0)
    {
        Console.WriteLine("No data - will attempt to seed data");
        var itemData = await File.ReadAllTextAsync("Data/activities.json");

        var options = new JsonSerializerOptions{
            PropertyNameCaseInsensitive = true
        };

        var items = JsonSerializer.Deserialize<List<Item>>(itemData, options);

        await DB.SaveAsync(items);
    }
    */
    using var scope = app.Services.CreateScope();

    var httpClient = scope.ServiceProvider.GetRequiredService<ActivitySvcHttpClient>();

    var items = await httpClient.GetItemsForSearchDb();

    Console.WriteLine("Items from ActivityService: " + items.Count);

    if(items.Count > 0) await DB.SaveAsync(items);

}

}