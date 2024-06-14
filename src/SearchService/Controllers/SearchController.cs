using Microsoft.AspNetCore.Mvc;
using MongoDB.Entities;
using ZstdSharp.Unsafe;

namespace SearchService;

[ApiController]
[Route("api/search")]
public class SearchController : ControllerBase
{
    [HttpGet]
    public async Task<ActionResult<List<Item>>> SearchItems([FromQuery]SearchParams searchParams)
    {
        var query = DB.PagedSearch<Item, Item>();

        query.Sort(x => x.Ascending(a => a.Name));

        if(!string.IsNullOrWhiteSpace(searchParams.SearchTerm))
        query.Match(Search.Full, searchParams.SearchTerm).SortByTextScore();

        query = searchParams.OrderBy switch
        {
            "name" => query.Sort(x => x.Ascending(a => a.Name)),
            "new" => query.Sort(x => x.Descending(a => a.CreatedAt)),
            _ => query.Sort(x => x.Ascending(a => a.ActivityEnd))
        };

        query = searchParams.FilterBy switch
        {
            "finished" => query.Match(x => x.ActivityEnd < DateTime.UtcNow),
            "endingSoon" => query.Match(x => x.ActivityEnd < DateTime.UtcNow.AddHours(1) && x.ActivityEnd > DateTime.UtcNow),
            _ => query.Match(x => x.ActivityEnd > DateTime.UtcNow)
        };

        if(!string.IsNullOrWhiteSpace(searchParams.Author))
        {
            query.Match(x => x.Author == searchParams.Author);
        }

         if(!string.IsNullOrWhiteSpace(searchParams.User))
        {
            query.Match(x => x.User == searchParams.User);
        }
        
        query.PageNumber(searchParams.PageNumber);
        query.PageSize(searchParams.PageSize);

        var result = await query.ExecuteAsync();

        return Ok(new
        {results = result.Results,
        pageCount = result.PageCount,
        totalCount = result.TotalCount});


    }
}