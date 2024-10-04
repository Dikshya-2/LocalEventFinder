using System.Text.Json.Serialization;

namespace LocalEventFinder.Model.Entities
{
    public class Event
    {
        public int EventId { get; set; } // Primary Key
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime EventDateTime { get; set; }
        public string LocationName { get; set; }
        public string LocationAddress { get; set; }
        public decimal LocationLatitude { get; set; }
        public decimal LocationLongitude { get; set; }
        public int RsvpCount { get; set; } = 0; 
        public string ImageUrl { get; set; } 

        // Foreign Keys many to one
        public int OrganizerId { get; set; }
        public int CategoryId { get; set; }

        // Many-to-Many Relationships

        public List<Performer> Performers { get; set; } = new List<Performer>();
        public List<SocialShare> SocialShares { get; set; } = new List<SocialShare>();
    }
}
