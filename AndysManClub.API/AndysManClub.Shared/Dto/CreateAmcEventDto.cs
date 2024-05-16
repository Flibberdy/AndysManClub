namespace AndysManClub.Shared.Dto
{
    public class CreateAmcEventDto
    {
        public Guid OrganiserId { get; set; }
        public required string Title { get; set; }
        public string? Description { get; set; }
        public required string Location { get; set; }
        public DateTime? EventDateTime { get; set; }
    }
}
