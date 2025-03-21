using System.ComponentModel.DataAnnotations;

namespace ActivityService.DTOs;

public class CreateActivityDto
{
    [Required]
    public string Name {get; set;}
    public string Description {get; set;}
    public int PredictedTime {get; set;}
    public string Category {get; set;}
    public int Experience {get; set;}
    public string ImageUrl {get; set;}
    public int ReserveTime {get; set;}
    public DateTime ActivityEnd {get; set;}
}








