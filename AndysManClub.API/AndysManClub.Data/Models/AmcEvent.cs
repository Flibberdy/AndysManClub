using System.ComponentModel.DataAnnotations.Schema;

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

    // Theoretically just one person - so we could use firstordefault and return just a personevent
    public List<PersonEvent> GetOrganisers()
    {
        return Volunteers.FindAll(e => e.IsOrganiser == true);
    }

    public List<PersonEvent> GetVolunteers()
    {
        return Volunteers.FindAll(e => e.IsOrganiser == false);
    }

    public void RegisterPerson(Person person)
    {
        var personEvent = new PersonEvent
        {
            Volunteer = person,
            Event = this,
            IsOrganiser = false
        };

        Volunteers.Add(personEvent);
    }
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
