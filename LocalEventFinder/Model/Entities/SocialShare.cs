namespace LocalEventFinder.Model.Entities
{
    public class SocialShare
    {
        public int ShareId { get; set; } 
        public int UserId { get; set; } 
        public int EventId { get; set; } 
        public string SharedPlatform { get; set; } // e.g., 'Facebook', 'Twitter'
        public DateTime ShareTimestamp { get; set; } 
    }
}
