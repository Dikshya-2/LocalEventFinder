namespace LocalEventFinder.Model.Entities
{
    public class UserEvent
    {
        public int UserId { get; set; } 
        public int EventId { get; set; } 
        public string RsvpStatus { get; set; } // e.g., 'going', 'interested', 'not going'
        public DateTime ResponseTimestamp { get; set; } // Date/Time of response
    }
}
