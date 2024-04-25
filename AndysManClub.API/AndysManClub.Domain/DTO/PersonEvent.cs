namespace AndysManClub.Domain.DTO;

public class PersonEvent
{
    public Guid Id { get; set; }
    
    public required AmcEvent Event { get; set; }
    
    public required Person Volunteer { get; set; }

    public bool IsOrganiser { get; set; }

}