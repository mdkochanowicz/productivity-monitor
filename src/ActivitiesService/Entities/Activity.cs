namespace ActivitiesService.Entities;

public class Activity
{
    public Guid Id {get; set;}
    public int ReserveTime {get; set;} = 0;
    public string Author {get; set;}
    public string User {get; set;}
    public int? ExecutionTime {get; set;}
    public int? HighestTime {get; set;}
    public DateTime CreatedAt {get; set;} = DateTime.Now;
    public DateTime? UpdatedAt {get; set;} = DateTime.Now;
    public DateTime? ActivityEnd {get; set;}
    //public Status Status {get; set;} = Status.Pending; 
    //public Item Item {get; set;}
}