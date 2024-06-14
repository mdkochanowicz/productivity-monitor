using System.Runtime.CompilerServices;
using Microsoft.AspNetCore.Http.Features;
using MongoDB.Entities;

namespace SearchService;

public class ActivitySvcHttpClient
{
    private readonly HttpClient _httpClient;
    private readonly IConfiguration _config;

    public ActivitySvcHttpClient(HttpClient httpClient, IConfiguration config)
    {
        _httpClient = httpClient;
        _config = config;
    }

    public async Task<List<Item>> GetItemsForSearchDb()
    {
        var lastUpdated = await DB.Find<Item, string>()
            .Sort(x => x.Descending(x => x.UpdatedAt))
            .Project(x => x.UpdatedAt.ToString())
            .ExecuteFirstAsync();

            return await _httpClient.GetFromJsonAsync<List<Item>>(_config["ActivityServiceUrl"] + "/api/activities?date=" + lastUpdated);
    }
}