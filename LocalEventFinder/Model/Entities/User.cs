namespace LocalEventFinder.Model.Entities
{
    public class User
    {
        public int UserId { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Role { get; set; }
        public decimal LocationLatitude { get; set; }
        public decimal LocationLongitude { get; set; }
        public string ProfilePictureUrl { get; set; }
        public List<string> Interests { get; set; } 
        public List<string> EventPreferences { get; set; } // Filters for events
        public List<Event> Events { get; set; } // Events this user RSVPs to
        public List<EventSubmission> EventSubmissions { get; set; } // Events submitted by this user
        public List<SocialShare> SocialShares { get; set; }

    }
}
