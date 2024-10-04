using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace LocalEventFinder.Migrations
{
    /// <inheritdoc />
    public partial class Init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    CategoryId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IconUrl = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.CategoryId);
                });

            migrationBuilder.CreateTable(
                name: "Organizers",
                columns: table => new
                {
                    OrganizerId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OrganizerName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ContactInformation = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    OrganizerType = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Organizers", x => x.OrganizerId);
                });

            migrationBuilder.CreateTable(
                name: "Performers",
                columns: table => new
                {
                    PerformerId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Age = table.Column<int>(type: "int", nullable: false),
                    SharedPlatform = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Performers", x => x.PerformerId);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Role = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LocationLatitude = table.Column<decimal>(type: "decimal(9,6)", nullable: false),
                    LocationLongitude = table.Column<decimal>(type: "decimal(9,6)", nullable: false),
                    ProfilePictureUrl = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Interests = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EventPreferences = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.UserId);
                });

            migrationBuilder.CreateTable(
                name: "Events",
                columns: table => new
                {
                    EventId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EventDateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LocationName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LocationAddress = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LocationLatitude = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    LocationLongitude = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    RsvpCount = table.Column<int>(type: "int", nullable: false),
                    ImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    OrganizerId = table.Column<int>(type: "int", nullable: false),
                    CategoryId = table.Column<int>(type: "int", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Events", x => x.EventId);
                    table.ForeignKey(
                        name: "FK_Events_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "CategoryId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Events_Organizers_OrganizerId",
                        column: x => x.OrganizerId,
                        principalTable: "Organizers",
                        principalColumn: "OrganizerId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Events_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "UserId");
                });

            migrationBuilder.CreateTable(
                name: "EventSubmissions",
                columns: table => new
                {
                    EventSubmissionId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    SubmissionDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    SubmissionStatus = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EventSubmissions", x => x.EventSubmissionId);
                    table.ForeignKey(
                        name: "FK_EventSubmissions_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "EventPerformer",
                columns: table => new
                {
                    EventsEventId = table.Column<int>(type: "int", nullable: false),
                    PerformersPerformerId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EventPerformer", x => new { x.EventsEventId, x.PerformersPerformerId });
                    table.ForeignKey(
                        name: "FK_EventPerformer_Events_EventsEventId",
                        column: x => x.EventsEventId,
                        principalTable: "Events",
                        principalColumn: "EventId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EventPerformer_Performers_PerformersPerformerId",
                        column: x => x.PerformersPerformerId,
                        principalTable: "Performers",
                        principalColumn: "PerformerId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SocialShares",
                columns: table => new
                {
                    ShareId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    EventId = table.Column<int>(type: "int", nullable: false),
                    SharedPlatform = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ShareTimestamp = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SocialShares", x => x.ShareId);
                    table.ForeignKey(
                        name: "FK_SocialShares_Events_EventId",
                        column: x => x.EventId,
                        principalTable: "Events",
                        principalColumn: "EventId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SocialShares_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "CategoryId", "Description", "IconUrl", "Name" },
                values: new object[,]
                {
                    { 1, "All kinds of music events", "music_icon.png", "Music" },
                    { 2, "Art exhibitions and shows", "art_icon.png", "Art" }
                });

            migrationBuilder.InsertData(
                table: "Organizers",
                columns: new[] { "OrganizerId", "ContactInformation", "OrganizerName", "OrganizerType" },
                values: new object[,]
                {
                    { 1, "info@cityconcerts.com", "City Concerts", "Organization" },
                    { 2, "contact@localartscouncil.org", "Local Arts Council", "Organization" }
                });

            migrationBuilder.InsertData(
                table: "Performers",
                columns: new[] { "PerformerId", "Age", "Name", "SharedPlatform" },
                values: new object[,]
                {
                    { 1, 30, "John Doe", "Instagram" },
                    { 2, 25, "Jane Smith", "YouTube" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "UserId", "Email", "EventPreferences", "Interests", "LocationLatitude", "LocationLongitude", "Name", "ProfilePictureUrl", "Role" },
                values: new object[,]
                {
                    { 1, "johndoe@example.com", "[\"Concerts\",\"Exhibitions\"]", "[\"Music\",\"Sports\"]", 34.0522m, -118.2437m, "John Doe", "http://example.com/johndoe.jpg", "User" },
                    { 2, "bob@example.com", "[\"Concerts\",\"Exhibitions\"]", "[\"Music\",\"Sports\"]", 34.0522m, -118.2437m, "Bob Brown", "http://example.com/johndoe.jpg", "User" }
                });

            migrationBuilder.InsertData(
                table: "EventSubmissions",
                columns: new[] { "EventSubmissionId", "SubmissionDate", "SubmissionStatus", "UserId" },
                values: new object[,]
                {
                    { 1, new DateTime(2024, 10, 4, 11, 20, 46, 712, DateTimeKind.Utc).AddTicks(3452), "approved", 1 },
                    { 2, new DateTime(2024, 10, 4, 11, 20, 46, 712, DateTimeKind.Utc).AddTicks(3454), "pending", 2 }
                });

            migrationBuilder.InsertData(
                table: "Events",
                columns: new[] { "EventId", "CategoryId", "Description", "EventDateTime", "ImageUrl", "LocationAddress", "LocationLatitude", "LocationLongitude", "LocationName", "OrganizerId", "RsvpCount", "Title", "UserId" },
                values: new object[,]
                {
                    { 1, 1, "Join us for a night of rock music!", new DateTime(2024, 11, 4, 11, 20, 46, 712, DateTimeKind.Utc).AddTicks(3421), "rock_concert.jpg", "123 Main St, Los Angeles, CA", 34.0522m, -118.2437m, "Downtown Arena", 1, 0, "Rock Concert", null },
                    { 2, 2, "Explore contemporary art by local artists.", new DateTime(2024, 12, 4, 11, 20, 46, 712, DateTimeKind.Utc).AddTicks(3431), "art_exhibition.jpg", "456 Art St, Los Angeles, CA", 34.0522m, -118.2437m, "City Gallery", 2, 0, "Art Exhibition", null }
                });

            migrationBuilder.InsertData(
                table: "SocialShares",
                columns: new[] { "ShareId", "EventId", "ShareTimestamp", "SharedPlatform", "UserId" },
                values: new object[,]
                {
                    { 1, 1, new DateTime(2024, 10, 4, 11, 20, 46, 712, DateTimeKind.Utc).AddTicks(3470), "Facebook", 1 },
                    { 2, 2, new DateTime(2024, 10, 4, 11, 20, 46, 712, DateTimeKind.Utc).AddTicks(3472), "Twitter", 2 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_EventPerformer_PerformersPerformerId",
                table: "EventPerformer",
                column: "PerformersPerformerId");

            migrationBuilder.CreateIndex(
                name: "IX_Events_CategoryId",
                table: "Events",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Events_OrganizerId",
                table: "Events",
                column: "OrganizerId");

            migrationBuilder.CreateIndex(
                name: "IX_Events_UserId",
                table: "Events",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_EventSubmissions_UserId",
                table: "EventSubmissions",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_SocialShares_EventId",
                table: "SocialShares",
                column: "EventId");

            migrationBuilder.CreateIndex(
                name: "IX_SocialShares_UserId",
                table: "SocialShares",
                column: "UserId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EventPerformer");

            migrationBuilder.DropTable(
                name: "EventSubmissions");

            migrationBuilder.DropTable(
                name: "SocialShares");

            migrationBuilder.DropTable(
                name: "Performers");

            migrationBuilder.DropTable(
                name: "Events");

            migrationBuilder.DropTable(
                name: "Categories");

            migrationBuilder.DropTable(
                name: "Organizers");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
