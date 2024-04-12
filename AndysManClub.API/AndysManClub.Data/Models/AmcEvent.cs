using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace AndysManClub.Data.Models;

[Table("AmcEvent")]
public class AmcEvent
{
    public AmcEvent()
    {
        Id = Guid.NewGuid();
    }

    public Guid Id { get; set; }
    public required string Title { get; set; }
    public string? Description { get; set; }
    public required string Location { get; set; }
    public DateTime? EventDateTime { get; set; }
    public bool IsActive { get; set; }
    public List<PersonEvent> Volunteers { get; set; }
}


[Table(nameof(PersonEvent))]
public class PersonEvent
{
    public Guid Id { get; set; }
    
    [ForeignKey(nameof(AmcEvent))]
    public required AmcEvent Event { get; set; }
    
    [ForeignKey(nameof(Person))]
    public required Person Volunteer { get; set; }
    
    public bool IsOrganiser { get; set; }

}
