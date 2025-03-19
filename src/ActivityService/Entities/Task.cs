namespace ActivityService.Entities
{
    public class Task
    {
        public Guid Id {get; set;}
        public string Name {get; set;}
        public string Description {get; set;}
        public int? PredictedTime {get; set;}
        public string Category {get; set;}
        public int Experience {get; set;}
        public string ImageUrl {get; set;}

        //nav properties
        public Activity Activity {get; set;}
        public Guid ActivityId {get; set;}
    }
}