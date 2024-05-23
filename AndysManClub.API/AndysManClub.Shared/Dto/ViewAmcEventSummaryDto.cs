namespace AndysManClub.Shared.Dto;

public class ViewAmcEventSummaryDto
{
    public Guid OrganiserId { get; set; }
    public required string Title { get; set; }
    public string? Description { get; set; }
    public required string Location { get; set; }
    public DateTime? EventDateTime { get; set; }
    public bool IsActive { get; set; }
    public int VolunteerCount { get; set; }
}