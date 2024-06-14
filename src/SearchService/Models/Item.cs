using MongoDB.Entities;

namespace SearchService;

public class Item : Entity
{

    public int ReserveTime {get; set;}
    public string Author {get; set;}
    public string User {get; set;}
    public int ExecutionTime {get; set;}
    public int HighestTime {get; set;}
    public DateTime CreatedAt {get; set;}
    public DateTime? UpdatedAt {get; set;}
    public DateTime? ActivityEnd {get; set;}
    public string Status {get; set;} 
    public string Name {get; set;}
    public string Description {get; set;}
    public int? PredictedTime {get; set;}
    public string Category {get; set;}
    public int Experience {get; set;}
    public string ImageUrl {get; set;}
}