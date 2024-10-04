using System.Text.Json.Serialization;

namespace LocalEventFinder.Model.Entities
{
    public class Category
    {
        public int CategoryId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; } 
        public string IconUrl { get; set; }
        [JsonIgnore]
        public List<Event>? Events { get; set; } = new List<Event>();// Many-to-Many
    }
}
