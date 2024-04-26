using System.ComponentModel.DataAnnotations;

namespace ActivitiesService.DTOs;

public class CreateActivityDto
{
    [Required]
    public string Name {get; set;}
    [Required]
    public string Description {get; set;}
    [Required]
    public int PredictedTime {get; set;}
    [Required]
    public string Category {get; set;}
    [Required]
    public int Experience {get; set;}
    [Required]
    public string ImageUrl {get; set;}
    [Required]
    public int ReserveTime {get; set;}
    [Required]
    public DateTime ActivityEnd {get; set;}
}