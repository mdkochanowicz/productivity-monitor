using System.Runtime.CompilerServices;

namespace Contracts;

public class ActivityUpdated
{
        public string Id {get; set;}
        public string Name {get; set;}
        public string Description {get; set;}
        public int? PredictedTime {get; set;}
        public string Category {get; set;}
        public int? Experience {get; set;}
}