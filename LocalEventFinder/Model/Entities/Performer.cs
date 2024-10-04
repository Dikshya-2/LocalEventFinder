using System.Text.Json.Serialization;

namespace LocalEventFinder.Model.Entities
{
    public class Performer
    {
        public int PerformerId { get; set; } // Primary Key
        public string Name { get; set; }
        public int Age { get; set; }
        public string SharedPlatform { get; set; }


        //[JsonIgnore]
        public List<Event> Events { get; set; } = new List<Event>(); //m-m
    }
}
