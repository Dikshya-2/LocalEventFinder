using LocalEventFinder.Model.Entities;
using Microsoft.EntityFrameworkCore;

namespace LocalEventFinder.Model
{
    public class DatabaseContext:DbContext
    {
        public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options) { }
        public DbSet<User> Users { get; set; }
        public DbSet<Event> Events { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Organizer> Organizers { get; set; }
        public DbSet<Performer> Performers { get; set; }
        public DbSet<EventSubmission> EventSubmissions { get; set; }
        public DbSet<SocialShare> SocialShares { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<SocialShare>()
               .HasKey(ss => ss.ShareId);

            // Specify precision and scale for decimal properties
            modelBuilder.Entity<User>()
                .Property(u => u.LocationLatitude)
                .HasColumnType("decimal(9, 6)");

            modelBuilder.Entity<User>()
               .Property(u => u.LocationLongitude)
               .HasColumnType("decimal(9, 6)");

            // Seeding data for Categories
            modelBuilder.Entity<Category>().HasData(
       new Category { CategoryId = 1, Name = "Music", Description = "All kinds of music events", IconUrl = "music_icon.png" },
       new Category { CategoryId = 2, Name = "Art", Description = "Art exhibitions and shows", IconUrl = "art_icon.png" }
   );

            // Seeding data for Organizers
            modelBuilder.Entity<Organizer>().HasData(
                new Organizer { OrganizerId = 1, OrganizerName = "City Concerts", ContactInformation = "info@cityconcerts.com", OrganizerType = "Organization" },
                new Organizer { OrganizerId = 2, OrganizerName = "Local Arts Council", ContactInformation = "contact@localartscouncil.org", OrganizerType = "Organization" }
            );

            // Seeding data for Performers (SharedPlatform is now provided)
            modelBuilder.Entity<Performer>().HasData(
                new Performer { PerformerId = 1, Name = "John Doe", Age = 30, SharedPlatform = "Instagram" },
                new Performer { PerformerId = 2, Name = "Jane Smith", Age = 25, SharedPlatform = "YouTube" }
            );

            // Seeding data for Users
            modelBuilder.Entity<User>().HasData(
                new User
                {
                    UserId = 1,
                    Name = "John Doe",
                    Email = "johndoe@example.com",
                    Role = "User",
                    LocationLatitude = 34.0522m,
                    LocationLongitude = -118.2437m,
                    ProfilePictureUrl = "http://example.com/johndoe.jpg",
                    Interests = new List<string> { "Music", "Sports" },
                    EventPreferences = new List<string> { "Concerts", "Exhibitions" }
                },
                new User
                {
                    UserId = 2,
                    Name = "Bob Brown",
                    Email = "bob@example.com",
                    Role = "User",
                    LocationLatitude = 34.0522M,
                    LocationLongitude = -118.2437M,
                    ProfilePictureUrl = "http://example.com/johndoe.jpg",
                    Interests = new List<string> { "Music", "Sports" },
                    EventPreferences = new List<string> { "Concerts", "Exhibitions" }
                }
            );

            // Seeding data for Events
            modelBuilder.Entity<Event>().HasData(
     new Event
     {
         EventId = 1,
         Title = "Rock Concert",
         Description = "Join us for a night of rock music!",
         EventDateTime = DateTime.UtcNow.AddMonths(1),
         LocationName = "Downtown Arena",
         LocationAddress = "123 Main St, Los Angeles, CA",
         LocationLatitude = 34.0522M,
         LocationLongitude = -118.2437M,
         RsvpCount = 0,
         ImageUrl = "rock_concert.jpg",
         OrganizerId = 1, // Foreign Key reference
         CategoryId = 1 // Valid CategoryId reference
     },
     new Event
     {
         EventId = 2,
         Title = "Art Exhibition",
         Description = "Explore contemporary art by local artists.",
         EventDateTime = DateTime.UtcNow.AddMonths(2),
         LocationName = "City Gallery",
         LocationAddress = "456 Art St, Los Angeles, CA",
         LocationLatitude = 34.0522M,
         LocationLongitude = -118.2437M,
         RsvpCount = 0,
         ImageUrl = "art_exhibition.jpg",
         OrganizerId = 2, // Foreign Key reference
         CategoryId = 2 // Valid CategoryId reference
     }
 );


            // Seeding data for Event Submissions
            modelBuilder.Entity<EventSubmission>().HasData(
                new EventSubmission { EventSubmissionId = 1, UserId = 1, SubmissionDate = DateTime.UtcNow, SubmissionStatus = "approved" },
                new EventSubmission { EventSubmissionId = 2, UserId = 2, SubmissionDate = DateTime.UtcNow, SubmissionStatus = "pending" }
            );

            // Seeding data for Social Shares
            modelBuilder.Entity<SocialShare>().HasData(
                new SocialShare { ShareId = 1, UserId = 1, EventId = 1, SharedPlatform = "Facebook", ShareTimestamp = DateTime.UtcNow },
                new SocialShare { ShareId = 2, UserId = 2, EventId = 2, SharedPlatform = "Twitter", ShareTimestamp = DateTime.UtcNow }
            );
        }

    }
}
