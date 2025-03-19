namespace ActivityService.Entities;

    public class Activity
    {
    public Guid Id {get; set;}
    public int ReserveTime {get; set;} = 0;
    public string Author {get; set;}
    public string User {get; set;}
    public int? ExecutionTime {get; set;}
    public int? HighestTime {get; set;}
    public DateTime CreatedAt {get; set;} = DateTime.UtcNow;
    public DateTime? UpdatedAt {get; set;} = DateTime.UtcNow;
    public DateTime? ActivityEnd {get; set;}
    public Status Status {get; set;} 
    public Task Task {get; set;}
    }
