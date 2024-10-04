namespace LocalEventFinder.Model.Entities
{
    public class EventSubmission
    {
        public int EventSubmissionId { get; set; } 
        public int UserId { get; set; } 
        //public int? EventId { get; set; } 
        public DateTime SubmissionDate { get; set; }
        public string SubmissionStatus { get; set; } // e.g., 'pending', 'approved', 'rejected'
    }
}
