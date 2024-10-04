namespace LocalEventFinder.Model.Entities
{
    public class Organizer
    {
        public int OrganizerId { get; set; } 
        public string OrganizerName { get; set; }
        public string ContactInformation { get; set; } 
        public string OrganizerType { get; set; } 
        public List<Event> Events { get; set; } = new List<Event>(); 

    }
}
